using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using Neo4j.Driver.V1;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class GraphSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly Dictionary<string, string> cypherQueries = new Dictionary<string, string>() {
                                                                    { "page_with_html","" }
                                                                    };
        public GraphSteps(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        //public bool matchGraphQueryResultsWithDictionary(string cypherQuery, Dictionary<string, string> expectedresults, out string message)
        //{
        //    bool match;
        //    message = "";
        //    Neo4JHelper neo4JHelper = new Neo4JHelper();
        //    neo4JHelper.connect(_scenarioContext.GetEnv().neo4JUrl,
        //                        _scenarioContext.GetEnv().neo4JUid,
        //                        _scenarioContext.GetEnv().neo4JPassword);

        //    var results = neo4JHelper.GetSingleRowAsDictionary(cypherQuery);

        //    match = DictionaryHelper.AreEqual(expectedresults, results);
        //    if (!match)
        //    {
        //        message = $"Expected: \n{DictionaryHelper.DictionaryToString(expectedresults)}\n";
        //        message += $"Actual: \n{DictionaryHelper.DictionaryToString(results)}\n";
        //    }
        //    return match;
        //}

        //[Given(@"I confirm the following ""(.*)"" data is preset in the Graph Database")]
        //public void GivenIConfirmTheFollowingDataIsPresetInTheGraphDatabase(string p0, Table table)
        //{
        //    bool addPrefix = _scenarioContext.ContainsKey(constants.prefixField);
        //    foreach (var r in table.Rows)
        //    {
        //        Dictionary<string, string> rowData = new Dictionary<string, string>();
        //        int count = 0;
        //        string cyperQuery = $"match (i:{p0}) where i.uri = '";
        //        string message;
        //        foreach (var i in r)
        //        {
        //            string newValue = i.Value;
        //            if (addPrefix && i.Key == (string)_scenarioContext[constants.prefixField])
        //            {
        //                newValue = (string)_scenarioContext[constants.prefix] + newValue;
        //            }
        //            count++;
        //            rowData.Add(i.Key, newValue);
        //            if (count == 1)
        //            {
        //                cyperQuery += $"{newValue}' return i.uri as uri";
        //            }
        //            else
        //            {
        //                cyperQuery += $" ,i.{i.Key} as {i.Key}";
        //            }

        //        }
        //        var match = matchGraphQueryResultsWithDictionary(cyperQuery, rowData, out message);
        //        if (!match)
        //        {
        //            Console.WriteLine("**confirm the following data is preset in the Graph Database**");
        //            Console.WriteLine("Mismatch between expected and actual results");
        //            Console.WriteLine(message);
        //        }
        //        match.Should().BeTrue();
        //    }
        //}


        //[Then(@"the ""(.*)"" graph matches the expect results using the ""(.*)"" query")]
        //public void ThenTheGraphMatchesTheExpectResultsUsingTheQuery(string graphReference, string queryReference, Table expectedResults)
        //{
        //    cypherQueries.Should().ContainKey(queryReference);

        //}

    }
}
