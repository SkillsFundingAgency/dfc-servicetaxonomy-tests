using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields
{
    public class InfoHtml
    {
        protected readonly ScenarioContext _scenarioContext;

        public InfoHtml(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement GetInfoField(string contentType) =>
            _scenarioContext.GetWebDriver().FindElement(By.Id($"{contentType}_Info_Html"));

        public string GetValue(string contentType) =>
            GetInfoField(contentType).GetAttribute("value");
    }
}
