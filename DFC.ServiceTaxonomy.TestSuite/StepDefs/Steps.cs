using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.TestSuite.Context;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly ApiRequest testContext;
        public Steps(ScenarioContext injectedContext, ApiRequest injectedTestContext)
        {
            context = injectedContext;
            testContext = injectedTestContext;
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

        public void GetEscoSearchResults(string type, int limit)
        {
            int totalValues = 0;
            int offset = 0;
            bool gotAll = false;

            while (!gotAll)
            { 
                // make call to esco api. 
                testContext.apiResponse = RestHelper.Get(env.escoApiBaseUrl + "/search?language=en&type=" + type + "&limit=" + limit.ToString() + ( offset == 0 ? "" : "&offset=" + offset ) );

                // confirm response was ok
                testContext.apiResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                // parse the response data as json
                JObject escoResults = JObject.Parse(testContext.apiResponse.Content);

                int.TryParse(escoResults.GetValue("total").ToString(),out totalValues);
                offset++;
                //extract the data that we are interested in to a list
                IList<JToken> results = escoResults["_embedded"]["results"].Children().ToList();

                //convert to a list of escoDataItems
                foreach (JToken result in results)
                {
                    EscoDataItem escoDataItem = result.ToObject<EscoDataItem>();
                    testContext.escoData.Add(escoDataItem);
                }
                gotAll = (totalValues <= testContext.escoData.Count);
            }
        }

        [Given(@"I get a list of occupations from esco")]
        public void GivenIGetAListOfOccupationsFromEsco()
        {
            // get esco data. currently less that 3000 returned results so limit of 10000 is ample
            GetEscoSearchResults("occupation", 10000);
        }

        [Given(@"I get a list of skills from esco")]
        public void GivenIGetAListOfSkillsFromEsco()
        {
            // get esco data. currently less that 15000 returned results so limit of 20000 is ample
            GetEscoSearchResults("skill", 10000);
        }

        [Given(@"I request all occupations from the NCS API")]
        public void GivenIRequestAllOccupationsFromTheNCSAPI()
        {
            IRestResponse response = RestHelper.Get(testContext.GetTaxonomyUri("GetAllOccupations"),testContext.taxonomyApiHeaders);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JObject ncsResults = JObject.Parse(response.Content);
            IList<JToken> results = ncsResults["occupations"].Children().ToList();
            foreach (JToken result in results)
            {
                Occupation occupation = result.ToObject<Occupation>();
                testContext.occupations.Add(occupation);
            }
        }

        [Given(@"I request all skills from the NCS API")]
        public void GivenIRequestAllSkillsFromTheNCSAPI()
        {
            IRestResponse response = RestHelper.Get(testContext.GetTaxonomyUri("GetAllSkills"), testContext.taxonomyApiHeaders);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JObject ncsResults = JObject.Parse(response.Content);
            IList<JToken> results = ncsResults["skills"].Children().ToList();
            foreach (JToken result in results)
            {
                Skill skill = result.ToObject<Skill>();
                testContext.skills.Add(skill);
            }
        }

        static bool AreEqual(IDictionary<string, string> thisItems, IDictionary<string, string> otherItems)
        {
            if (thisItems.Count != otherItems.Count)
            {
                return false;
            }
            var thisKeys = thisItems.Keys;
            foreach (var key in thisKeys)
            {
                if (!(otherItems.TryGetValue(key, out var value) &&
                      string.Equals(thisItems[key], value, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
            }
            return true;
        }

        [Then(@"the occupations returned by each service match")]
        public void ThenTheOccupationsReturnedByEachServiceMatch()
        {
            // convert esco response data  and occupation response data to dictionaries of title and uri
            var escoOccupations = testContext.escoData.ToDictionary(x => x.title, x=>x.uri);
            var ncsOccupations = testContext.occupations.ToDictionary(x => x.occupation, x => x.uri);

            //confirm the dictionaries are equivalent
            bool match = AreEqual(escoOccupations, ncsOccupations);

            // assert result
            match.Should().BeTrue();
        }


        [Then(@"the skills returned by each service match")]
        public void ThenTheSkillsReturnedByEachServiceMatch()
        {
            // convert esco response data  and occupation response data to dictionaries of title and uri
            var escoSkills = testContext.escoData.ToDictionary(x => x.title + testContext.GetSkillOrKnowlegeFromSkillTypeUri(x.hasSkillType[0]), x => x.uri);
            var ncsSkills = testContext.skills.ToDictionary(x => x.skill + x.skillType, x => x.uri);

            var newList = testContext.escoData.Where(x => x.hasSkillType.Count() > 1);
            foreach (var item in newList)
            {
                escoSkills.Add(item.title + testContext.GetSkillOrKnowlegeFromSkillTypeUri(item.hasSkillType[1]), item.uri);
            }

            //confirm the dictionaries are equivalent
            bool match = AreEqual(escoSkills, ncsSkills);

            // assert result
            match.Should().BeTrue();
        }


        [Then(@"the alternate labels listed for first Occupation returned matches esco data")]
        public void ThenTheAlternateLabelsListedForFirstOccupationReturnedMatchesEscoData()
        {
            // confirm occupation reponse data exists
            testContext.occupations.Count.Should().BeGreaterThan(0, "Because as least 1 occupation should exist in the response data");

            // check first occupation in reponse data
            CheckNthOccupationReturnedForAlternateLabelMatch<Occupation>( 1, ref testContext.occupations).Should().BeTrue();
        }

        [Then(@"the alternate labels listed for mid Occupation returned matches esco data")]
        public void ThenTheAlternateLabelsListedForMidOccupationReturnedMatchesEscoData()
        {
            // if more than three occupations in the list, check the middle one
            if (testContext.occupations.Count > 3)
            {
                //CheckNthOccupationReturnedForAlternateLabelMatch((int)Math.Ceiling((double) testContext.occupations.Count / 2 )).Should().BeTrue();
                CheckNthOccupationReturnedForAlternateLabelMatch<Occupation>((int)Math.Ceiling((double)testContext.occupations.Count / 2), ref testContext.occupations).Should().BeTrue();
            }
        }

        [Then(@"the alternate labels listed for last Occupation returned matches esco data")]
        public void ThenTheAlternateLabelsListedForLastOccupationReturnedMatchesEscoData()
        {
            // if more than one occupation in the list, check the last one
            if (testContext.occupations.Count > 1)
            {
                CheckNthOccupationReturnedForAlternateLabelMatch<Occupation>(testContext.occupations.Count, ref testContext.occupations).Should().BeTrue();
            }
        }

        [Then(@"the alternate labels listed for first Skill returned matches esco data")]
        public void ThenTheAlternateLabelsListedForFirstSkillReturnedMatchesEscoData()
        {
            // confirm occupation reponse data exists
            testContext.skills.Count.Should().BeGreaterThan(0, "Because as least 1 occupation should exist in the response data");

            // check first occupation in reponse data
            CheckNthOccupationReturnedForAlternateLabelMatch<Skill>(1, ref testContext.skills).Should().BeTrue();
        }

        [Then(@"the alternate labels listed for mid Skill returned matches esco data")]
        public void ThenTheAlternateLabelsListedForMidSkillReturnedMatchesEscoData()
        {
            // if more than three occupations in the list, check the middle one
            if (testContext.skills.Count > 3)
            {
                //CheckNthOccupationReturnedForAlternateLabelMatch((int)Math.Ceiling((double) testContext.occupations.Count / 2 )).Should().BeTrue();
                CheckNthOccupationReturnedForAlternateLabelMatch<Skill>((int)Math.Ceiling((double)testContext.skills.Count / 2), ref testContext.skills).Should().BeTrue();
            }
        }

        [Then(@"the alternate labels listed for last Skill returned matches esco data")]
        public void ThenTheAlternateLabelsListedForLastSkillReturnedMatchesEscoData()
        {
            // if more than three occupations in the list, check the middle one
            if (testContext.skills.Count > 3)
            {
                //CheckNthOccupationReturnedForAlternateLabelMatch((int)Math.Ceiling((double) testContext.occupations.Count / 2 )).Should().BeTrue();
                CheckNthOccupationReturnedForAlternateLabelMatch<Skill>(testContext.skills.Count, ref testContext.skills).Should().BeTrue();
            }
        }


        public bool CheckNthOccupationReturnedForAlternateLabelMatch<T>(int n, ref IList<T> ncsData) where T : NcsEntity
        {
            // get nth occupation in ncs response
            string uri = ncsData[n - 1].uri;

            // make call to esco api to get alternate labels
            testContext.apiResponse = RestHelper.Get(env.escoApiBaseUrl + "/resource/" + ncsData[0].GetType().Name.ToLower() + "? language=en&uri=" + uri);

            // confirm response was ok
            testContext.apiResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // parse the response data as json
            JObject escoResults = JObject.Parse(testContext.apiResponse.Content);

            //extract the data that we are interested in to a list
            IList<JToken> results = escoResults["alternativeLabel"]["en"].Children().ToList();

            testContext.valueList.Clear();
            Dictionary<string, string> escoAlternativeReferences = new Dictionary<string, string>();

            //convert to a list of strings and store in test context
            foreach (JToken result in results)
            {
                string value = result.ToObject<string>();
                testContext.valueList.Add(value);
                escoAlternativeReferences.Add(value, "");
            }

            //convert to key only dictionary
            var ncsAlternateLabels = ncsData[n - 1].alternativeLabels.ToDictionary(x => x, x => "");

            // confirm match with ncs api response data
            return AreEqual(escoAlternativeReferences, ncsAlternateLabels);
        }
    }
}
