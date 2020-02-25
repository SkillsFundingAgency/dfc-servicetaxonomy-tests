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

        [Then(@"The output for each API matches for all job profiles")]
        public void ThenTheOutputForEachAPIMatchesForAllJobProfiles()
        {
            List<JobProfileSummary> allJobProfiles = (List<JobProfileSummary>)context["AllJobProfiles"];

            foreach ( var jobProfile in allJobProfiles)
            {
                //  get source job profile data

                var responseSourceData = RestHelper.Get(jobProfile.url, context.GetJobProfileApiHeaders());
                //  get test subject job profile data


                // compare data

            }



        }

    }
}
