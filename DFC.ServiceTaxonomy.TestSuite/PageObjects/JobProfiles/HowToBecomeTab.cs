using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class HowToBecomeTab
    {
        private ScenarioContext _scenarioContext;
        public HowToBecomeTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement txtfldEntryRoutes => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldUniversityReleventSubjects => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldUniversityFurtherRouteInfo => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownUniversityEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedUniversityRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedUniversityLinks => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldCollegeRelevantSubjects => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldCollegeFurtherRouteInfo => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownCollegeEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedCollegeRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedCollegeLinks => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldApprenticeshipReleventSubjects => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldApprenticeshipFurtherRouteInfo => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownApprenticeshipEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedApprenticeshipRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedApprenticeshipLinks => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldWork => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldVolunteering => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldDirectApplication => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldOtherRoutes => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement dropdownRelatedRegistrations => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldCareerTips => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldProfessionslAndIndustryBodies => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement txtfldFurterInformation => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));
        IWebElement xxx => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(""));

    }
}
