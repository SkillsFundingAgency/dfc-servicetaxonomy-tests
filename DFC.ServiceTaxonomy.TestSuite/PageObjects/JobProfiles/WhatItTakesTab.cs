
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;

using OpenQA.Selenium;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

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

        IWebElement tabWhatItTakes => _driver.WaitUntilElementFound(By.LinkText("What it takes"));
        IWebElement dropdownRelatedRestrictions => _driver.FindElement(By.CssSelector("#JobProfile_Relatedrestrictions_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtfldOtherRequirements => _driver.FindElement(By.CssSelector("label[for='JobProfile_Otherrequirements_Html'] + div > .trumbowyg-editor"));
        IWebElement dropdownDigitalSkills => _driver.FindElement(By.CssSelector("#JobProfile_DigitalSkills_ContentItemIds + div > .multiselect__tags"));

        IWebElement dropdownRelatedSkills => _driver.FindElement(By.CssSelector("#JobProfile_Relatedskills_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtRelatedSkills => _driver.WaitUntilElementFound(By.CssSelector("#JobProfile_Relatedskills_ContentItemIds + div input"));

        ReadOnlyCollection<IWebElement> btnDeleteRelatedSkills => _driver.FindElements(By.CssSelector("div[data-field='Relatedskills'] ul button.content-picker-default__list-item__delete"));

        public void DisplayWhatItTakesTab()
        {
            //Utilities.Hover(_driver, tabWhatItTakes);
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
                    txtRelatedSkills.SendKeys(option.Split('-')[0]);
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

        public void CheckOrRearrangeSkills(string[] skills)
        {
            Thread.Sleep(500);
            var items = _driver.FindElements(By.CssSelector("div[data-field='Relatedskills'] > div:nth-of-type(1) li span:nth-of-type(1)")).Select(c => c.Text.Trim()).ToArray();
            if (items.SequenceEqual(skills))
            {
                _scenarioContext.Set(true, "Related skills");
                return;
            }

            RemoveSkills();
            foreach (var skill in skills)
            {
                if (!string.IsNullOrWhiteSpace(skill))
                    OptionSelection(skill, "Related skills");
            }
            _scenarioContext.Set(false, "Related skills");
        }

        public bool GetSkillsInOrder()
        {
            return _scenarioContext.GetOrDefault<bool>("Related skills");
        }
    }
}