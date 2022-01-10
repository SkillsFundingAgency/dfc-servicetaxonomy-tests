using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using DFC.ServiceTaxonomy.TestSuite.Extensions;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class SideNavigator
    {
        private ScenarioContext _scenarioContext;
        public SideNavigator(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement linkNew => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#new"));
        IWebElement linkJobProfileSpecialism => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Job profile specialism')]"));
        IWebElement linkJobProfileCategory => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Job profile category')]"));

        public void ClickSideNavNew()
        {
            linkNew.Click();
        }

        public void ClickJobProfileSpecialism()
        {
            linkJobProfileSpecialism.Click();
        }

        public void ClickJobProfileCategory()
        {
            linkJobProfileCategory.Click();
        }

    }
}
