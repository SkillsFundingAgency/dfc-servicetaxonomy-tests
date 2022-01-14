using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class HeaderTab
    {
        private ScenarioContext _scenarioContext;
        public HeaderTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }
        IWebElement tabHeader => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".nav-tabs li:nth-of-type(2) > a"));
        IWebElement fldAlternativeTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_AlternativeTitle_Text"));
        IWebElement dropdownHiddenAlternativeTitle => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_HiddenAlternativeTitle_ContentItemIds + div > .multiselect__tags"));
        IWebElement fldWidgetContentTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_WidgetContentTitle_Text"));
        IWebElement fldOverview => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_Overview_Text"));
        IWebElement fldSalaryStarter => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_Salarystarterperyear_Value"));
        IWebElement fldSalaryExperienced => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_Salaryexperiencedperyear_Value"));
        IWebElement fldMinimumHours => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_Minimumhours_Value"));
        IWebElement fldMaximumHours => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_Maximumhours_Value"));
        IWebElement dropdownWorkingHoursDetails => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_WorkingHoursDetails_ContentItemIds+ div > .multiselect__tags"));
        IWebElement dropdownWorkingPattern => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Workingpattern_ContentItemIds+ div > .multiselect__tags"));
        IWebElement dropdownWorkingPatternDetails => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Workingpatterndetails_ContentItemIds + div > .multiselect__tags"));

        public void DisplayHeaderTab()
        {
            tabHeader.Click();
        }

        public void EnterAlternativeTitle(string alternativeTitle)
        {
            fldAlternativeTitle.SendKeys(alternativeTitle); 
        }

        public void SelectHiddenAlternativeTitle(string hiddenAlternativeTitle)
        {
            dropdownHiddenAlternativeTitle.Click();
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_HiddenAlternativeTitle_ContentItemIds']//following-sibling::div/div[3]//li[" + hiddenAlternativeTitle + "]")).Click();
        }

        public void EntertWidgetContentTitle(string widgetContentTitle)
        {
            fldWidgetContentTitle.SendKeys(widgetContentTitle);
        }

        public void EnterOverview(string overview)
        {
            fldOverview.SendKeys(overview);
        }

        public void EnterSalaryStarter(string salaryStarter)
        {
            fldSalaryStarter.SendKeys(salaryStarter);
        }
        public void EnterSalaryExperienced(string salaryExperienced)
        {
            fldSalaryExperienced.SendKeys(salaryExperienced);
        }

        public void EnterMinimumHours(string minimumHours)
        {
            fldMinimumHours.SendKeys(minimumHours);
        }

        public void EnterMaximumHours(string maximumHours)
        {
            fldMaximumHours.SendKeys(maximumHours);
        }

        public void SelectWorkingHoursDetails(string workingHoursDetails)
        {
            dropdownWorkingHoursDetails.Click();
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_WorkingHoursDetails_ContentItemIds']//following-sibling::div/div[3]//li[" + workingHoursDetails + "]")).Click();
        }

        public void SelectWorkingPattern(string workingPattern)
        {
            dropdownWorkingPattern.Click();
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Workingpattern_ContentItemIds']//following-sibling::div/div[3]//li[" + workingPattern + "]")).Click();
        }

        public void SelecetWorkingPatternDetails(string workingPatternDetails)
        {
            dropdownWorkingPatternDetails.Click();
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Workingpatterndetails_ContentItemIds']//following-sibling::div/div[3]//li[" + workingPatternDetails + "]")).Click();
        }
    }
}
