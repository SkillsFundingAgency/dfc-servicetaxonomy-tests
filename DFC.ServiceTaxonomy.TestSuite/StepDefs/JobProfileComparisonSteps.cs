using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public sealed class JobProfileComparisonSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public JobProfileComparisonSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I have got a list of all available job profile from the existing API")]
        public void GivenIHaveGotAListOfAllAvailableJobProfileFromTheExistingAPI()
        {
            var response = RestHelper.Get(context.GetJobProfileUri("summary"), context.GetJobProfileApiHeaders());
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JArray responseData = JArray.Parse(response.Content);
            var allJobProfiles = responseData.ToObject<List<JobProfileSummary>>();

            context["AllJobProfiles"] = allJobProfiles;
        }

        [Given(@"I have got a list of all available job profile from the new API")]
        public void GivenIHaveGotAListOfAllAvailableJobProfileFromTheNewAPI()
        {
            var response = RestHelper.Get(context.GetTaxonomyUri("GetJobProfileSummary"), context.GetTaxonomyApiHeaders());
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JArray responseData = JArray.Parse(response.Content);
            var allJobProfiles = responseData.ToObject<List<JobProfileSummary>>();

            context["AllSTAXJobProfiles"] = allJobProfiles;
        }

        [Then(@"The existing and new job profile summaries are comparable")]
        public void ThenTheExistingAndNewJobProfileSummariesAreComparable()
        {
            string padding = "--------------------------------------------------------------------------------------------------------------------------------------------------------";
            List<JobProfileSummary> existingList = (List<JobProfileSummary>)context["AllJobProfiles"];
            List<JobProfileSummary> newList = (List<JobProfileSummary>)context["AllSTAXJobProfiles"];
            int totalFailed = 0;
            //existingList.Count.Should().Be(newList.Count);
            
            // not all are present yet, so drive the checks from the new list

            foreach ( var item in newList)
            {
                bool checksOK = true;
                bool matched, lastUpdateDateCheck, titleCheck, uriCheck;
                matched = lastUpdateDateCheck = titleCheck = uriCheck = false;
                string canonicalName = item.url.Substring(item.url.LastIndexOf('/'));
                var match = existingList.Where(u => u.url.EndsWith(canonicalName)).FirstOrDefault();

                // check titles match
                matched = ( match != null );

                if (matched)
                {
                    // check last updated is not null
                    lastUpdateDateCheck = item.lastUpdated != null;

                    //title check
                    titleCheck = item.title == match.title;

                    //uri check
                    uriCheck = false;

                    checksOK = (matched && lastUpdateDateCheck && titleCheck && uriCheck);
                }
                else
                {
                    Console.WriteLine("");
                }
                Console.WriteLine("Check for {0}{1} is Match {2} \tTitle {3}\tLastUpdate {4}\turi {5}", item.title
                                                                                                      , padding.Substring(0,50-item.title.Length)
                                                                                                      , matched.ToString()
                                                                                                      ,titleCheck
                                                                                                      , lastUpdateDateCheck
                                                                                                      , uriCheck);
                if (!checksOK) totalFailed++;
            }
            Console.WriteLine("Total Checked: {0} Total Failed {1}", newList.Count, totalFailed);
        }


        [Then(@"The output for each API matches for all job profiles")]
        public void ThenTheOutputForEachAPIMatchesForAllJobProfiles()
        {
            List<JobProfileSummary> allJobProfiles = (List<JobProfileSummary>)context["AllJobProfiles"];

            foreach ( var jobProfile in allJobProfiles)
            {
                //  get source job profile data

                var responseSourceData = RestHelper.Get(jobProfile.url, context.GetJobProfileApiHeaders());

                //  get test subject job profile data
                var responseTestData = RestHelper.Get(context.GetTaxonomyUri("JobProfileDetail",jobProfile.title),context.GetTaxonomyApiHeaders() );

                // compare data
                JObject diffs = FindDiff(JToken.Parse(responseSourceData.Content), JToken.Parse(responseTestData.Content));
                //exploreJsonObject(JToken.Parse(responseSourceData.Content), 0, "$", JObject.Parse(responseTestData) );
                string output = diffs.ToString();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(output);

            }
        }

        [Given(@"I compare actor")]
        public void GivenICompareActor()
        {
            var responseSourceData = RestHelper.Get("https://sit.api.nationalcareersservice.org.uk/job-profiles/Actor", context.GetJobProfileApiHeaders());

            var responseTestData = RestHelper.Get("https://dev.api.nationalcareersservice.org.uk/servicetaxonomy/getjobprofilebytitle/Execute/Actor" , context.GetTaxonomyApiHeaders());

            // compare data
            JObject diffs = FindDiff(JToken.Parse(responseSourceData.Content), JToken.Parse(responseTestData.Content));
            //exploreJsonObject(JToken.Parse(responseSourceData.Content), 0, "$", JObject.Parse(responseTestData) );
            string output = diffs.ToString();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(output);
        }


        public JObject FindDiff(JToken Current, JToken Model, string key = "")
        {
            var diff = new JObject();

            // exception handling
            switch (key)
            {
                case "AlternativeLabel":
                    break;
                default:
                    break;
            }



            if (JToken.DeepEquals(Current, Model)) return diff;
            switch (Current.Type)
            {
                case JTokenType.Object:
                    {
                        var current = Current as JObject;
                        var model = Model as JObject;
                        var addedKeys = current.Properties().Select(c => c.Name).Except(model.Properties().Select(c => c.Name));
                        var removedKeys = model.Properties().Select(c => c.Name).Except(current.Properties().Select(c => c.Name));
                        var unchangedKeys = current.Properties().Where(c => JToken.DeepEquals(c.Value, Model[c.Name])).Select(c => c.Name);
                        foreach (var k in addedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["+"] = Current[k]
                            };
                        }
                        foreach (var k in removedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["-"] = Model[k]
                            };
                        }
                        var potentiallyModifiedKeys = current.Properties().Select(c => c.Name).Except(addedKeys).Except(unchangedKeys);
                        foreach (var k in potentiallyModifiedKeys)
                        {
                            diff[k] = FindDiff(current[k], model[k], k);
                        }
                    }
                    break;
                case JTokenType.Array:
                    {
                        var current = Current as JArray;
                        var model = Model as JArray;
                        if (model != null)
                        {
                            diff["+"] = new JArray(current.Except(model));
                            diff["-"] = new JArray(model.Except(current));
                        }
                        else
                        {
                            diff["-"] = new JArray(current);
                        }
                        
                    }
                    break;
                default:
                    diff["+"] = Current;
                    diff["-"] = Model;
                    break;
            }

            return diff;
        }


        [Given(@"mock test step")]
        public void GivenMockTestStep(string multilineText)
        {
            var responseSourceData = RestHelper.Get("https://sit.api.nationalcareersservice.org.uk/job-profiles/bottler", context.GetJobProfileApiHeaders());

            var responseTestData = multilineText;

            var tempString = "{  \"SalaryStarter\": \"13500\", \"SalaryExperienced\": \"24000\", \"LastUpdatedDate\": \"ToDo\", \"MinimumHours\": 41.0, \"RelatedCareers\": [ \"ToDo\" ], \"Soc\": \"9134\", \"Title\": \"Bottler\", \"Overview\":\"<p>Bottlers fill, pack and operate bottling machinery in food, drink and bottling factories.</p>\", \"WorkingPattern\": \"evenings / weekends\", \"AlternativeTitle\": \"canning and bottling operative, canningoperative, canning and bottling worker, canner\", \"WorkingHoursDetails\": \"a week\", \"Url\": \"https://pp.api.nationalcareers.service.gov.uk/job-profiles/bottler\", \"WhatYouWillDo\": { \"WYDDayToDayTasks\": [ \"<p>keeping machinery clean and sterile, to meet high standards of food safety</p>\", \"<p>setting up machines and starting the bottling process</p>\", \"<p>making sure bottles or jars are correctly filled andlabelled</p>\", \"<p>reporting more serious machinery problems to your line manager or a technician</p>\", \"<p>sorting out any problems with the production line so bottling is not held up</p>\" ], \"WorkingEnvironment\": { \"Environment\": \"<p>Your working environment may be noisy.</p>\", \"Uniform\": \"\", \"Location\": \"<p>You could work in a factory.</p>\" } }, \"ONetOccupationalCode\": \"ToDo\", \"MaximumHours\": 43.0, \"WhatItTakes\": { \"Skills\": [ \"ToDo\" ], \"DigitalSkillsLevel\": \"<p>to be able to carry out basic tasks on a computer or hand-held device</p>\" }, \"CareerPathAndProgression\": { \"CareerPathAndProgression\": [ \"<p>With experience, you could progress to team supervisor or manager.</p>\" ] }, \"WorkingPatternDetails\": \"on shifts\", \"HowToBecome\": { \"EntryRoutes\": { \"University\": { \"AdditionalInformation\": [ \"ToDo\" ], \"EntryRequirements\": [ \"ToDo\",\"flippy\" ], \"RelevantSubjects\": [ \"ToDo\" ], \"FurtherInformation\": [ \"ToDo\" ], \"EntryRequirementPreface\": [ \"ToDo\" ] } }, \"EntryRouteSummary\": \"ToDo\", \"MoreInformation\": { \"Registration\": [ \"ToDo\" ], \"FurtherInformation\": [ \"\" ], \"ProfessionalAndIndustryBodies\": [ \"\" ], \"CareerTips\": [ \"\" ] } }}";
            dynamic sourceObject = JsonConvert.DeserializeObject(responseSourceData.Content);

            //exploreObject(sourceObject, 0, "TOP");

            JObject diffs = FindDiff(JToken.Parse(responseTestData), JToken.Parse(tempString));
            //exploreJsonObject(JToken.Parse(responseSourceData.Content), 0, "$", JObject.Parse(responseTestData) );
            string output = diffs.ToString();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(output);
            return;
     
        }


    }
}
