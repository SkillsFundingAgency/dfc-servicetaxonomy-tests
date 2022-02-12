using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields
{
    public class DescriptionHtml
    {
        protected readonly ScenarioContext _scenarioContext;

        public DescriptionHtml(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement GetDescriptionField(string contentType) =>
            _scenarioContext.GetWebDriver().FindElement(By.Id($"{contentType}_Description_Html"));

        public string GetValue(string contentType) =>
            GetDescriptionField(contentType).GetAttribute("value");
    }
}
