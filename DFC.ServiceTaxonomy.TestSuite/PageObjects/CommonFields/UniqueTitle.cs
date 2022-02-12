using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields
{
    public class UniqueTitle
    {
        protected readonly ScenarioContext _scenarioContext;
        public UniqueTitle(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement UniqueTitleField =>
            _scenarioContext.GetWebDriver().FindElement(By.Id("UniqueTitlePart_Title"));

        public void EnterTitle(string text) =>
            UniqueTitleField.SendKeys(text);

        public string GetTitle() =>
            UniqueTitleField.GetAttribute("value");
    }
}
