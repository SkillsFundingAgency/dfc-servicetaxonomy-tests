using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class DigitalSkills
    {
        private ScenarioContext _scenarioContext;
        public DigitalSkills(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#TitlePart_Title"));
        IWebElement fldDescription => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#Digitalskills_Description_Text"));

        public void EnterTitle(string contentItemInitials)
        {
            fldTitle.SendKeys("Test_Auto_" + contentItemInitials + "_" + RandomStringGenerator.RandomString());
        }

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }
    }
}
