using DFC.ServiceTaxonomy.Events.Models;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    [Binding]
    public sealed class CleanUp
    {
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public CleanUp(ScenarioContext context, FeatureContext fContext)
        {
            _scenarioContext = context;
            _featureContext = fContext;
        }

        private void TeardownDataWithPrefix(string prefix, string field)
        {
            //SQL
            (bool result, string message) = _scenarioContext.DeleteSQLRecordsWithPrefix(prefix);
            Console.WriteLine($"CLEANUP: Deleted SQL Records with prefix {prefix}: {message}");

            if (!result)
            {
                _scenarioContext.AddFeatureFailure("Sql Cleardown", message);
            }

            //graph
            try
            {
                result = _scenarioContext.DeleteGraphNodesWithPrefix(field, prefix);
                Console.WriteLine("CLEANUP: Succesfully deleted GRAPH items prefixed with " + prefix);
            }
            catch (Exception e)
            {
                _scenarioContext.AddFeatureFailure("Neo Cleardown", e.Message);
            }
        }

        [AfterScenario("webtest", Order = 10)]
        public void TearDownData()
        {
            if (_scenarioContext.ContainsKey("prefix"))
            {
                string prefix = _scenarioContext["prefix"].ToString();
                string prefixField = _scenarioContext["prefixField"].ToString();

                TeardownDataWithPrefix(prefix, prefixField);

                if (_scenarioContext.GetEnv().pipelineRun)
                {
                    TeardownDataWithPrefix(constants.testDataPrefix, prefixField);
                }
            }



        }

        [AfterScenario("webtest", Order = 15)]
        public void TearDownDataInUI()
        {
            StartPage _startPage = new StartPage(_scenarioContext);
            EditPageLocationTaxonomy _editPageLocationTaxonomy = new EditPageLocationTaxonomy(_scenarioContext);
            foreach (var location in _scenarioContext.GetPageLocations())
            {
                // attempt to delete page location through the UI 
                _startPage.NavigateTo("/Admin/Contents/ContentItems/4eembshqzx66drajtdten34tc8/Edit");
                _editPageLocationTaxonomy.DeletePageLocation(location);
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

        
        [AfterFeature("webtest",Order = 20)]
        public static void CloseWebDriver()
        {
            WebDriverContainer.Instance.CloseDriver();
        }

        [AfterScenario( Order = 100)]
        public void CheckForNotifiableFailure()
        {
            if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError )
            {
            }
            if (_scenarioContext.ContainsKey(constants.featureFailure))
            {
                string messageText = "Fatal error(s) detected in clean up:\n";

                // cancel the rest of the feature run
                _featureContext[constants.featureFailAll] = true;

                foreach ( var message in (Dictionary<string,string>)_scenarioContext[constants.featureFailure] )
                {
                    Console.WriteLine($"Error: {message.Key} - {message.Value}");
                    messageText += $"  {message.Key} - {message.Value}";
                }
                throw new Exception(messageText);

            }
        }
    }
}
