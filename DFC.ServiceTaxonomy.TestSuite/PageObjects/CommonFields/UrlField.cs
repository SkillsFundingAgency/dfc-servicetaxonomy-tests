using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields
{
    public class UrlField
    {
        protected readonly ScenarioContext _scenarioContext;

        public UrlField(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement GetUrlField(string contentType) =>
            _scenarioContext.GetWebDriver().FindElement(By.Id($"{contentType}_URL_Text"));

        public string GetValue(string contentType) =>
            GetUrlField(contentType).GetAttribute("value");
    }
}
