using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class EditorSteps_Pages
    {
        private AddEditPage _addEditPage;

        private readonly ScenarioContext _scenarioContext;

        public EditorSteps_Pages(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _addEditPage = new AddEditPage(_scenarioContext);
        }


        [Given(@"I select the default page location")]
        public void GivenISelectTheDefaultPageLocation()
        {
            _addEditPage.SetBasePageLocation();
        }

        [Given(@"I add an html item to the page with content")]
        public void GivenIAddAnHtmlItemToThePageWithContent(string htmlValue)
        {
            _addEditPage.AddHtmlItem(htmlValue);
        }
    }
}
