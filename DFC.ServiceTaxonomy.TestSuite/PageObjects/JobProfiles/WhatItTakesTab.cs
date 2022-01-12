using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class WhatItTakesTab
    {
        private ScenarioContext _scenarioContext;
        public WhatItTakesTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement dropdownRelatedRestrictions => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldOtherRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownDigitalSkills => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
    }

}
