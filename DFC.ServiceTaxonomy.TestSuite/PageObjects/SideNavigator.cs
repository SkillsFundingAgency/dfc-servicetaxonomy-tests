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
        IWebElement linkSocCode => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'SOC code')]"));
        IWebElement linkWorkingHoursDetail => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Working hours detail')]"));
        IWebElement linkWorkingPatternDetail => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Working pattern detail')]"));
        IWebElement linkWorkingPatterns => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Working patterns')]"));
        IWebElement linkUniversityEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'University entry requirements')]"));
        IWebElement linkUniversityRequirements => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'University requirements')]"));
        IWebElement linkUniversityLinks => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'University link')]"));
        IWebElement linkCollegeEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'College entry requirements')]"));

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

        public void ClickSocCode()
        {
            linkSocCode.Click();
        }

        public void ClickWorkingHoursDetail()
        {
            linkWorkingHoursDetail.Click();
        }

        public void ClickWorkingPatternDetail()
        {
            linkWorkingPatternDetail.Click();
        }

        public void ClickWorkingPatterns()
        {
            linkWorkingPatterns.Click();
        }

        public void ClickUniversityEntryRequirements()
        {
            linkUniversityEntryRequirements.Click();
        }

        public void ClickUniversityRequirements()
        {
            linkUniversityRequirements.Click();
        }

        public void ClickUniversityLinks()
        {
            linkUniversityLinks.Click();
        }

        public void ClickCollegeEntryRequirements()
        {
            linkCollegeEntryRequirements.Click();
        }

    }
}
