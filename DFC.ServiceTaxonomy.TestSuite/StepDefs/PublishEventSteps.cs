using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using TechTalk.SpecFlow;
using DFC.ServiceTaxonomy.SharedResources;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using System.Threading;
using TechTalk.SpecFlow.Analytics.AppInsights;
using AngleSharp.Common;
using Dapper;
using AngleSharp.Dom.Events;

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

            return;
            if (!_scenarioContext.GetEnv().checkEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            string id = _scenarioContext.GetContentItemId(_scenarioContext.GetNumberOfStoredContentIds()-1);
            List<ContentItemIndexRow> indexes = _scenarioContext.GetContentItemIndexList();

            indexes.Count.Should().BeGreaterThan(0, "Because otherwise no data has been stored to check against");

            var capturedEvents = _scenarioContext.GetCapturedEvents();
            //            // mock the response until event store is up and running
            //            MockEvent(id, _scenarioContext.GetUri(0), eventType);
            int existingEventsOfType = capturedEvents.Where(x => x.eventType.ToLower() == eventType.ToLower()).Count();
            //List<ContentEvent> list = RetryHelper.RetryOnEmptyList<ContentEvent>(3, new TimeSpan(3000), GetMatchingDocuments(id, eventType ));
            var args = new Dictionary<string, string>()
            {
                { cosmosId, id }//,
                //{ cosmosEventType, eventType },
                //{ cosmosVersionId, indexes.Last().ContentItemVersionId }
            };

            //TODO use polly or something
            List<ContentEvent> list = null;
            bool success = false;
            int count = 0;
            int maxTries = 5;
            while (!success && count++ < maxTries)
            {
                list = GetMatchingDocuments(new string[] { }, args);
                var matchingItems = list.Where(x => x.eventType.ToLower() == eventType.ToLower() &&
                                                    x.data.versionId == indexes.Last().ContentItemVersionId).ToList();
                if (matchingItems.Count() == existingEventsOfType + 1 )
                {
                    success = true;
                }
                else
                {
                    Thread.Sleep(retryWaitPeriodMS);
                    count++;
                }
            }
            success.Should().BeTrue("Because a cosmos document relating to the event message should have been found");
            _scenarioContext.SetCapturedEvents(list);

            //TODO incorporate check of dates and contentitemversion
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
            //            // mock the response until event store is up and running
            //            MockEvent(id, _scenarioContext.GetUri(0), eventType);
          //  int existingEventsOfType = capturedEvents.Where(x => x.eventType.ToLower() == eventType.ToLower()).Count();
            //List<ContentEvent> list = RetryHelper.RetryOnEmptyList<ContentEvent>(3, new TimeSpan(3000), GetMatchingDocuments(id, eventType ));
            var args = new Dictionary<string, string>()
            {
                { cosmosId, id }//,
                //{ cosmosEventType, eventType },
                //{ cosmosVersionId, indexes.Last().ContentItemVersionId }
            };

            //TODO use polly or something
            List<ContentEvent> list = null;
            bool success = false;
            int count = 0;
            int maxTries = 5;
            while (!success && count++ < maxTries)
            {
                list = GetMatchingDocuments(new string[] { }, args);
                var versionMatches = list.Where(x => x.data.versionId == indexes.Last().ContentItemVersionId).ToList();
                foreach ( var row in table.Rows)
                {
                    var typeMatches = versionMatches.Where(x => x.eventType.ToLower() == row[0].ToLower()).ToList();
                    int existingEventsOfType = capturedEvents.Where(x => x.eventType.ToLower() == row[0].ToLower()).Count();
                    success = (typeMatches.Count() == existingEventsOfType + 1);
                }
                if (!success)
                {
                    Thread.Sleep(retryWaitPeriodMS);
                    count++;
                }
            }
            success.Should().BeTrue("Because a cosmos document relating to the event message should have been found");
            _scenarioContext.SetCapturedEvents(list);
        }


        [Then(@"an event of type ""(.*)"" has been issued to notify consumers of the change and (.*) others")]
        public void ThenAnEventOfTypeHasBeenIssuedToNotifyConsumersOfTheChangeAndOthers(string p0, int p1)
        {
            //TODO also check that no unintended events have been published
        }



        [Then(@"an event has been published to notify consumers of the change")]
        public void ThenAnEventHasBeenPublishedToNotifyConsumersOfTheChange()
        {
        //    // get expected content id
        //    string uri = _scenarioContext.GetUri(0);

        //    // attempt to retrieve document
        //    // there maybe more than one for the given uri
        //    string document = CosmosHelper.RetrieveDocumentAsString(_scenarioContext.GetEnv().eventStoreConnectionString, _scenarioContext.GetEnv().eventStoreKey, uri);
        //    ContentEvent contentEvent = JsonConvert.DeserializeObject<ContentEvent>(document);
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

            CosmosHelper.InsertDocumentFromJson<ContentEvent>("EventStore",
                                                              "events",
                                                              mockItem,
                                                              out response);

        }

        //private List<ContentEvent> GetMatchingDocuments(string id, string eventType = "")
        //{
        //    string additionalClause = eventType.Equals(string.Empty) ? string.Empty : $" and c.eventType = '{eventType.ToLower()}'";
        //    string query = $"SELECT * FROM c where  c.data.workflowCorrelationId = '{id}'{additionalClause}";

        //    CosmosHelper.Initialise(_scenarioContext.GetEnv().eventStoreEndPoint, _scenarioContext.GetEnv().eventStoreKey);
        //    List<ContentEvent> list = CosmosHelper.SearchForDocuments<ContentEvent>("dfc-eventstore", "events", query);

        //    return list;
        //}

        //private List<ContentEvent> GetMatchingDocuments(string id, string eventType, string contentVersionId)
        //{
        //    string additionalClause = eventType.Equals(string.Empty) ? string.Empty : $" and c.eventType = '{eventType.ToLower()}' and c.data.versionId = '{contentVersionId}'";
        //    string query = $"SELECT * FROM c where  c.data.workflowCorrelationId = '{id}'{additionalClause}";

        //    CosmosHelper.Initialise(_scenarioContext.GetEnv().eventStoreEndPoint, _scenarioContext.GetEnv().eventStoreKey);
        //    List<ContentEvent> list = CosmosHelper.SearchForDocuments<ContentEvent>("dfc-eventstore", "events", query);

        //    return list;
        //}

        private List<ContentEvent> GetMatchingDocuments(string[] fields, Dictionary<string, string> args, int expectedRecords = 0)
        {
            args.Count.Should().BeGreaterThan(0, "No params have been passed to build a query");
            CosmosHelper.Initialise(_scenarioContext.GetEnv().eventStoreEndPoint, _scenarioContext.GetEnv().eventStoreKey);
            List<ContentEvent> list = CosmosHelper.SearchForDocuments<ContentEvent>("dfc-eventstore", "events", CosmosHelper.BuildQuery(fields, args));

            return list;
        }

        //private List<ContentEvent> GetMatchingDocuments(Dictionary<string,string> args, int expectedRecords = 0)
        //{
        //    args.Count.Should().BeGreaterThan(0, "No params have been passed to build a query");
        //    CosmosHelper.Initialise(_scenarioContext.GetEnv().eventStoreEndPoint, _scenarioContext.GetEnv().eventStoreKey);
        //    List<ContentEvent> list = CosmosHelper.SearchForDocuments<ContentEvent>("dfc-eventstore", "events", CosmosHelper.BuildQuery(new string[] { },args));

        //    return list;
        //}

        [Then(@"no event is issued")]
        public void ThenNoEventIsIssued()
        {
            if (!_scenarioContext.GetEnv().checkEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            //give any events a chance to come through
            Thread.Sleep(10000);

            List<ContentEvent> capturedEvents = _scenarioContext.GetCapturedEvents();
            string id = _scenarioContext.GetLatestContentItemId();
            
            var args = new Dictionary<string, string>()
            {
                { cosmosId, id }
            };
            List<ContentEvent> list = GetMatchingDocuments(new string[] { }, args,0);

            list.Count().Should().Be(capturedEvents.Count(), "Because no more events should have been raised");
        }

        //[Given(@"I check time of the latest event message")]
        //public void GivenICheckTimeOfTheLatestEventMessage()
        //{
        //    string id = _scenarioContext.GetContentItemId(0);
        //    string query = $"SELECT * FROM c where  c.data.itemId = '{id}'";

        //    CosmosHelper.Initialise(_scenarioContext.GetEnv().eventStoreEndPoint, _scenarioContext.GetEnv().eventStoreKey);
        //    List<ContentEvent> list = CosmosHelper.SearchForDocuments<ContentEvent>("EventStore", "events", query);
        //    //TODO
        //    Console.WriteLine($"");
        //}

        [Given(@"I check the number of events sent for this contentItem")]
        public void GivenICheckTheNumberOfEventsSentForThisContentItem()
        {
            if (!_scenarioContext.GetEnv().checkEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            //give any events a chance to come through
            Thread.Sleep(10000);

            string id = _scenarioContext.GetContentItemId(0);

            var args = new Dictionary<string, string>()
            {
                { cosmosId, id }
            };
            List<ContentEvent> list = GetMatchingDocuments(new string[] {  }, args);

            _scenarioContext.SetCapturedEvents(list);

            //Dictionary<string, int> tallys = new Dictionary<string, int>();
            //foreach (var item in list)
            //{
            //    int val = tallys.ContainsKey(item.eventType) ? tallys[item.eventType] : 0;
            //    tallys[item.eventType] = val + 1;
            //}

            //int numberOfEvents = 0;
            //foreach ( var item in tallys)
            //{
            //    Console.WriteLine($"{item.Value} messages of type {item.Key} detected for document {id}");
            //    numberOfEvents += item.Value;
            //    _scenarioContext[$"countOf{item.Key.ToLower()}Events"] = numberOfEvents;
            //}
            //Console.WriteLine($"Total {numberOfEvents} messages detected for document {id}");
            //_scenarioContext["TotalEvents"] = numberOfEvents;
        }

        //[Given(@"I check the number of events sent for this contentItem is (.*)")]
        //public void GivenICheckTheNumberOfEventsSentForThisContentItemIs(int expectedEvents)
        //{
        //    if (!_scenarioContext.GetEnv().checkEvents)
        //    {
        //        Console.WriteLine("Event store checks are disabled in App Settings");
        //        return;
        //    }
        //    string id = _scenarioContext.GetContentItemId(0);

        //    var args = new Dictionary<string, string>()
        //    {
        //        { cosmosId, id }
        //    };
        //    List<ContentEvent> list = GetMatchingDocuments(new string[] { }, args, expectedEvents);

        //    _scenarioContext["capturedEvents"] = list;


        //}

    }
}
