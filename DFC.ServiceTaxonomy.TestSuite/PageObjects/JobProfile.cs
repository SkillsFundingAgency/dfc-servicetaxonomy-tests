using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class JobProfile
    {
        private ScenarioContext _scenarioContext;
        public JobProfile(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#TitlePart_Title"));
        IWebElement dropdownDynamicTitlePrefix => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".multiselect.multiselect--above .multiselect__tags"));
        IWebElement dropdownJobProfileSpecialism => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("div[data-field='Jobprofilespecialism'] .multiselect__tags"));
        IWebElement dropdownJobProfileCatogory => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));

        public void SelectDynamicTitlePrefix(string description)
        {
            dropdownDynamicTitlePrefix.SendKeys("");
        }
    }
}
