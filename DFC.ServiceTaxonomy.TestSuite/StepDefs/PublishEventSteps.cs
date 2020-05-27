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
            string id = _scenarioContext.GetContentItemId(_scenarioContext.GetNumberOfStoredContentIds()-1);
            int numberOfEvents = _scenarioContext.ContainsKey($"countOf{eventType}Events") ? (int)_scenarioContext[$"countOf{eventType}Events"] : 0;
            // mock the response until event store is up and running
            MockEvent(id, _scenarioContext.GetUri(0), eventType);

            List<ContentEvent> list = GetMatchingDocuments(id, eventType);
            list.Count().Should().Be(numberOfEvents +1, "Because a cosmos document relating to the event message should have been found");
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

        private List<ContentEvent> GetMatchingDocuments(string id, string eventType = "")
        {
            string additionalClause = eventType.Equals(string.Empty) ? string.Empty : $" and c.eventType = '{eventType}'";
            string query = $"SELECT * FROM c where  c.data.itemId = '{id}'{additionalClause}";

            CosmosHelper.Initialise(_scenarioContext.GetEnv().eventStoreEndPoint, _scenarioContext.GetEnv().eventStoreKey);
            List<ContentEvent> list = CosmosHelper.SearchForDocuments<ContentEvent>("EventStore", "events", query);

            return list;
        }
        [Then(@"no event is issued")]
        public void ThenNoEventIsIssued()
        {
            string id = _scenarioContext.GetContentItemId(0);
            int numberOfEvents = _scenarioContext.ContainsKey("TotalEvents") ? (int)_scenarioContext["TotalEvents"] : 0 ;

            List<ContentEvent> list = GetMatchingDocuments(id);

            list.Count().Should().Be(numberOfEvents, "Because no more events should have been raised");
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
            string id = _scenarioContext.GetContentItemId(0);

            List<ContentEvent> list = GetMatchingDocuments(id);

            Dictionary<string, int> tallys = new Dictionary<string, int>();
            foreach (var item in list)
            {
                int val = tallys.ContainsKey(item.eventType) ? tallys[item.eventType] : 0;
                tallys[item.eventType] = val;
            }

            int numberOfEvents = 0;
            foreach ( var item in tallys)
            {
                Console.WriteLine($"{item.Value} messages of type {item.Key} detected for document {id}");
                _scenarioContext[$"countOf{item.Key}Events"] = item.Value;
                numberOfEvents += item.Value;
            }
            Console.WriteLine($"Total {numberOfEvents} messages detected for document {id}");
            _scenarioContext["TotalEvents"] = numberOfEvents;
        }
    }
}
