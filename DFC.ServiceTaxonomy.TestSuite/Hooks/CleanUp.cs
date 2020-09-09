using DFC.ServiceTaxonomy.Events.Models;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

//using Microsoft.Extensions.DependencyInjection;


namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    [Binding]
    public sealed class CleanUp
    {
        private ScenarioContext _scenarioContext;
        //private IEventGridContentRestHttpClientFactory i;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public CleanUp(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        [AfterScenario("webtest", Order = 10)]
        public void TearDownData()
        {
            if (_scenarioContext.ContainsKey("prefix"))
            {
                string prefix = _scenarioContext["prefix"].ToString();
                string prefixField = _scenarioContext["prefixField"].ToString();
                // attempt to clear down data from sql and neo where title / skos__PrefLabel begins with prefix

                //SQL
                int count = _scenarioContext.DeleteSQLRecordsWithPrefix(prefix);
                Console.WriteLine("CLEANUP: Deleted " + count + "content items prefixed with " + prefix);

                //graph
                bool result = _scenarioContext.DeleteGraphNodesWithPrefix(prefixField, prefix);
                Console.WriteLine("CLEANUP: Succesfully deleted GRAPH items prefixed with " + prefix);
            }

        }

        [AfterScenario(Order = 1)]
        public void TearDownDataItems()
        {
            // clear down based on stored uri
            foreach (var item in _scenarioContext.GetDataItems().Where(x => x.TearDownGraph))
            {
                //clear graph based on URI
                bool result = _scenarioContext.DeleteGraphNodesWithUri(item.Uri);
                Console.WriteLine($"CLEANUP: Succesfully deleted GRAPH items with uri {item.Uri}");

            }
            foreach (var item in _scenarioContext.GetDataItems().Where(x => x.TearDownSql))
            {
                //clear SQL based on URI
                Console.WriteLine("CLEANUP: Sql clear down based on URI not yet implemented");

            }
            var env = _scenarioContext.GetEnv();
            var dataItems = _scenarioContext.GetContentItemIndexList();
            if (env.sendEvents && env.sqlServerChecksEnabled && dataItems.Count > 0)
            { 
                foreach (var item in dataItems)
                {
                    ContentItem contentItem = new ContentItem();
                    contentItem.Author = item.Author;
                    contentItem.ContentItemId = item.ContentItemId;
                    contentItem.ContentItemVersionId = item.ContentItemVersionId;
                    contentItem.ContentType = item.ContentType;
                    contentItem.CreatedUtc = DateTime.Parse(item.CreatedUtc);
                    contentItem.DisplayText = item.DisplayText;
                    var uri = _scenarioContext.GetLatestUri().Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl);
                    ContentEvent contentEvent = new ContentEvent(contentItem, uri, DFC.ServiceTaxonomy.Events.Models.ContentEventType.Deleted);
                    string json = $"[{JsonConvert.SerializeObject(contentEvent)}]";
                    var response = RestHelper.Post(env.eventTopicUrl, json, new Dictionary<string, string>() { { "Aeg-sas-key", env.AegSasKey } });
                    Console.WriteLine($"CLEANUP: send delete event for {uri} - Response Code:{response.StatusCode}");
                }
             }
        }

        [AfterScenario("webtest", Order = 20)]
        public void CLoseWebDriver()
        {
            _scenarioContext.GetWebDriver().Close();
        }
    }
}
