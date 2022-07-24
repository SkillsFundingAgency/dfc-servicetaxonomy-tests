using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class SocCode
    {
        private ScenarioContext _scenarioContext;
        public SocCode(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("UniqueTitlePart_Title"));
        IWebElement fldDescription => _scenarioContext.GetWebDriver().FindElement(By.Id("SOCCode_Description_Text"));
        IWebElement fldOnetOccupationCode => _scenarioContext.GetWebDriver().FindElement(By.Id("SOCCode_OnetOccupationCode_Text"));
        IWebElement dropApprenticeshipStandards => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#SOCCode_ApprenticeshipStandards_ContentItemIds + div > .multiselect__tags"));
        IWebElement fldSoc2020 => _scenarioContext.GetWebDriver().FindElement(By.Id("SOCCode_SOC2020_Text"));
        IWebElement fldSoc2020extension => _scenarioContext.GetWebDriver().FindElement(By.Id("SOCCode_SOC2020extension_Text"));

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }

        public void EnterOnetOccupationCode(string onetOccupationCode)
        {
            fldOnetOccupationCode.SendKeys(onetOccupationCode);
        }

        public void SelectApprenticeshipStandards(string option)
        {
            dropApprenticeshipStandards.Click();
            //_scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_JobProfileSpecialism_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]")).Click();
            _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='SOCCode_ApprenticeshipStandards_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
        }

        public void EnterSoc2020(string soc2020)
        {
            fldSoc2020.SendKeys(soc2020);
        }

        public void EnterSoc2020extension(string soc2020extension)
        {
            fldSoc2020extension.SendKeys(soc2020extension);
        }
    }
}
