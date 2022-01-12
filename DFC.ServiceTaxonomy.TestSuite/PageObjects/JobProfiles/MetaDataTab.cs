using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
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
        IWebElement dropdownDynamicTitlePrefix => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".multiselect.multiselect--above .multiselect__tags"));
        IWebElement dropdownJobProfileSpecialism => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("div[data-field='Jobprofilespecialism'] .multiselect__tags"));
        IWebElement fldCourseKeywords => _scenarioContext.GetWebDriver().FindElement(By.Id("JobProfile_Coursekeywords_Text"));
        IWebElement dropdownJobProfileCatogory => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Jobprofilecategory_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedCareersProfiles => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedcareerprofiles_ContentItemIds + div > .multiselect__tags"));

        public void SelectDynamicTitlePrefix(string description)
        {
            dropdownDynamicTitlePrefix.SendKeys("");
        }
    }
}
