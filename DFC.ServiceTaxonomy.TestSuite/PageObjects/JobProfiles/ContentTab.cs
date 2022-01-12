using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class ContentTab
    {
        private ScenarioContext _scenarioContext;
        public ContentTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement txtfldCareerPathAndProgression => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
    }
}
