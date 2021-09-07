using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class StartPage
    {
        private ScenarioContext _scenarioContext;

        public StartPage(ScenarioContext context)
        {
            _scenarioContext = context;

        }

        public StartPage NavigateTo( string sPath)
        {
            string url = _scenarioContext.GetEnv().EditorBaseUrl + ( sPath.StartsWith("/") ? string.Empty : "/" ) + sPath;
            _scenarioContext.GetWebDriver().Url = url;
            return this;
        }
    }
}
