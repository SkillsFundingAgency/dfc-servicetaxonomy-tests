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
        IWebElement fldComment => _scenarioContext.GetWebDriver().FindElement(By.Id("AuditTrailPart_Comment"));

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
                    Utilities.SelectFromDropdown(_scenarioContext.GetWebDriver().FindElement(By.Id("SitemapPart_ChangeFrequency")), option);
                    break;
                case "Priority":
                    Utilities.SelectFromDropdown(_scenarioContext.GetWebDriver().FindElement(By.Id("SitemapPart_Priority")), option);
                    break;
            }
        }

        public void TextEntry(string textToEnter, string field)
        {
            switch (field)
            {
                case "Comment":
                    fldComment.SendKeys(textToEnter); ;
                    break;
            }
        }

    }
}
