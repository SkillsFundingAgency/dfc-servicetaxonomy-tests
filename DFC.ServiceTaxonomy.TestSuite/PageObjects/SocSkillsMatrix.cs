using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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