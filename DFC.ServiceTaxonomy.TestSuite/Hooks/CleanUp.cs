﻿using DFC.ServiceTaxonomy.Events.Models;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;


//using Microsoft.Extensions.DependencyInjection;


namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    [Binding]
    public sealed class CleanUp
    {
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;
        //private IEventGridContentRestHttpClientFactory i;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public CleanUp(ScenarioContext context, FeatureContext fContext)//, IServiceCollection services)
        {
            _scenarioContext = context;
            _featureContext = fContext;
            // services.AddSingleton<IEventGridContentRestHttpClientFactory>(i);
        }

        private void TeardownDataWithPrefix(string prefix, string field)
        {
            //SQL
            (bool result, string message) = _scenarioContext.DeleteSQLRecordsWithPrefix(prefix);
            Console.WriteLine($"CLEANUP: Deleted SQL Records with prefix {prefix}: {message}");

            if (!result)
            {
                _scenarioContext.AddNotifiableFailure("Sql Cleardown", message);
            }

            //graph
            try
            {
                result = _scenarioContext.DeleteGraphNodesWithPrefix(field, prefix);
                Console.WriteLine("CLEANUP: Succesfully deleted GRAPH items prefixed with " + prefix);
            }
            catch (Exception e)
            {
                _scenarioContext.AddNotifiableFailure("Neo Cleardown", e.Message);
            }
        }

        [AfterScenario("webtest", Order = 10)]
        public void TearDownData()
        {
            if (_scenarioContext.ContainsKey("prefix"))
            {
                string prefix = _scenarioContext["prefix"].ToString();
                string prefixField = _scenarioContext["prefixField"].ToString();

                TeardownDataWithPrefix(prefixField, prefix);

                if (_scenarioContext.GetEnv().pipelineRun)
                {
                    TeardownDataWithPrefix(prefixField, constants.testDataPrefix);
                }
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
        public void CloseWebDriver()
        {
            _scenarioContext.GetWebDriver().Close();
            _scenarioContext.GetWebDriver().Quit();
        }

        [AfterScenario( Order = 100)]
        public void CheckForNotifiableFailure()
        {
            if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError )
            {
            }
            if (_scenarioContext.ContainsKey(constants.NotifiableFailure))
            {
                string messageText = "Fatal error(s) detected in clean up:\n";

                // cancel the rest of the feature run
                _featureContext["failAll"] = true;

                foreach ( var message in (Dictionary<string,string>)_scenarioContext[constants.NotifiableFailure] )
                {
                    Console.WriteLine($"Error: {message.Key} - {message.Value}");
                    messageText += $"  {message.Key} - {message.Value}";
                }
                throw new Exception(messageText);

            }

        }
    }
}
