using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class JobProfiles
    {
        private ScenarioContext _scenarioContext;
        public JobProfiles(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement btnClone => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement btnDiscardDraft => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement btnDelete => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
    }
}
