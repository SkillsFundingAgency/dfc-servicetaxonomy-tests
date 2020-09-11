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
using AngleSharp.Io;
using AngleSharp.Common;
using System.Text.RegularExpressions;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class ApiSteps
    {
        #region consts
        private const string tokenChar = "@";
        private const string tokenName = "@NAME@";
        private const string cypher_skillWithRelatedJobProfile = "MATCH (s:esco__Skill) --> (o:esco__Occupation) -- (j:JobProfile) RETURN distinct s.uri";
        private const string cypher_AddJobProfileAndRelationToOccupation = "to define";
        private const string cypher_occupationWithRelatedJobProfile = "MATCH (o:esco__Occupation) -- (j:JobProfile) RETURN o.uri";
        private string cypher_jobProfileUriFromOccupationName = $"MATCH (o:esco__Occupation) -- (j:JobProfile) WHERE o.skos__prefLabel ='{tokenName}' RETURN  j.uri as uri";
        #endregion


        private readonly ScenarioContext context;

        public ApiSteps(ScenarioContext injectedContext )
        {
            context = injectedContext;
        }

        public string getNth(string str, char splitChar, int n)
        {
            int idx;
            string newString = "";
            var count = 0;
            do
            {
                idx = str.IndexOf(splitChar);
                newString += $"{str.Substring(0, idx)}{(++count < n ? splitChar.ToString() : string.Empty)}";
                str = str.Substring(idx + 1);
            } while (count < n);
            return newString;
        }

        public string addLinksToJson(string json, _DataItem item)
        {
            int count = item.Uri.Count(f => f == '/');
            string curie = getNth(item.Uri, '/', count - 1);
            string id = item.Uri.Substring(item.Uri.LastIndexOf("/")+1);


            JObject linkDetails = new JObject();

            var groups = item.linkedItems.Select(x => x.RelationshipType)
                                         .GroupBy(r => r)
                                         .Select(g => new { Name = g.Key.ToString(), Count = g.Count() })
                                         .OrderBy( o => o.Name);

            if (groups.Count() > 0)
            {
                linkDetails.Add(new JProperty("self", item.Uri));
                linkDetails.Add(new JProperty("curies",
                                    new JArray(
                                        new JObject(
                                            new JProperty("name", "cont"),
                                            new JProperty("href", curie)
                                                   )
                                              )
                                       )
                               );
            }

            foreach ( var group in groups)
            {
                bool asArray = group.Count > 1;
                JContainer groupMembers = linkDetails;
                if (asArray)
                    groupMembers = new JArray();

                foreach (var linkItem in item.linkedItems.Where( x => x.RelationshipType == group.Name).OrderByDescending(x => x.Title))
                {
                    JObject link = new JObject(
                                        new JProperty("href", linkItem.RelatedItem.Uri.Replace(curie, string.Empty)),
                                        new JProperty("title", linkItem.Title),
                                        new JProperty("contentType", linkItem.RelatedItem.TypeName)
                                        );
                    if (asArray)
                    {
                        groupMembers.Add(link);
                    }
                    else
                    {
                        groupMembers.Add(new JProperty($"cont:{linkItem.RelationshipType}", link));
                    }
                    
                }
                if (asArray)
                {
                    linkDetails.Add(new JProperty($"cont:{group.Name}", groupMembers));
                }
            }
            json = JsonHelper.AddPropertyToJsonString(json, "id", id);
            json = JsonHelper.AddPropertyToJsonString(json, "_links", linkDetails);
            return json;
        }


        [Given(@"I define a test type and call it ""(.*)""")]
        public void GivenIDefineATestTypeAndCallIt(string p0)
        {
            context.StoreToken(p0, context.RandomString(10).ToLower());
        }

        private SharedContent InsertSharedContent( string name, Table dataTable, string graph = constants.publish)
        {
            SharedContent newItem = dataTable.CreateInstance<SharedContent>();
            newItem.uri = context.GenerateUri(name, graph);
            String cypher = CypherHelper.GenerateCypher<SharedContent>(newItem, name);

            var response = context.GetGraphConnection(graph).ExecuteTableQuery(cypher, null);

            context.StoreUri(newItem.uri, string.Empty, name, newItem, TeardownOption.Graph);
            context.StoreToken($"__URI{context.GetNumberOfStoredUris()}__", newItem.uri);
            return newItem;
        }

        private void AddRelationship( string uri1, string uri2, string relationshipName, string graph)
        {
            String cypher = CypherHelper.AddRelationship("uri", uri1, uri2, relationshipName);
            var response = context.GetGraphConnection(graph).ExecuteTableQuery(cypher, null);
        }

         [Given(@"I create a shared content item with the following data")]
        public void GivenICreateASharedContentItemWithTheFollowingData(Table table)
        {
            InsertSharedContent("sharedcontent", table);
        }

        [Given(@"I create a ""(.*)"" item in the ""(.*)"" graph with the following data")]
        public void GivenICreateAItemInTheGraphWithTheFollowingData(string type, string graph, Table dataTable)
        {
            graph = graph.ToLower();
            graph.Should().BeOneOf(new[] { constants.publish, constants.preview });

            string contentTypeName = context.ReplaceTokensInString(type);
            InsertSharedContent(contentTypeName, dataTable, graph);
        }

        //[Given(@"I publish a ""(.*)"" item with the following values")]
        //public void GivenIPublishAItemWithTheFollowingValues(string p0, Table table)
        //{
        //    string contentTypeName = context.ReplaceTokensInString(p0);
        //    ScenarioContext.Current.Pending();
        //}



        //[Given(@"I create an item of ""(.*)"" related by ""(.*)"" with the following data")]
        //public void GivenICreateAnItemOfRelatedByWithTheFollowingData(string p0, string p1, Table table)
        //{
        //    string contentTypeName = context.ReplaceTokensInString(p0);
        //    InsertSharedContent(contentTypeName, table);

        //    AddRelationship(context.GetUri(context.GetNumberOfStoredUris() - 2), context.GetLatestUri(), p1 );
        //}

        [Given(@"I create an item of ""(.*)"" in the ""(.*)"" graph related by ""(.*)"" to item (.*) with the following data")]
        public void GivenICreateAnItemOfInTheGraphRelatedByToItemWithTheFollowingData(string type, string graph, string relationship, int itemRef, Table dataTable)
        {
            // assume non zero based index is supplied
            string contentTypeName = context.ReplaceTokensInString(type);
            var item = InsertSharedContent(contentTypeName, dataTable, graph);

            _DataItem parentItem = context.GetDataItems()[itemRef - 1];

            AddRelationship(context.GetUri(itemRef - 1), context.GetLatestUri(), relationship, graph);
            context.RelateDataItems(itemRef - 1, context.GetNumberOfStoredUris() - 1, item.Title, relationship);
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

        [Given(@"I want to supply an invalid security header")]
        public void GivenIWantToSupplyAnInvalidSecurityHeader()
        {
            context[constants.securityHeader] = new Dictionary<string, string> () { { "Ocp-Apim-Subscription-Key", "12345" } };
        }

        [Given(@"I want to fail to send a security header")]
        public void GivenIWantToFailToSendASecurityHeader()
        {
            context[constants.securityHeader] = new Dictionary<string, string>() ;
        }

        [Given(@"I want to supply ""(.*)"" as a parameter in the following request")]
        public void GivenIWantToSupplyAsAParameterInTheFollowingRequest(string p0)
        {
            context[constants.requestParam] = p0;
        }

        [Given(@"I make a request to the service taxonomy API ""(.*)""")]
        public void GivenIMakeARequestToTheServiceTaxonomyAPI(string p0, Table table)
        {
            string requestBody = "{}";
            string param = (context.ContainsKey(constants.requestParam) ? context[constants.requestParam].ToString() : "");
            var requestItems = table.SingleColumnToDictionary();
            foreach ( var item in requestItems )
            {
               requestBody = JsonHelper.AddPropertyToJsonString(requestBody, item.Key, item.Value);
            }
            var response = RestHelper.Post(context.GetTaxonomyUri(p0,param), requestBody, context.GetTaxonomyApiHeaders());
            //response.StatusCode.Should().Be(HttpStatusCode.OK);
            context[constants.responseStatus] = response.StatusCode;
            context[constants.responseContent] = response.Content;
        }

        [Given(@"I make a request to the service taxonomy API ""(.*)"" with request body")]
        public void GivenIMakeARequestToTheServiceTaxonomyAPIWithRequestBody(string p0, string multilineText)
        {
            string param = (context.ContainsKey(constants.requestParam) ? context[constants.requestParam].ToString() : "");
            var response = RestHelper.Post(context.GetTaxonomyUri(p0,param), multilineText, context.GetTaxonomyApiHeaders());
            context[constants.responseStatus] = response.StatusCode;
            context[constants.responseContent] = response.Content;
        }

        [Given(@"I make a request to the content API")]
        public void GivenIMakeARequestToTheContentAPI()
        {
            string uri = context.GetLatestUri();
            var response = RestHelper.Get(uri, context.GetTaxonomyApiHeaders());
            context[constants.responseStatus] = response.StatusCode;
            context[constants.responseContent] = response.Content;
            context[constants.responseScope] = constants.resultSingle;
        }

        [Given(@"I make a request to the ""(.*)"" content API to retrive all ""(.*)"" items")]
        public void GivenIMakeARequestToTheContentAPIToRetriveAllItems(string graph, string type)
        {
            graph = graph.ToLower();
            graph.Should().BeOneOf(new[] { constants.publish, constants.preview });

            string uri = (graph == constants.publish) ? context.GetContentUri(context.ReplaceTokensInString(type)) : 
                                                        context.GetDraftContentUri(context.ReplaceTokensInString(type)) ;
            var response = RestHelper.Get(uri, context.GetContentApiHeaders());
            context[constants.responseStatus] = response.StatusCode;
            context[constants.responseContent] = response.Content;
            context[constants.responseScope] = constants.resultSummary;
        }


        [Given(@"I make a request to the content API to retrive all ""(.*)"" items")]
        public void GivenIMakeARequestToTheContentAPIToRetriveAllItems(string p0)
        {
            string uri = context.GetContentUri(context.ReplaceTokensInString(p0));
            var response = RestHelper.Get(uri,context.GetContentApiHeaders());
            context[constants.responseStatus] = response.StatusCode;
            context[constants.responseContent] = response.Content;
            context[constants.responseScope] = constants.resultSummary;
        }

        [Given(@"I make a request to the ""(.*)"" content API to retrive item (.*)")]
        public void GivenIMakeARequestToTheContentAPIToRetriveItem(string graph, int itemRef)
        {
            graph = graph.ToLower();
            graph.Should().BeOneOf(new[] { constants.publish, constants.preview });

            string uri = (graph == constants.publish ) ? context.GetUri(itemRef - 1) :
                                                         context.GetDraftUri(itemRef - 1);
            var response = RestHelper.Get(uri, context.GetContentApiHeaders());
            context[constants.responseStatus] = response.StatusCode;
            context[constants.responseContent] = response.Content;
            context[constants.responseScope] = constants.resultSingle;
        }



        [When(@"I build the expected response for item (.*)")]
        public void WhenIBuildTheExpectedResponseForItem(int p0)
        {
            bool singleResponse = (string)context[constants.responseScope] == constants.resultSingle;
            string json = "";

            if (singleResponse)
            {
                string uri = context.GetUri(p0 - 1);
                _DataItem requestedItem = context.GetDataItems()[p0 - 1];

                json = JsonConvert.SerializeObject(requestedItem.model);

                json = addLinksToJson(json, requestedItem);
            }
            else
            {
                JArray newArray = new JArray();
                string jsonItem = "";
                // assume for now that all data items are of the requested type
                foreach( var item in context.GetDataItems())
                {
                    jsonItem = JsonConvert.SerializeObject(item.model);
                    //TODO remove properties that aren't in expected summary
                    //FORNOW assume it is going to be a sharecontent item and just remove "content"
                    jsonItem = JsonHelper.RemovePropertyFromJsonString(jsonItem,"Content");
                    newArray.Add(new JObject(JObject.Parse(jsonItem) ));
                }
                json = newArray.ToString();
            }
            context["expectedResult"] = json;
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
            Neo4JHelper graphConnection = context.GetGraphConnection(constants.publish);
            int numberOfRecords = graphConnection.GetRecordCount(statementTemplate, null);

            if (numberOfRecords < 1)
            {
                // add a record
                graphConnection.ExecuteTableQuery(cypher_AddJobProfileAndRelationToOccupation, null);
            }

            // check success
            numberOfRecords = graphConnection.GetRecordCount(statementTemplate, null);
            numberOfRecords.Should().BeGreaterThan(0);

            // store in context
            context.SetExpectedRecordCount(numberOfRecords);
        }

        [Given(@"I look up the job profile Uri for ""(.*)""")]
        public void GivenILookUpTheJobProfileUriFor(string p0)
        {
            string uri = "";
            var statementTemplate = cypher_jobProfileUriFromOccupationName.Replace(tokenName, p0);
            try
            {
                uri = context.GetGraphConnection(constants.publish).GetSingleRowAsDictionary(statementTemplate)["uri"];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to look up job profile Uri:\n{e.Message}");
            }
            //todo deal with hardcoded string values?
            context.StoreToken("JobProfileUri", uri);
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

        [Then(@"the response matches the created item")]
        public void ThenTheResponseMatchesTheCreatedItem()
        {
            var createdItem = context.GetDataItems().Last();
            string responseJson = (string)context[constants.responseContent];
            string itemJson = JsonConvert.SerializeObject(createdItem);
            itemJson = JsonHelper.AddPropertyToJsonString(itemJson,"_links", "[{}]");

            var result = JsonHelper.CompareJsonString(itemJson, responseJson);
            result.Should().BeTrue("Because the data returned should match the created item");
        }

        [Then(@"the response includes all items of type ""(.*)""")]
        public void ThenTheResponseIncludesAllItemsOfType(string p0)
        {
            string responses = "";
            int numberOfItems = context.GetDataItems().Count;
            int itemCount = 0;
            foreach ( var item in context.GetDataItems())
            {
                bool lastItem = ++itemCount == numberOfItems;
                responses += $"{JsonConvert.SerializeObject(item)}{(lastItem ? "" : ",")}";
            }
            string itemJson = $"[{responses}]";
            string responseJson = (string)context[constants.responseContent];

            var result = JsonHelper.CompareJsonString(itemJson, responseJson);
            result.Should().BeTrue("Because the data returned should include all the created items");
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

        [Then(@"the response matches the expectation")]
        public void ThenTheResponseMatchesTheExpectation()
        {
            string message = "";
            string expectedResult = (string)context["expectedResult"];

            bool match = JsonHelper.CompareJsonString(expectedResult, (string)context[constants.responseContent], out message);
            match.Should().BeTrue(message);
        }


        [Then(@"the response json matches:")]
        public void ThenTheResponseJsonMatches(string multilineText)
        {
            // replace any tokens in the expected response
            foreach ( var item in context.GetTokens())
            {
                //TODO standardise token use
                if (item.Key.Contains("__"))
                {
                    multilineText = multilineText.Replace($"{item.Key}", item.Value);
                }
                else
                {
                    multilineText = multilineText.Replace($"{tokenChar}{item.Key}{tokenChar}", item.Value);
                }
            }
            string message = "";
            bool match = JsonHelper.CompareJsonString(multilineText, (string)context[constants.responseContent], out message);
            match.Should().BeTrue(message);

        }


        [Then(@"the response json has collection ""(.*)"" with an item matching")]
        public void ThenTheResponseJsonHasCollectionWithAnItemMatching(string p0, string multilineText)
        {
            bool bMatch = false;
            dynamic responseJson = JsonConvert.DeserializeObject<dynamic>((string)context[constants.responseContent]);
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
            string response = (string)context[constants.responseContent];
            string strippedResonse = JsonHelper.RemovePropertyFromJsonString(response, p0);
            JsonHelper.CompareJsonString(multilineText, strippedResonse).Should().BeTrue();
        }

        [Then(@"the response json with elements ""(.*)"" and ""(.*)"" removed matches:")]
        public void ThenTheResponseJsonWithElementsAndRemovedMatches(string p0, string p1, string multilineText)
        {
            string response = (string)context[constants.responseContent];
            string strippedResonse = JsonHelper.RemovePropertyFromJsonString(response, p0);
            strippedResonse = JsonHelper.RemovePropertyFromJsonString(strippedResonse, p1);
            JsonHelper.CompareJsonString(multilineText, strippedResonse).Should().BeTrue();

        }

        [Then(@"the element ""(.*)"" in the collection ""(.*)"" has distinct values")]
        public void ThenTheElementInTheCollectionHasDistinctValues(string p0, string p1)
        {
            Dictionary<string, string> distinctValues = new Dictionary<string, string>();
            string response = (string)context[constants.responseContent];
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
            string response = (string)context[constants.responseContent];
            JsonHelper.GetDocumentCountInCollection(response, p0).Should().Be(p1);
        }




        [Then(@"the response value for ""(.*)"" is an empty array")]
        public void ThenTheValueForIsAnEmptyArray(string p0)
        {
            Occupation returnedOccupation = JsonConvert.DeserializeObject<Occupation>((string)context[constants.responseContent]);
        }

        [Then(@"the response body includes the text:")]
        public void ThenTheResponseBodyIncludesTheText(string multilineText)
        {
            string response = (string)context[constants.responseContent];
            bool check = response.Contains(multilineText);
            check.Should().BeTrue();
        }


        [Then(@"the response code is (.*)")]
        public void ThenTheResponseCodeIs(int p0)
        {
            context[constants.responseStatus].Should().Be(p0);
        }

        [Then(@"the the response message is (.*)")]
        public void ThenTheTheResponseMessageIs(string p0)
        {
            context[constants.responseContent].Should().Be(p0);
         }


    }
}
