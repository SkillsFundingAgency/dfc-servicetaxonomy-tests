using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
        IWebElement dropdownWorkingHoursDetails => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_WorkingHoursDetails_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownWorkingPattern => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_WorkingPattern_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownWorkingPatternDetails => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_WorkingPatternDetails_ContentItemIds + div > .multiselect__tags"));

        public void DisplayHeaderTab()
        {
            Utilities.Hover(_scenarioContext.GetWebDriver(), tabHeader);
            tabHeader.Click();
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "Hidden alternative title":
                    dropdownHiddenAlternativeTitle.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_HiddenAlternativeTitle_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]")).Click();
                    break;
                case "Working hours details":
                    dropdownWorkingHoursDetails.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_WorkingHoursDetails_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]")).Click();
                    break;
                case "Working pattern":
                    dropdownWorkingPattern.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_WorkingPattern_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]")).Click();
                    break;
                case "Working pattern details":
                    dropdownWorkingPatternDetails.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_WorkingPatternDetails_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]")).Click();
                    break;
            }
        }

        public void TextEntry(string textToEnter, string field)
        {
            switch (field)
            {
                case "Alternative title":
                    Utilities.Wait(_scenarioContext.GetWebDriver(), fldAlternativeTitle);
                    fldAlternativeTitle.SendKeys(textToEnter);
                    break;
                case "Widget content title":
                    fldWidgetContentTitle.SendKeys(textToEnter);
                    break;
                case "Overview":
                    fldOverview.SendKeys(textToEnter);
                    break;
                case "Salary starter per year":
                    fldSalaryStarter.SendKeys(textToEnter);
                    break;
                case "Salary experienced per year":
                    fldSalaryExperienced.SendKeys(textToEnter);
                    break;
                case "Minimum hours":
                    fldMinimumHours.SendKeys(textToEnter);
                    break;
                case "Maximum hours":
                    fldMaximumHours.SendKeys(textToEnter);
                    break;
            }
        }
    }
}
