using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class JobProfileSpecialism
    {
        private ScenarioContext _scenarioContext;
        public JobProfileSpecialism(ScenarioContext context) 
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("UniqueTitlePart_Title"));
        IWebElement fldDescription => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfileSpecialism_Description_Text"));
        IWebElement btnSaveDraftAndContinue => _scenarioContext.GetWebDriver().FindElement(By.ClassName("draft-continue"));
        IWebElement btnPublishAndContinue => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".btn.btn-success.publish"));

        public void EnterTitle(string contentItemInitials)
        {
            fldTitle.SendKeys("Test_Auto_" + contentItemInitials + "_" + RandomStringGenerator.RandomString());
        }

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }

        public void ClickSaveDraftAndContinue()
        {
            btnSaveDraftAndContinue.Click();
        }

        public void ClickPublishAndContinue()
        {
            btnPublishAndContinue.Click();
        }
    }
}
