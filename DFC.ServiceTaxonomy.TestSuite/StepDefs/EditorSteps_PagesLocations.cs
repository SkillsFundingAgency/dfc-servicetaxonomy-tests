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
using System.Threading;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class EditorSteps_PagesLocations
    {
        private AddEditPageLocation _addEditPageLocation;
        private EditPageLocationTaxonomy _editPageLocationTaxonomy;
        
        private readonly ScenarioContext _scenarioContext;

        public EditorSteps_PagesLocations(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _addEditPageLocation = new AddEditPageLocation(_scenarioContext);
            _editPageLocationTaxonomy = new EditPageLocationTaxonomy(_scenarioContext);
        }

        [Given(@"I click to add an new PageLocation under the first item")]
        public void GivenIClickToAddAnNewPageLocationUnderTheFirstItem()
        {
            _editPageLocationTaxonomy.AddPageLocation();
        }

        [Given(@"I click to edit the PageLocation '(.*)'")]
        public void GivenIClickToEditThePageLocation(string p0)
        {
            _editPageLocationTaxonomy.EditPageLocation(p0);
        }
    }
}
