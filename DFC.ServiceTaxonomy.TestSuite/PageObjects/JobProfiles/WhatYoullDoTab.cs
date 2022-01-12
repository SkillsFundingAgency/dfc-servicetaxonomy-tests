using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class WhatYoullDoTab
    {
        private ScenarioContext _scenarioContext;
        public WhatYoullDoTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement txtfldDayToDayTasks => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedLocations => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedEnvironments => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedUniforms => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
    }
}
