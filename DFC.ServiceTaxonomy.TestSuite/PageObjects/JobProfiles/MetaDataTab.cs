using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class MetaDataTab
    {
        private ScenarioContext _scenarioContext;
        public MetaDataTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#TitlePart_Title"));
        IWebElement dropdownDynamicTitlePrefix => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Dynamictitleprefix_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownJobProfileSpecialism => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Jobprofilespecialism_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownJobProfileCategory => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("div[data-field='Jobprofilecategory'] .multiselect__tags"));
        IWebElement fldCourseKeywords => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_Coursekeywords_Text"));
        IWebElement dropdownSocCode => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_SOCcode_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedCareersProfiles => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedcareerprofiles_ContentItemIds + div > .multiselect__tags"));

        

        public void SelectDynamicTitlePrefix(string dynamicTitlePrefix)
        {
            dropdownDynamicTitlePrefix.Click();
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Dynamictitleprefix_ContentItemIds']//following-sibling::div/div[3]//span[contains(text(),'" + dynamicTitlePrefix + "')]")).Click();
        }

        public void SelectJobProfileSpecialism(string jobProfileSpecialism)
        {
            dropdownJobProfileSpecialism.Click();
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilespecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + jobProfileSpecialism + "]")).Click();
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "Job profile specialism":
                    dropdownJobProfileSpecialism.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilespecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]")).Click();
                    Assert.IsNotEmpty(_scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Jobprofilespecialism_ContentItemIds'] + div > div:nth-of-type(1) span:nth-of-type(1)")).Text);
                    break;
                case "Job profile category":
                    dropdownJobProfileCategory.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilecategory_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "SOC code":
                    dropdownSocCode.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_SOCcode_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related careers profiles":
                    dropdownRelatedCareersProfiles.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedcareerprofiles_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
            }
        }

        public void TextEntry(string textToEnter, string field)
        {
            switch(field)
            {
                case "Course keywords":
                    fldCourseKeywords.SendKeys(textToEnter);
                    break;
            }
        }
    }
}
