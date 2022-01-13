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
        IWebElement dropdownSocCode => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Jobprofilecategory_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedCareersProfiles => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedcareerprofiles_ContentItemIds + div > .multiselect__tags"));

        public void SelectDynamicTitlePrefix(string dynamicTitlePrefix)
        {
            dropdownDynamicTitlePrefix.Click();
            Thread.Sleep(750);
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Dynamictitleprefix_ContentItemIds']//following-sibling::div/div[3]//span[contains(text(),'" + dynamicTitlePrefix + "')]")).Click();
        }

        public void SelectJobProfileSpecialism(string jobProfileSpecialism)
        {
            dropdownJobProfileSpecialism.Click();
            //Thread.Sleep(750);
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilespecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + jobProfileSpecialism + "]")).Click();
        }

        public void SelectJobProfileCategory(string jobProfileCategory)
        {
            dropdownJobProfileCategory.Click();
            //Thread.Sleep(750);
            Utilities.Hover(_scenarioContext.GetWebDriver(), _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilespecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + jobProfileCategory + "]/span/div")));
            //_scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilespecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + jobProfileCategory + "]")).Click();
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilespecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + jobProfileCategory + "]/span/div")).Click();
        }

        public void EnterCourseKeywords(string courseKeywords)
        {
            fldCourseKeywords.SendKeys(courseKeywords);
        }

        public void EnterSocCode(string socCode)
        {
            dropdownSocCode.Click();
            //Thread.Sleep(750);
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilespecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + socCode + "]")).Click();
        }

        public void SelectRelatedCareersProfiles(string relatedCareersProfiles)
        {
            dropdownRelatedCareersProfiles.Click();
            Thread.Sleep(750);
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Jobprofilespecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + relatedCareersProfiles + "]")).Click();
        }

    }
}
