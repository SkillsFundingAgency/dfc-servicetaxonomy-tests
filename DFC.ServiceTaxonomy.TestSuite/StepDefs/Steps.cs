﻿using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class Steps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        EnvironmentSettings env = new EnvironmentSettings();

        private readonly ScenarioContext context;

        public Steps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            context.Pending();
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            //TODO: implement act (action) logic

            context.Pending();
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            context.Pending();
        }

        [Given(@"The Occupation ID i wish to look up is (.*)")]
        public void GivenTheOccupationIDIWishToLookUpIs(string occupationId)
        {
            context["occupationId"] = occupationId;
        }

        [When(@"I make the request")]
        public void WhenIMakeTheRequest()
        {
            context["RestResponse"] = RestHelper.Get("https://localhost:44349/cypher/" + context["occupationId"]);

        }

        [Then(@"The number of skills returned is (.*)")]
        public void ThenTheNumberOfSkillsReturnedIs(int p0)
        {
            IRestResponse response = (IRestResponse)context["RestResponse"];
            var a = JsonHelper.DocumentCount(response.Content);
            NUnit.Framework.Assert.AreEqual(a, p0);
        }


        [Given(@"I get a list of occupations from esco")]
        public void GivenIGetAListOfOccupationsFromEsco()
        {

            IRestResponse response = RestHelper.Get(env.escoApiBaseUrl + "/search?language=en&type=occupation&limit=10000");
            JObject escoResults = JObject.Parse(response.Content);
            IList<JToken> results = escoResults["_embedded"]["results"].Children().ToList();
            IList <EscoDataItem> escoData = new List<EscoDataItem>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                EscoDataItem escoDataItem = result.ToObject<EscoDataItem>();
                escoData.Add(escoDataItem);
            }

        }

    }
}
