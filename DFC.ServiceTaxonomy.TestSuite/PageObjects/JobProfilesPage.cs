using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class JobProfilesPage
    {
        private ScenarioContext _scenarioContext;
        public JobProfilesPage(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement btnPublishAndContinue => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("button[value='submit.PublishAndContinue']"));
        IWebElement btnPublishAndContinueArrow => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("button[value='submit.PublishAndContinue'] + button"));
        IWebElement btnPublishAndExit => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("button[value='submit.PublishAndContinue'] + button + div > button"));
        IWebElement btnSaveDraftAndContinue => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".draft-continue"));
        IWebElement btnClone => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement btnDiscardDraft => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement btnDelete => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));

        public void PublishAndContinue()
        {
            btnPublishAndContinue.Click();
        }

        public void PublishAndExit()
        {
            btnPublishAndContinueArrow.Click();
            btnPublishAndExit.Click();
        }

        public void ClickSaveDraftAndContinue()
        {
            btnSaveDraftAndContinue.Click();
        }
    }
}
