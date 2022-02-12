using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    public class ApprenticeshipStandardsPage
    {
        private readonly ScenarioContext _scenarioContext;

        public ApprenticeshipStandardsPage(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement DescriptionField => _scenarioContext.GetWebDriver().FindElement(By.Id("ApprenticeshipStandard_Description_Text"));
        IWebElement LarsCodeField => _scenarioContext.GetWebDriver().FindElement(By.Id("ApprenticeshipStandard_LARScode_Text"));

        public void EnterDescription(string text) =>
            DescriptionField.SendKeys(text);

        public string GetDescription() =>
            DescriptionField.GetAttribute("value");

        public void EnterLarsCode(string text) =>
            LarsCodeField.SendKeys(text);

        public string GetLarsCode() =>
            LarsCodeField.GetAttribute("value");
    }

    public class HiddenAlternativeTitlePage
    {
        private readonly ScenarioContext _scenarioContext;

        public HiddenAlternativeTitlePage(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement DescriptionField => _scenarioContext.GetWebDriver().FindElement(By.Id("HiddenAlternativeTitle_Description_Text"));

        public void EnterDescription(string text) =>
            DescriptionField.SendKeys(text);

        public string GetDescription() =>
            DescriptionField.GetAttribute("value");
    }
}
