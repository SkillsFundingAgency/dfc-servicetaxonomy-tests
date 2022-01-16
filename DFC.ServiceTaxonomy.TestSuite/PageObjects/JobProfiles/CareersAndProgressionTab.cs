using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class CareersAndProgressionTab
    {
        private ScenarioContext _scenarioContext;
        public CareersAndProgressionTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement tabCareerPathAndProgression => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".nav-tabs li:nth-of-type(6) > a"));
        IWebElement txtfldCareerPathAndProgression => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Careerpathandprogression_Html'] + div > .trumbowyg-editor"));

        public void DisplayCareerPathAndProgression()
        {
            Utilities.Hover(_scenarioContext.GetWebDriver(), tabCareerPathAndProgression);
            tabCareerPathAndProgression.Click();
        }

        public void TextEntry(string textToEnter, string field)
        {
            switch (field)
            {
                case "Career path and progression":
                    txtfldCareerPathAndProgression.SendKeys(textToEnter);
                    break;
            }
        }
    }
}
