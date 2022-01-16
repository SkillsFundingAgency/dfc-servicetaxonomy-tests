using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class WhatItTakesTab
    {
        private ScenarioContext _scenarioContext;
        public WhatItTakesTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement tabWhatItTakes => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".nav-tabs li:nth-of-type(4) > a"));
        IWebElement dropdownRelatedRestrictions => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedrestrictions_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtfldOtherRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Otherrequirements_Html'] + div > .trumbowyg-editor"));
        IWebElement dropdownDigitalSkills => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Digitalskills_ContentItemIds + div > .multiselect__tags"));

        public void DisplayWhatItTakesTab()
        {
            Utilities.Hover(_scenarioContext.GetWebDriver(), tabWhatItTakes);
            tabWhatItTakes.Click();
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "Related restrictions":
                    dropdownRelatedRestrictions.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedrestrictions_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Digital skills":
                    dropdownDigitalSkills.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Digitalskills_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
            }
        }

        public void TextEntry(string textToEnter, string field)
        {
            switch (field)
            {
                case "Other requirements":
                    txtfldOtherRequirements.SendKeys(textToEnter);
                    break;
            }
        }

    }

}
