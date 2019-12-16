using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    [Binding]
    public sealed class setupContext
    {
        FeatureContext _featureContext;
        ScenarioContext _scenarioContext;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public setupContext ( FeatureContext fContext, ScenarioContext sContext)
        {
            _featureContext = fContext;
            _scenarioContext = sContext;
        }
        [BeforeScenario("webtest")] 
        public void IntialiseWebDriver()
        {
            _scenarioContext.SetWebDriver(new ChromeDriver(Environment.CurrentDirectory));
        }

        [BeforeScenario]
        public void IntialiseEnvironementVariables()
        {
            _scenarioContext.SetEnv(new EnvironmentSettings());
        }
    }
}
