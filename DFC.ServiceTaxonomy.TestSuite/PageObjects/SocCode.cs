using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class SocCode
    {
        private ScenarioContext _scenarioContext;
        public SocCode(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("UniqueTitlePart_Title"));
        IWebElement fldDescription => _scenarioContext.GetWebDriver().FindElement(By.Id("SOCCode_Description_Text"));
        IWebElement fldOnetOccupationCode => _scenarioContext.GetWebDriver().FindElement(By.Id("SOCCode_OnetOccupationCode_Text"));

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }

        public void EnterOnetOccupationCode(string onetOccupationCode)
        {
            fldOnetOccupationCode.SendKeys(onetOccupationCode);
        }
    }
}
