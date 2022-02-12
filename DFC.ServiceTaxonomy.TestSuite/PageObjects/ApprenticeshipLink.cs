using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class ApprenticeshipLink
    {
        private readonly ScenarioContext _scenarioContext;
        public ApprenticeshipLink(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement fldTitle => _scenarioContext.GetWebDriver().FindElement(By.Id("UniqueTitlePart_Title"));
        IWebElement fldText => _scenarioContext.GetWebDriver().FindElement(By.Id("ApprenticeshipLink_Text_Text"));
        IWebElement fldUrl => _scenarioContext.GetWebDriver().FindElement(By.Id("ApprenticeshipLink_URL_Text"));

        public void EnterDescription(string description)
        {
            var title = fldTitle.GetAttribute("value");
            fldText.SendKeys(description + title);
        }

        public string GetText()
        {
            return fldText.GetAttribute("value");
        }

        public string GetUrl()
        {
            return fldUrl.GetAttribute("value");
        }
    }
}
