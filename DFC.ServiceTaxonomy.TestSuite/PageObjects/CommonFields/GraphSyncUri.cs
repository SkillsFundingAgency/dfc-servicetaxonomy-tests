using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields
{
    public class GraphSyncUri
    {
        protected readonly ScenarioContext _scenarioContext;

        public GraphSyncUri(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement UriIdField =>
            _scenarioContext.GetWebDriver().FindElement(By.Id("GraphSyncPart_Text"));

        public string GetValue() =>
            UriIdField.GetAttribute("value");

        public string GetId() =>
            GetValue().Split('/').Last();
    }
}
