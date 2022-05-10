﻿using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;

using OpenQA.Selenium;

using System.Collections.ObjectModel;

using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class WhatItTakesTab
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public WhatItTakesTab(ScenarioContext context)
        {
            _scenarioContext = context;
            _driver = _scenarioContext.GetWebDriver();
        }

        IWebElement tabWhatItTakes => _driver.FindElement(By.CssSelector(".nav-tabs li:nth-of-type(4) > a"));
        IWebElement dropdownRelatedRestrictions => _driver.FindElement(By.CssSelector("#JobProfile_Relatedrestrictions_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtfldOtherRequirements => _driver.FindElement(By.CssSelector("label[for='JobProfile_Otherrequirements_Html'] + div > .trumbowyg-editor"));
        IWebElement dropdownDigitalSkills => _driver.FindElement(By.CssSelector("#JobProfile_DigitalSkills_ContentItemIds + div > .multiselect__tags"));

        IWebElement dropdownRelatedSkills => _driver.FindElement(By.CssSelector("#JobProfile_Relatedskills_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtRelatedSkills => _driver.WaitUntilElementFound(By.CssSelector("#JobProfile_Relatedskills_ContentItemIds + div input"));

        ReadOnlyCollection<IWebElement> btnDeleteRelatedSkills => _driver.FindElements(By.CssSelector("div[data-field='Relatedskills'] ul button.content-picker-default__list-item__delete"));

        public void DisplayWhatItTakesTab()
        {
            Utilities.Hover(_driver, tabWhatItTakes);
            tabWhatItTakes.Click();
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "Related restrictions":
                    Utilities.Wait(_driver, dropdownRelatedRestrictions);
                    dropdownRelatedRestrictions.Click();
                    _driver.FindElement(By.XPath(".//*[@id='JobProfile_Relatedrestrictions_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Digital skills":
                    dropdownDigitalSkills.Click();
                    _driver.FindElement(By.XPath(".//*[@id='JobProfile_DigitalSkills_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related skills":
                    dropdownRelatedSkills.Click();
                    txtRelatedSkills.SendKeys(option);
                    _driver.WaitUntilElementFound(By.XPath(".//*[@id='JobProfile_Relatedskills_ContentItemIds']//following-sibling::div/div[3]//li['" + option + "']/span/div/span")).Click();
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

        public void RemoveSkills()
        {
            _driver.WaitElementToBeClickable(By.CssSelector("div[data-field='Relatedskills'] ul button.content-picker-default__list-item__delete"));
            if (btnDeleteRelatedSkills?.Count > 0)
                foreach (var btn in btnDeleteRelatedSkills)
                    btn.Click();
        }
    }

}
