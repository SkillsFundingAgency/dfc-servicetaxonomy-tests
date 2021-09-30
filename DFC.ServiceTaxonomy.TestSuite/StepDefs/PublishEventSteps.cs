using System;
using System.Collections.Generic;
using System.Threading;

using DFC.ServiceTaxonomy.SharedResources.Helpers;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Models;

using FluentAssertions;

using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class PublishEventSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public PublishEventSteps(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        [Then(@"an event of type ""(.*)"" has been issued to notify consumers of the change")]
        public void ThenAnEventOfTypeHasBeenIssuedToNotifyConsumersOfTheChange(string eventType)
        {
            ThenEventsOfTypeHasBeenIssuedToNotifyConsumersOfTheChange(1, eventType);
        }

        [Then(@"(.*) events of type ""(.*)"" has been issued to notify consumers of the change")]
        public void ThenEventsOfTypeHasBeenIssuedToNotifyConsumersOfTheChange(int p0, string eventType)
        {
            if (!_scenarioContext.GetEnv().CheckEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            Console.WriteLine("Wait for 10 seconds to allow events to come through");
            Thread.Sleep(10000);

            //string id = _scenarioContext.GetContentItemId(_scenarioContext.GetNumberOfStoredContentIds() - 1);
            string uri = _scenarioContext.GetLatestUri().Replace("<<contentapiprefix>>", "/content");

            //List<ContentItemIndexRow> indexes = _scenarioContext.GetContentItemIndexList();
            //indexes.Count.Should().BeGreaterThan(0, "Because otherwise no data has been stored to check against");

            int numberOfEvents = _scenarioContext.ContainsKey($"countOf{eventType.ToLower()}Events") ? (int)_scenarioContext[$"countOf{eventType.ToLower()}Events"] : 0;
            //// mock the response until event store is up and running
            //MockEvent(id, _scenarioContext.GetUri(0), eventType);

            List<ContentEvent> list = GetMatchingDocuments(uri, eventType.ToLower());
            if (list.Count < numberOfEvents + p0)
            {
                Console.WriteLine("Wait longer");
                Thread.Sleep(5000);
                list = GetMatchingDocuments(uri, eventType.ToLower());
            }
            list.Count.Should().Be(numberOfEvents + p0, "Because a cosmos document relating to the event message should have been found");

            //TODO incorporate check of dates and contentitemversion
        }

        private List<ContentEvent> GetMatchingDocuments(string id, string eventType = "")
        {
            string additionalClause = eventType.Equals(string.Empty) ? string.Empty : $" and c.eventType = '{eventType.ToLower()}'";
            string query = $"SELECT * FROM c where  c.subject = '{id}'{additionalClause}";

            CosmosHelper.Initialise(_scenarioContext.GetEnv().EventStoreEndPoint, _scenarioContext.GetEnv().EventStoreKey);
            List<ContentEvent> list = CosmosHelper.SearchForDocuments<ContentEvent>("dfc-eventstore", "events", query);

            Console.WriteLine($"Check Event Store: found {list.Count} with query '{query}'");
            return list;
        }

        [Then(@"the number of events sent for this content Item is (.*)")]
        public void ThenTheNumberOfEventsSentForThisContentItemIs(int p0)
        {
            if (!_scenarioContext.GetEnv().CheckEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            //string id = _scenarioContext.GetContentItemId(_scenarioContext.GetNumberOfStoredContentIds() - 1);
            string uri = _scenarioContext.GetLatestUri().Replace("<<contentapiprefix>>", "/content");
            List<ContentEvent> list = GetMatchingDocuments(uri);
            list.Count.Should().Be(p0, $"Because the total number of events sent should be {p0}");

        }

        [Then(@"no event is issued")]
        public void ThenNoEventIsIssued()
        {
            if (!_scenarioContext.GetEnv().CheckEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            // pause to ensure events are received
            Thread.Sleep(10000);
            //string id = _scenarioContext.GetContentItemId(0);
            string uri = _scenarioContext.GetLatestUri().Replace("<<contentapiprefix>>", "/content");
            int numberOfEvents = _scenarioContext.ContainsKey("TotalEvents") ? (int)_scenarioContext["TotalEvents"] : 0;

            List<ContentEvent> list = GetMatchingDocuments(uri);

            list.Count.Should().Be(numberOfEvents, "Because no more events should have been raised");
        }

        [Given(@"I check the number of events sent for this contentItem")]
        public void GivenICheckTheNumberOfEventsSentForThisContentItem()
        {
            if (!_scenarioContext.GetEnv().CheckEvents)
            {
                Console.WriteLine("Event store checks are disabled in App Settings");
                return;
            }
            // pause to ensure events are received
            Thread.Sleep(10000);
            //string id = _scenarioContext.GetContentItemId(0);
            string uri = _scenarioContext.GetLatestUri().Replace("<<contentapiprefix>>", "/content");
            List<ContentEvent> list = GetMatchingDocuments(uri);

            Dictionary<string, int> tallys = new Dictionary<string, int>();
            foreach (var item in list)
            {
                int val = tallys.ContainsKey(item.eventType.ToLower()) ? tallys[item.eventType.ToLower()] : 0;
                val++;
                tallys[item.eventType] = val;
            }

            int numberOfEvents = 0;
            foreach (var item in tallys)
            {
                Console.WriteLine($"{item.Value} messages of type {item.Key} detected for uri {uri}");
                _scenarioContext[$"countOf{item.Key}Events"] = item.Value;
                numberOfEvents += item.Value;
            }
            Console.WriteLine($"Total {numberOfEvents} messages detected for uri {uri}");
            _scenarioContext["TotalEvents"] = numberOfEvents;
        }
    }
}
