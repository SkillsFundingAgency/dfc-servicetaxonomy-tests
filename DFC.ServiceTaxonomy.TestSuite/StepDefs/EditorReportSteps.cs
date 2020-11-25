using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{

    [Binding]
    public class EditorReportSteps
    {
        ScenarioContext _scenarioContext;
        private ValidatedAndRepair _validateAndRepair;

        public EditorReportSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _validateAndRepair = new ValidatedAndRepair(scenarioContext);
        }

        [Given(@"I run the sync check")]
        public void GivenIRunTheSyncCheck()
        {
            bool succesfulAttempt = false;
            int tries = 0;
            int maxTries = 5;

            while (!succesfulAttempt && tries++ < maxTries)
            {
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(_scenarioContext.GetEnv().editorBaseUrl + "/Admin/DFC.ServiceTaxonomy.GraphSync/GraphSync/TriggerSyncValidation?scope=ModifiedSinceLastValidation");
                succesfulAttempt = !_validateAndRepair.CheckIfAlreadyRunning();
                if (!succesfulAttempt)
                    Thread.Sleep(500);
            }

            _validateAndRepair.CheckForSuccess().Should().BeTrue(); 
        }

        [Given(@"the sync completes succesfully")]
        public void GivenTheSyncCompletesSuccesfully()
        {
            bool success = _validateAndRepair.CheckForSuccess();
        }

        [Then(@"the document ""(.*)"" appears in the ""(.*)"" and ""(.*)"" section")]
        public void ThenTheDocumentAppearsInTheAndSection(string p0, string p1, string p2)
        {
            bool success = _validateAndRepair.FindRecordInSection(p1, p2, p0);
            if (!success)
            {
                Console.WriteLine("Didn't find item");
            }
            success.Should().BeTrue($"Because document {p0} should appear in the report section: {p2}.{p0}");
        }
    }
}
