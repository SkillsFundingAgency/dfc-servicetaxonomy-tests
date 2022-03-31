using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using System.Threading;
using DFC.ServiceTaxonomy.TestSuite.Helpers;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class SideNavigator
    {
        private ScenarioContext _scenarioContext;
        public SideNavigator(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement linkNew => _scenarioContext.GetWebDriver().FindElement(By.Id("new"));
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
        IWebElement linkCollegeRequirements => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'College requirements')]"));
        IWebElement linkCollegeLink => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'College link')]"));
        IWebElement linkApprenticeshipEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Apprenticeship entry requirements')]"));
        IWebElement linkApprenticeshipRequirements => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Apprenticeship requirements')]"));
        IWebElement linkApprenticeshipLink => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Apprenticeship link')]"));
        IWebElement linkRegistration => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Registration')]"));
        IWebElement linkRestriction => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Restriction')]"));
        IWebElement linkDigitalSkills => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Digital skills')]"));
        IWebElement linkLocation => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Location')]"));
        IWebElement linkEnvironment => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Environment')]"));
        IWebElement linkUniform => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Uniform')]"));
        IWebElement linkJobProfile => _scenarioContext.GetWebDriver().FindElement(By.XPath("//span[contains(text(),'Job profile')]"));
        IWebElement linkContent => _scenarioContext.GetWebDriver().FindElement(By.Id("content"));
        IWebElement linkContentItem => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("span[title='Content Items'] + span"));

        public void ClickSideNavNew()
        {
            linkNew.Click();
        }

        public void ClickJobProfileSpecialism()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Job profile specialism')]"));
            linkJobProfileSpecialism.Click();
        }

        public void ClickJobProfileCategory()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Job profile category')]"));
            linkJobProfileCategory.Click();
        }

        public void ClickSocCode()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'SOC code')]"));
            linkSocCode.Click();
        }

        public void ClickWorkingHoursDetail()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Working hours detail')]"));
            linkWorkingHoursDetail.Click();
        }

        public void ClickWorkingPatternDetail()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Working pattern detail')]"));
            linkWorkingPatternDetail.Click();
        }

        public void ClickWorkingPatterns()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Working patterns')]"));
            linkWorkingPatterns.Click();
        }

        public void ClickUniversityEntryRequirements()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'University entry requirements')]"));
            linkUniversityEntryRequirements.Click();
        }

        public void ClickUniversityRequirements()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'University requirements')]"));
            linkUniversityRequirements.Click();
        }

        public void ClickUniversityLinks()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'University link')]"));
            linkUniversityLinks.Click();
        }

        public void ClickCollegeEntryRequirements()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'College entry requirements')]"));
            linkCollegeEntryRequirements.Click();
        }

        public void ClickCollegeRequirements()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'College requirements')]"));
            linkCollegeRequirements.Click();
        }

        public void ClickCollegeLink()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'College link')]"));
            linkCollegeLink.Click();
        }

        public void ClicklinkApprenticeshipEntryRequirements()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Apprenticeship entry requirements')]"));
            linkApprenticeshipEntryRequirements.Click();
        }

        public void ClicklinkApprenticeshipRequirements()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Apprenticeship requirements')]"));
            linkApprenticeshipRequirements.Click();
        }

        public void ClickApprenticeshipLink()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Apprenticeship link')]"));
            linkApprenticeshipLink.Click();
        }

        public void ClickRegistration()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Registration')]"));
            linkRegistration.Click();
        }

        public void ClickRestriction()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Restriction')]"));
            linkRestriction.Click();
        }

        public void ClickDigitalSkills()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Digital skills')]"));
            linkDigitalSkills.Click();
        }

        public void ClickLocation()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Location')]"));
            linkLocation.Click();
        }

        public void ClickEnvironment()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Environment')]"));
            linkEnvironment.Click();
        }

        public void ClickUniform()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Uniform')]"));
            linkUniform.Click();
        }

        public void ClickJobProfile()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Job profile')]"));
            linkJobProfile.Click();
        }

        public void ClickContent()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("(//span[@class = 'icon' and @title = 'Audit Trail'])[1]//following-sibling::span[contains(text(),'Audit Trail')]"));
            linkContent.Click();
        }

        public void ClickContentItem()
        {
            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("(//span[@class = 'icon' and @title = 'Audit Trail'])[1]//following-sibling::span[contains(text(),'Audit Trail')]"));
            linkContentItem.Click();
        }

    }
}
