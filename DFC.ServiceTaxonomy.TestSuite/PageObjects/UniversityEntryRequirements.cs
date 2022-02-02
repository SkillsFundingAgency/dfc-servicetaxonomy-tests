using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class UniversityEntryRequirements
    {
        private ScenarioContext _scenarioContext;
        public UniversityEntryRequirements(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("UniqueTitlePart_Title"));
        IWebElement fldDescription => _scenarioContext.GetWebDriver().FindElement(By.Id("UniversityEntryRequirements_Description_Text"));

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }
    }
}
