using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
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
using TechTalk.SpecFlow.Assist;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class ApiSteps
    {
        #region consts
        private const string cypher_skillWithRelatedJobProfile = "MATCH (s:esco__Skill) --> (o:esco__Occupation) -- (j:ncs__JobProfile) RETURN distinct s.uri";
        private const string cypher_AddJobProfileAndRelationToOccupation = "to define";
        private const string cypher_occupationWithRelatedJobProfile = "MATCH (o:esco__Occupation) -- (j:ncs__JobProfile) RETURN o.uri";
        #endregion


        private readonly ScenarioContext context;

        public ApiSteps(ScenarioContext injectedContext )
        {
            context = injectedContext;
        }

        public void GetEscoSearchResults(string type, int limit)
        {
            int totalValues = 0;
            int offset = 0;
            bool gotAll = false;
            IList<EscoDataItem> escoData = new List<EscoDataItem>();

            while (!gotAll)
            {
                // make call to esco api. 
                var response = RestHelper.Get( context.GetEscoApiBaseUrl() + "/search?language=en&type=" + type + "&limit=" + limit.ToString() + (offset == 0 ? "" : "&offset=" + offset) );

                // confirm response was ok
                response.StatusCode.Should().Be( HttpStatusCode.OK );

                // parse the response data as json
                JObject escoResults = JObject.Parse( response.Content );

                int.TryParse( escoResults.GetValue("total").ToString(),out totalValues );
                offset++;
                //extract the data that we are interested in to a list
                IList<JToken> results = escoResults["_embedded"]["results"].Children().ToList();
                //convert to a list of escoDataItems
                foreach (JToken result in results)
                {
                    EscoDataItem escoDataItem = result.ToObject<EscoDataItem>();
                    escoData.Add(escoDataItem);
                }
                gotAll = (totalValues <= escoData.Count);
            }
            context.SetEscoItemListData( escoData );
        }

        [Given(@"I get a list of occupations from esco")]
        public void GivenIGetAListOfOccupationsFromEsco()
        {
            // get esco data. currently less that 3000 returned results so limit of 10000 is ample
            GetEscoSearchResults( "occupation", 10000 );
        }

        [Given(@"I get a list of skills from esco")]
        public void GivenIGetAListOfSkillsFromEsco()
        {
            // get esco data. currently less that 15000 returned results so limit of 20000 is ample
            GetEscoSearchResults( "skill", 10000 );
        }

        [Given(@"I request all occupations from the NCS API")]
        public void GivenIRequestAllOccupationsFromTheNCSAPI()
        {
            IList<Occupation> occupations = new List<Occupation>();

            var response = RestHelper.Get( context.GetTaxonomyUri("GetAllOccupations"),context.GetTaxonomyApiHeaders() );
            response.StatusCode.Should().Be( HttpStatusCode.OK );

            JObject ncsResults = JObject.Parse( response.Content );
            IList<JToken> results = ncsResults["occupations"].Children().ToList();
            foreach (JToken result in results)
            {
                Occupation occupation = result.ToObject<Occupation>();
                occupations.Add( occupation );
            }

            context.SetOccupationListData( occupations );
        }

        [Given(@"I request all occupations with related job profile from the NCS API")]
        public void GivenIRequestAllOccupationsWithRelatedJobProfileFromTheNCSAPI()
        {
            IList<Occupation> occupations = new List<Occupation>();

            var response = RestHelper.Get(context.GetTaxonomyUri("GetAllOccupationsWithRelatedJobProfile"), context.GetTaxonomyApiHeaders());
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JObject ncsResults = JObject.Parse(response.Content);
            IList<JToken> results = ncsResults["occupations"].Children().ToList();
            foreach (JToken result in results)
            {
                Occupation occupation = result.ToObject<Occupation>();
                occupations.Add(occupation);
            }

            context.SetOccupationListData(occupations);
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        [Given(@"I want to supply an invalid security header")]
        public void GivenIWantToSupplyAnInvalidSecurityHeader()
        {
            context["securityHeader"] = new Dictionary<string, string> () { { "Ocp-Apim-Subscription-Key", "12345" } };
        }

        [Given(@"I want to fail to send a security header")]
        public void GivenIWantToFailToSendASecurityHeader()
        {
            context["securityHeader"] = new Dictionary<string, string>() ;
        }

        [Given(@"I want to supply ""(.*)"" as a parameter in the following request")]
        public void GivenIWantToSupplyAsAParameterInTheFollowingRequest(string p0)
        {
            context["requestParam"] = p0;
        }


        [Given(@"I make a request to the service taxonomy API ""(.*)""")]
        public void GivenIMakeARequestToTheServiceTaxonomyAPI(string p0, Table table)
        {
            string requestBody = "{}";
            string param = (context.ContainsKey("requestParam") ? context["requestParam"].ToString() : "");
            var requestItems = ToDictionary(table);
            foreach ( var item in requestItems )
            {
               requestBody = JsonHelper.AddPropertyToJsonString(requestBody, item.Key, item.Value);
            }
            var response = RestHelper.Post(context.GetTaxonomyUri(p0,param), requestBody, ( context.ContainsKey("securityHeader") ? (Dictionary<string, string>)context["securityHeader"] : context.GetTaxonomyApiHeaders() ) );
            //response.StatusCode.Should().Be(HttpStatusCode.OK);
            context["responseStatus"] = response.StatusCode;
            context["responseBody"] = response.Content;
        }

        [Given(@"I make a request to the service taxonomy API ""(.*)"" with request body")]
        public void GivenIMakeARequestToTheServiceTaxonomyAPIWithRequestBody(string p0, string multilineText)
        {
            string param = (context.ContainsKey("requestParam") ? context["requestParam"].ToString() : "");
            var response = RestHelper.Post(context.GetTaxonomyUri(p0,param), multilineText, (context.ContainsKey("securityHeader") ? (Dictionary<string, string>)context["securityHeader"] : context.GetTaxonomyApiHeaders()));
            //response.StatusCode.Should().Be(HttpStatusCode.OK);
            context["responseStatus"] = response.StatusCode;
            context["responseBody"] = response.Content;
        }


        [Given(@"I request all skills from the NCS API")]
        public void GivenIRequestAllSkillsFromTheNCSAPI()
        {
            IList<Skill> skills = new List<Skill>();

            IRestResponse response = RestHelper.Get( context.GetTaxonomyUri("GetAllSkills"), context.GetTaxonomyApiHeaders() );
            response.StatusCode.Should().Be( HttpStatusCode.OK );

            JObject ncsResults = JObject.Parse( response.Content );
            IList<JToken> results = ncsResults["skills"].Children().ToList();
            foreach (JToken result in results)
            {
                Skill skill = result.ToObject<Skill>();
                skills.Add( skill );
            }

            context.SetSkillListData( skills );
        }

        [Given(@"I request all skills with related job profile from the NCS API")]
        public void GivenIRequestAllSkillsWithRelatedJobProfileFromTheNCSAPI()
        {
            IList<Skill> skills = new List<Skill>();

            IRestResponse response = RestHelper.Get(context.GetTaxonomyUri("GetAllSkillsWithRelationshipToJobProfile"), context.GetTaxonomyApiHeaders());
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JObject ncsResults = JObject.Parse(response.Content);
            IList<JToken> results = ncsResults["skills"].Children().ToList();
            foreach (JToken result in results)
            {
                Skill skill = result.ToObject<Skill>();
                skills.Add(skill);
            }

            context.SetSkillListData(skills);
        }
        
        [Given(@"I have made sure that ""(.*)"" with related job profiles are present in the graph datastore")]
        public void GivenIHaveMadeSureThatWithRelatedJobProfilesArePresentInTheGraphDatastore(string p0)
        {
            //  check how many skills exist for occupations with related job profile
            var statementTemplate = (p0.ToLower().Equals("skills") ? cypher_skillWithRelatedJobProfile : cypher_occupationWithRelatedJobProfile );
            // var statementParameters = new Dictionary<string, object> { { "uri", context.Get<string>(keyGeneratedUri) } };

            Neo4JHelper neo4JHelper = new Neo4JHelper();
            neo4JHelper.connect(context.GetEnv().neo4JUrl,
                                    context.GetEnv().neo4JUid,
                                    context.GetEnv().neo4JPassword);

            int numberOfRecords = neo4JHelper.GetRecordCount(statementTemplate, null);

            if (numberOfRecords < 1)
            {
                // add a record
                neo4JHelper.ExecuteTableQuery(cypher_AddJobProfileAndRelationToOccupation, null);
            }

            // check success
            numberOfRecords = neo4JHelper.GetRecordCount(statementTemplate, null);
            numberOfRecords.Should().BeGreaterThan(0);

            // store in context
            context.SetExpectedRecordCount(numberOfRecords);
        }




        //[Given(@"I have made sure that occupations with related job profiles are present in the graph datastore")]
        //public void GivenIHaveMadeSureThatOccupationsWithRelatedJobProfilesArePresentInTheGraphDatastore()
        //{
        //    //  check how many skills exist for occupations with related job profile
        //    var statementTemplate = cypher_skillWithRelatedJobProfile;
        //   // var statementParameters = new Dictionary<string, object> { { "uri", context.Get<string>(keyGeneratedUri) } };

        //    Neo4JHelper neo4JHelper = new Neo4JHelper();
        //    neo4JHelper.connect(context.GetEnv().neo4JUrl,
        //                            context.GetEnv().neo4JUid,
        //                            context.GetEnv().neo4JPassword);

        //    int numberOfRecords = neo4JHelper.GetRecordCount(statementTemplate, null);

        //    if ( numberOfRecords < 1)
        //    {
        //        // add a record
        //        neo4JHelper.ExecuteTableQuery(cypher_AddJobProfileAndRelationToOccupation,null);
        //    }

        //    // check success
        //    numberOfRecords = neo4JHelper.GetRecordCount(statementTemplate, null);
        //    numberOfRecords.Should().BeGreaterThan(0);

        //    // store in context
        //    context.SetExpectedRecordCount(numberOfRecords);
        //}

        static bool AreEqual(IDictionary<string, string> thisItems, IDictionary<string, string> otherItems)
        {
            if (thisItems.Count != otherItems.Count)
            {
                return false;
            }
            var thisKeys = thisItems.Keys;
            foreach (var key in thisKeys)
            {
                if ( !  (otherItems.TryGetValue( key, out var value ) 
                     && string.Equals( thisItems[key], value, StringComparison.OrdinalIgnoreCase) )
                    )
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
            var escoOccupations = context.GetEscoItemListData().ToDictionary(x => x.title, x=>x.uri);
            var ncsOccupations = context.GetOccupationListData().ToDictionary(x => x.occupation, x => x.uri);

            //confirm the dictionaries are equivalent
            bool match = AreEqual(escoOccupations, ncsOccupations);

            // assert result
            match.Should().BeTrue();
        }


        [Then(@"the skills returned by each service match")]
        public void ThenTheSkillsReturnedByEachServiceMatch()
        {
            // convert esco response data  and occupation response data to dictionaries of title and uri
            var escoSkills = context.GetEscoItemListData().ToDictionary( x => x.title + context.GetSkillOrKnowlegeFromSkillTypeUri( x.hasSkillType[0] ), x => x.uri );
            var ncsSkills = context.GetSkillListData().ToDictionary( x => x.skill + x.skillType, x => x.uri );

            var newList = context.GetEscoItemListData().Where( x => x.hasSkillType.Count() > 1 );
            foreach (var item in newList)
            {
                escoSkills.Add(item.title + context.GetSkillOrKnowlegeFromSkillTypeUri( item.hasSkillType[1] ), item.uri );
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
            context.GetOccupationListData().Count.Should().BeGreaterThan( 0, "Because as least 1 occupation should exist in the response data" );

            // check first occupation in reponse data
            CheckNthOccupationReturnedForAlternateLabelMatch<Occupation>( 1,
                                                                          context.GetOccupationListData()
                                                                          ).Should().BeTrue();
        }

        [Then(@"the alternate labels listed for mid Occupation returned matches esco data")]
        public void ThenTheAlternateLabelsListedForMidOccupationReturnedMatchesEscoData()
        {
            // if more than three occupations in the list, check the middle one
            if (context.GetOccupationCount() > 3)
            {
                CheckNthOccupationReturnedForAlternateLabelMatch<Occupation>(   (int)Math.Ceiling((double)context.GetOccupationCount() / 2),
                                                                                context.GetOccupationListData()
                                                                                ).Should().BeTrue();
            }
        }

        [Then(@"the alternate labels listed for last Occupation returned matches esco data")]
        public void ThenTheAlternateLabelsListedForLastOccupationReturnedMatchesEscoData()
        {
            // if more than one occupation in the list, check the last one
            if (context.GetOccupationCount() > 1)
            {
                CheckNthOccupationReturnedForAlternateLabelMatch<Occupation>(   context.GetOccupationCount(),
                                                                                context.GetOccupationListData()
                                                                                ).Should().BeTrue();
            }
        }

        [Then(@"the alternate labels listed for first Skill returned matches esco data")]
        public void ThenTheAlternateLabelsListedForFirstSkillReturnedMatchesEscoData()
        {
            // confirm occupation reponse data exists
           context.GetSkillCount().Should().BeGreaterThan(0, "Because as least 1 occupation should exist in the response data");

            // check first occupation in reponse data
            CheckNthOccupationReturnedForAlternateLabelMatch<Skill>(    1,
                                                                        context.GetSkillListData()
                                                                        ).Should().BeTrue();
        }

        [Then(@"the alternate labels listed for mid Skill returned matches esco data")]
        public void ThenTheAlternateLabelsListedForMidSkillReturnedMatchesEscoData()
        {
            // if more than three occupations in the list, check the middle one
            if (context.GetSkillCount() > 3)
            {
                CheckNthOccupationReturnedForAlternateLabelMatch<Skill>(    (int)Math.Ceiling((double)context.GetSkillCount() / 2),
                                                                            context.GetSkillListData()
                                                                            ).Should().BeTrue();
            }
        }

        [Then(@"the alternate labels listed for last Skill returned matches esco data")]
        public void ThenTheAlternateLabelsListedForLastSkillReturnedMatchesEscoData()
        {
            // if more than two occupations in the list, check the last one
            if (context.GetSkillCount() > 2)
            {
                CheckNthOccupationReturnedForAlternateLabelMatch<Skill>(    context.GetSkillCount(),
                                                                            context.GetSkillListData()
                                                                            ).Should().BeTrue();
            }
        }


        public bool CheckNthOccupationReturnedForAlternateLabelMatch<T>(int n, IList<T> ncsData) where T : NcsEntity
        {
            IList<string> stringList = new List<string>();
            // get nth occupation in ncs response
           string uri = ncsData[n - 1].uri;

            // make call to esco api to get alternate labels
            var response = RestHelper.Get( context.GetEscoApiBaseUrl() + "/resource/" + ncsData[0].GetType().Name.ToLower() + "? language=en&uri=" + uri );

            // confirm response was ok
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // parse the response data as json
            JObject escoResults = JObject.Parse(response.Content);

            //extract the data that we are interested in to a list
            IList<JToken> results = escoResults["alternativeLabel"]["en"].Children().ToList();

            //ntext.ClearStringList();
            Dictionary<string, string> escoAlternativeReferences = new Dictionary<string, string>();

            //convert to a list of strings and store in test context
            foreach (JToken result in results)
            {
                string value = result.ToObject<string>();
                stringList.Add(value);
                escoAlternativeReferences.Add(value, "");
            }

            //convert to key only dictionary
            var ncsAlternateLabels = ncsData[n - 1].alternativeLabels.ToDictionary(x => x, x => "");

            // confirm match with ncs api response data
            return AreEqual( escoAlternativeReferences, ncsAlternateLabels );
        }

        [Then(@"the number of results returned matches the expected value")]
        public void ThenTheNumberOfResultsReturnedMatchesTheExpectedValue()
        {
            context.GetSkillListData().Count.Should().Be(context.GetExpectedRecordCount());
        }

        [Then(@"the response json matches:")]
        public void ThenTheResponseJsonMatches(string multilineText)
        {
            JsonHelper.CompareJsonString(multilineText, (string)context["responseBody"]).Should().BeTrue();

        }

        [Then(@"the response json has collection ""(.*)"" with an item matching")]
        public void ThenTheResponseJsonHasCollectionWithAnItemMatching(string p0, string multilineText)
        {
            bool bMatch = false;
            dynamic responseJson = JsonConvert.DeserializeObject<dynamic>((string)context["responseBody"]);
            dynamic includedCollection = responseJson[p0];
            foreach ( var item in includedCollection)
            {
               string json = Newtonsoft.Json.JsonConvert.SerializeObject(item); 
                bMatch = JsonHelper.CompareJsonString(json, multilineText);
                if (bMatch) break;
            }
            bMatch.Should().BeTrue();
        }


        [Then(@"the response json with element ""(.*)"" removed matches:")]
        public void ThenTheResponseJsonWithElementRemovedMatches(string p0, string multilineText)
        {
            string response = (string)context["responseBody"];
            string strippedResonse = JsonHelper.RemovePropertyFromJsonString(response, p0);
            JsonHelper.CompareJsonString(multilineText, strippedResonse).Should().BeTrue();
        }

        [Then(@"the response json with elements ""(.*)"" and ""(.*)"" removed matches:")]
        public void ThenTheResponseJsonWithElementsAndRemovedMatches(string p0, string p1, string multilineText)
        {
            string response = (string)context["responseBody"];
            string strippedResonse = JsonHelper.RemovePropertyFromJsonString(response, p0);
            strippedResonse = JsonHelper.RemovePropertyFromJsonString(strippedResonse, p1);
            JsonHelper.CompareJsonString(multilineText, strippedResonse).Should().BeTrue();

        }

        [Then(@"the element ""(.*)"" in the collection ""(.*)"" has distinct values")]
        public void ThenTheElementInTheCollectionHasDistinctValues(string p0, string p1)
        {
            Dictionary<string, string> distinctValues = new Dictionary<string, string>();
            string response = (string)context["responseBody"];
            var collection = JsonHelper.GetCollectionPropertyFromJson(response, p1);
            
            foreach ( var item in collection)
            {
                try
                {
                    distinctValues.Add((string)item[p0], "OK");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error checking distinct values in collection:{0}", e.Message);
                }
                
            }
            distinctValues.Count.Should().Be(JsonHelper.GetDocumentCountInCollection(response, p1));
        }


        [Then(@"the count of collection ""(.*)"" is (.*)")]
        public void ThenTheCountOfCollectionIs(string p0, int p1)
        {
            string response = (string)context["responseBody"];
            JsonHelper.GetDocumentCountInCollection(response, p0).Should().Be(p1);
        }




        [Then(@"the response value for ""(.*)"" is an empty array")]
        public void ThenTheValueForIsAnEmptyArray(string p0)
        {
            Occupation returnedOccupation = JsonConvert.DeserializeObject<Occupation>((string)context["responseBody"]);
        }

        [Then(@"the response body includes the text:")]
        public void ThenTheResponseBodyIncludesTheText(string multilineText)
        {
            string response = (string)context["responseBody"];
            bool check = response.Contains(multilineText);
            check.Should().BeTrue();
        }


        [Then(@"the response code is (.*)")]
        public void ThenTheResponseCodeIs(int p0)
        {
            context["responseStatus"].Should().Be(p0);
        }

        [Then(@"the the response message is (.*)")]
        public void ThenTheTheResponseMessageIs(string p0)
        {
            context["responseBody"].Should().Be(p0);
         }


    }
}
