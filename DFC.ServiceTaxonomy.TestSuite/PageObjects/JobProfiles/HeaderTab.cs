using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class HeaderTab
    {
        private ScenarioContext _scenarioContext;
        public HeaderTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }
        IWebElement fldAlternativeTitle => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownHiddenAlternativeTitle => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement fldHiddenContentTitle => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement fldOverview => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement fldSalaryStarter => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement fldSalaryExperienced => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement fldMinimumHours => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement fldMaximumHours => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownWorkingHoursDetails => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownWorkingPattern => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownWorkingPatternDetails => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
    }
}
