using DFC.ServiceTaxonomy.TestSuite.Extensions;

using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    public class SocSkillsMatrix
    {
        private readonly ScenarioContext _scenarioContext;
        public SocSkillsMatrix(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement ContextualisationField => _scenarioContext.GetWebDriver().FindElement(By.Id("SOCSkillsMatrix_Contextualised_Text"));

        public void EnterContextualisationText(string text)
        {
            ContextualisationField.SendKeys(text);
        }
    }
}
