using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class ContentTab
    {
        private ScenarioContext _scenarioContext;
        public ContentTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement tabContent => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".nav-tabs li:nth-of-type(7) > a"));
        IWebElement dropdownChangeFrequency => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedlocations_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownPriority => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedlocations_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedSkills => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedlocations_ContentItemIds + div > .multiselect__tags"));

        public void DisplayContent()
        {
            Utilities.Hover(_scenarioContext.GetWebDriver(), tabContent);
            tabContent.Click();
        }

        public void TickUntick(string tickBox)
        {
            switch(tickBox)
            {
                case "Override sitemap configuration":
                    _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='SitemapPart_OverrideSitemapConfig']")).Click();
                    break;
                case "Exclude":
                    _scenarioContext.GetWebDriver().FindElement(By.Id("SitemapPart_Exclude")).Click();
                    break;
            }
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "Change Frequency":
                    Utilities.SelectFromDropdown(dropdownChangeFrequency, option);
                    break;
                case "Priority":
                    Utilities.SelectFromDropdown(dropdownPriority, option);
                    break;
                case "Related skills":
                    dropdownRelatedSkills.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedskills_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
            }
        }

    }
}
