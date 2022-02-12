using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields
{
    public class Description
    {
        protected readonly ScenarioContext _scenarioContext;

        public Description(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement GetDescriptionField(string contentType) =>
            _scenarioContext.GetWebDriver().FindElement(By.Id($"{contentType}_Description_Text"));

        public string GetValue(string contentType) =>
            GetDescriptionField(contentType).GetAttribute("value");
    }
}
