using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class ApprenticeshipRequirements
    {
        private ScenarioContext _scenarioContext;
        public ApprenticeshipRequirements(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("UniqueTitlePart_Title"));
        IWebElement fldDescription => _scenarioContext.GetWebDriver().FindElement(By.ClassName("trumbowyg-editor"));

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }
    }
}
