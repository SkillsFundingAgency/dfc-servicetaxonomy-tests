using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
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

        ICollection<IWebElement> lstApprenticeshipStandards => _scenarioContext.GetWebDriver().FindElements(
              By.CssSelector("[id^=ContentPicker_SOCCode_ApprenticeshipStandards] li.content-picker-default__list-item"));

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldDescription.SendKeys(description + title);
        }

        public void EnterOnetOccupationCode(string onetOccupationCode)
        {
            fldOnetOccupationCode.SendKeys(onetOccupationCode);
        }

        public string GetTitle()
        {
            return fldTitle.GetAttribute("value");
        }

        public string GetDescription()
        {
            return fldDescription.GetAttribute("value");
        }

        public string GetOnetCode()
        {
            return fldOnetOccupationCode.GetAttribute("value");
        }

        public List<string> GetApprenticeshipStandards()
        {
            return lstApprenticeshipStandards.Select(l => l.Text).ToList();
        }
    }
}
