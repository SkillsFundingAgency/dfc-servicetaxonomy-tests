using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using System.Threading;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class PublishEventSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private const string cosmosId = "data.workflowCorrelationId";
        private const string cosmosEventType = "eventType";
        private const string cosmosVersionId = "data.versionId";
        private const int defaultWaitPeriodMS = 10000;
        private const int retryWaitPeriodMS = 4000;
        public PublishEventSteps(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        [Then(@"an event of type ""(.*)"" has been issued to notify consumers of the change")]
        public void ThenAnEventOfTypeHasBeenIssuedToNotifyConsumersOfTheChange(string eventType)
        {
            Table eventTable = new Table(new string[]{ "EventType" });
            eventTable.AddRow(new string[] { eventType });
            ThenTheFollowingNewEventsHaveBeenIssuedToNotifyConsumersOfTheChange(eventTable);
            //TODO incorporate check of dates
        }

        [Then(@"the following new events have been issued to notify consumers of the change")]
        public void ThenTheFollowingNewEventsHaveBeenIssuedToNotifyConsumersOfTheChange(Table table)
        {
            if (!_scenarioContext.GetEnv().checkEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            string id = _scenarioContext.GetContentItemId(_scenarioContext.GetNumberOfStoredContentIds() - 1);
            List<ContentItemIndexRow> indexes = _scenarioContext.GetContentItemIndexList();
            indexes.Count.Should().BeGreaterThan(0, "Because otherwise no data has been stored to check against");

            var capturedEvents = _scenarioContext.GetCapturedEvents();

            // mock the response until event store is up and running
            //            MockEvent(id, _scenarioContext.GetUri(0), eventType);

            var args = new Dictionary<string, string>()
            {
                { cosmosId, id }
            };

            //TODO use polly or something
            List<ContentEvent> list = null;
            bool success = false;
            int count = 0;
            int maxTries = 5;
            while (!success && count++ < maxTries)
            {
                list = GetMatchingDocuments(new string[] { }, args);
                // removed  versio check due to complexity of version ids in false positive tests
                //TODO add additional logic to cater for this and re-instate
                //var versionMatches = list.Where(x => x.data.versionId == indexes.Last().ContentItemVersionId).ToList();
                int matchCount = 0;
                foreach ( var row in table.Rows)
                {
                    var typeMatches = list.Where(x => x.eventType.ToLower() == row[0].ToLower()).ToList();
                    int existingEventsOfType = capturedEvents.Where(x => x.eventType.ToLower() == row[0].ToLower()).Count();
                    matchCount += typeMatches.Count() == existingEventsOfType + 1 ? 1 : 0;
                }
                success = matchCount == table.Rows.Count;
                if (!success)
                {
                    Thread.Sleep(retryWaitPeriodMS);
                    count++;
                }
            }
            success.Should().BeTrue("Because a cosmos document relating to the event message should have been found");
            _scenarioContext.SetCapturedEvents(list);
        }

        private void  MockEvent(string reference, string uri, string expectedType, bool pass = true )
        {
            ContentEvent mockItem = new ContentEvent();
            
            mockItem.eventType = expectedType;
            mockItem.id = Guid.NewGuid().ToString();
            mockItem.subject = "/content/sharedcontent/29849536-f716-468d-bf49-41446cb68284";
            mockItem.eventTime = "";
            mockItem.dataVersion = "";
            mockItem.metadataVersion = "";
            mockItem.topic = "";
            mockItem.data.itemId = reference;
            mockItem.data.api = uri;
            mockItem.data.versionId = Guid.NewGuid().ToString();
            mockItem.data.displayText = "some content";
            mockItem.data.author = "Fred";

            string response;
            CosmosHelper.Initialise(_scenarioContext.GetEnv().eventStoreEndPoint, _scenarioContext.GetEnv().eventStoreKey);

            CosmosHelper.InsertDocumentFromJson<ContentEvent>("dfc-eventStore",
                                                              "events",
                                                              mockItem,
                                                              out response);
        }

        private List<ContentEvent> GetMatchingDocuments(string[] fields, Dictionary<string, string> args)
        {
            args.Count.Should().BeGreaterThan(0, "No params have been passed to build a query");
            
            CosmosHelper.Initialise(_scenarioContext.GetEnv().eventStoreEndPoint, _scenarioContext.GetEnv().eventStoreKey);
            List<ContentEvent> list = CosmosHelper.SearchForDocuments<ContentEvent>("dfc-eventstore", "events", CosmosHelper.BuildQuery(fields, args));
            return list;
        }

        [Then(@"no event is issued")]
        public void ThenNoEventIsIssued()
        {
            if (!_scenarioContext.GetEnv().checkEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            //give any events a chance to come through
            Thread.Sleep(defaultWaitPeriodMS);

            List<ContentEvent> capturedEvents = _scenarioContext.GetCapturedEvents();
            string id = _scenarioContext.GetLatestContentItemId();
            
            var args = new Dictionary<string, string>()
            {
                { cosmosId, id }
            };
            List<ContentEvent> list = GetMatchingDocuments(new string[] { }, args);

            list.Count().Should().Be(capturedEvents.Count(), "Because no more events should have been raised");
        }

        [Given(@"I check the number of events sent for this contentItem")]
        public void GivenICheckTheNumberOfEventsSentForThisContentItem()
        {
            if (!_scenarioContext.GetEnv().checkEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            //give any events a chance to come through
            Thread.Sleep(defaultWaitPeriodMS);

            string id = _scenarioContext.GetContentItemId(0);

            var args = new Dictionary<string, string>()
            {
                { cosmosId, id }
            };
            List<ContentEvent> list = GetMatchingDocuments(new string[] {  }, args);

            _scenarioContext.SetCapturedEvents(list);
        }
    }
}
