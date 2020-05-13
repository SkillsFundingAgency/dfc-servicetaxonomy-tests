using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    class ContosoItemReceivedEventData
    {
        [JsonProperty(PropertyName = "itemSku")]
        public string ItemSku { get; set; }
    }

    [Binding]
    public sealed class EventGridSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public EventGridSteps(ScenarioContext injectedContext)
        {
            _scenarioContext = injectedContext;
        }

        [Given(@"an event is published")]
        public void GivenAnEventIsPublished()
        {
            const string CustomTopicEvent = "Contoso.Items.ItemReceived";

            EventGridSubscriber eventGridSubscriber = new EventGridSubscriber();
            eventGridSubscriber.AddOrUpdateCustomEventMapping(CustomTopicEvent, typeof(ContosoItemReceivedEventData));
          //  EventGridEvent[] eventGridEvents = eventGridSubscriber.DeserializeEventGridEvents();
        }


    }
}
