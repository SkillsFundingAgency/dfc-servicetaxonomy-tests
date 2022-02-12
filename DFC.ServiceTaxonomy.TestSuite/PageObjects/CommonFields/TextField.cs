using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields
{
    public class TextField
    {
        protected readonly ScenarioContext _scenarioContext;

        public TextField(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement GetTextField(string contentType) =>
            _scenarioContext.GetWebDriver().FindElement(By.Id($"{contentType}_Text_Text"));

        public string GetValue(string contentType) =>
            GetTextField(contentType).GetAttribute("value");
    }
}
