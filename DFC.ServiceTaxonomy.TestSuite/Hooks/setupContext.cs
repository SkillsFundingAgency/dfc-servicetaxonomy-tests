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
        private int _WebdriverTimeoutSeconds = 0; // 0 means use default value
        private const int _WebdriverExtendedTimeout = 1200;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public setupContext ( FeatureContext fContext, ScenarioContext sContext)
        {
            _featureContext = fContext;
            _scenarioContext = sContext;
        }

        [BeforeScenario("longrunning", Order = 10)]
        public void SetLongRunningTimeout()
        {
            _WebdriverTimeoutSeconds = _WebdriverExtendedTimeout;
        }

        [BeforeScenario("webtest", Order = 20)] 
        public void IntialiseWebDriver()
        {
            if (_WebdriverTimeoutSeconds > 0)
            {
                _scenarioContext.SetWebDriver(new ChromeDriver(Environment.CurrentDirectory, new ChromeOptions(), TimeSpan.FromSeconds(_WebdriverTimeoutSeconds)));
            }
            else
            {
                _scenarioContext.SetWebDriver(new ChromeDriver());
            }
        }





        [BeforeScenario]
        public void IntialiseEnvironementVariables()
        {
            _scenarioContext.SetEnv(new EnvironmentSettings());
        }
    }
}
