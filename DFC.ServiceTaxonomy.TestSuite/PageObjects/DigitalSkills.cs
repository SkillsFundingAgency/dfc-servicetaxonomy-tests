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

        public static string JobProfileTitle { get; set; }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("TitlePart_Title"));
        IWebElement fldDescription => _scenarioContext.GetWebDriver().FindElement(By.Id("DigitalSkills_Description_Text"));

        public void EnterTitle(string contentItemInitials)
        {
            JobProfileTitle = "Test_Auto_" + contentItemInitials + "_" + RandomStringGenerator.RandomString(8);
            fldTitle.SendKeys(JobProfileTitle);
        }

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }
    }
}
