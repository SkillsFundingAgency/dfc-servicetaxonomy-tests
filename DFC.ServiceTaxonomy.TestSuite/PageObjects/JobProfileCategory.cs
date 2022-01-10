using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class JobProfileCategory
    {
        private ScenarioContext _scenarioContext;
        public JobProfileCategory(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#UniqueTitlePart_Title"));
        IWebElement linkJobProfileSpecialism => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Job profile category')]"));
        IWebElement fldDescription => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#Jobprofilecategory_Description_Text"));

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }
    }
}
