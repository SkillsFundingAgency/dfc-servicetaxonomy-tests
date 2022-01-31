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
    class ContentTab
    {
        private ScenarioContext _scenarioContext;
        public ContentTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement tabContent => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".nav-tabs li:nth-of-type(7) > a"));
        IWebElement fldComment => _scenarioContext.GetWebDriver().FindElement(By.Id("AuditTrailPart_Comment"));

        public void DisplayContent()
        {
            Utilities.Hover(_scenarioContext.GetWebDriver(), tabContent);
            tabContent.Click();
        }

        public void TickUntick(string tickBox)
        {
            Utilities.Wait(_scenarioContext.GetWebDriver(), fldComment);

            switch (tickBox)
            {
                case "Override sitemap configuration":
                    _scenarioContext.GetWebDriver().FindElement(By.CssSelector("input[data-val-required='The OverrideSitemapConfig field is required.'] + label")).Click();
                    break;
                case "Exclude":
                    _scenarioContext.GetWebDriver().FindElement(By.CssSelector("input[data-val-required='The Exclude field is required.'] + label")).Click();
                    break;
            }
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "Change Frequency":
                    _scenarioContext.GetWebDriver().FindElement(By.Id("SitemapPart_ChangeFrequency")).Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath("//select[@id='SitemapPart_ChangeFrequency']/option[contains(text(), '" + option + "')]")).Click();
                    break;
                case "Priority":
                    _scenarioContext.GetWebDriver().FindElement(By.Id("SitemapPart_Priority")).Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath("//select[@id='SitemapPart_Priority']/option[contains(text(), '" + option + "')]")).Click();
                    break;
            }
        }
         
        public void TextEntry(string textToEnter)
        {
            fldComment.Click();
            _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".tab-content.accordion > div:nth-of-type(7)")).Click();
            fldComment.SendKeys(textToEnter); ;
        }

    }
}
