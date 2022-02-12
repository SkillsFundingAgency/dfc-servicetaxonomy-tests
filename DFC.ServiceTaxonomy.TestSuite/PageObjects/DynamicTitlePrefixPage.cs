using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    public class DynamicTitlePrefixPage
    {
        private readonly ScenarioContext _scenarioContext;

        public DynamicTitlePrefixPage(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement TitleField => _scenarioContext.GetWebDriver().FindElement(By.Id("TitlePart_Title"));

        public string GetTitle() =>
            TitleField.GetAttribute("value");
    }
}
