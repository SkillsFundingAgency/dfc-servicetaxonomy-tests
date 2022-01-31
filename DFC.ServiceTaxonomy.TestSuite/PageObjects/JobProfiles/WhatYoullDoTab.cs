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
    class WhatYoullDoTab
    {
        private ScenarioContext _scenarioContext;
        public WhatYoullDoTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement tabWhatYoullDo => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".nav-tabs li:nth-of-type(5) > a"));
        IWebElement txtfldDayToDayTasks => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Daytodaytasks_Html'] + div > .trumbowyg-editor"));
        //IWebElement txtfldDayToDayTasks => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_Daytodaytasks_Html"));
        IWebElement dropdownRelatedLocations => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_RelatedLocations_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedEnvironments => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_RelatedEnvironments_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedUniforms => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_RelatedUniforms_ContentItemIds + div > .multiselect__tags"));

        public void DisplayWhatYoullDo()
        {
            Utilities.Hover(_scenarioContext.GetWebDriver(), tabWhatYoullDo);
            tabWhatYoullDo.Click();
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "Related locations":
                    dropdownRelatedLocations.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_RelatedLocations_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related environments":
                    dropdownRelatedEnvironments.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_RelatedEnvironments_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related uniforms":
                    dropdownRelatedUniforms.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_RelatedUniforms_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
            }
        }

        public void TextEntry(string textToEnter, string field)
        {
            switch (field)
            {
                case "Day-to-day tasks":
                    Utilities.Wait(_scenarioContext.GetWebDriver(), dropdownRelatedUniforms);
                    txtfldDayToDayTasks.Click();
                    txtfldDayToDayTasks.SendKeys(textToEnter);
                    break;
            }
        }
    }
}
