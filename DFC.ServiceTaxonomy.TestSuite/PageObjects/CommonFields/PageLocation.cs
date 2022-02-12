using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields
{
    public class PageLocation
    {
        protected readonly ScenarioContext _scenarioContext;
        public PageLocation(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement UrlNameField =>
            _scenarioContext.GetWebDriver().FindElement(By.Id("PageLocationPart_UrlName"));

        IWebElement FullUrlField =>
            _scenarioContext.GetWebDriver().FindElement(By.Id("PageLocationPart_FullUrl"));

        public void EnterTitle(string text) =>
            UrlNameField.SendKeys(text);

        public string GetUrlName() =>
            UrlNameField.GetAttribute("value");

        public string GetFullUrl() =>
            FullUrlField.GetAttribute("value");

    }
}
