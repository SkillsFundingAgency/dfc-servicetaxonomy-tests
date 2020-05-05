using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
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
        private const string ChromeDriverServiceName = "chromedriver.exe";

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
            string DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (_WebdriverTimeoutSeconds > 0)
            {
                _scenarioContext.SetWebDriver(new ChromeDriver(Environment.CurrentDirectory, new ChromeOptions(), TimeSpan.FromSeconds(_WebdriverTimeoutSeconds)));
            }
            else
            {
               // _scenarioContext.SetWebDriver(new ChromeDriver(Environment.CurrentDirectory));
                //  _scenarioContext.SetWebDriver ( ChromeDriver(new List<string>()) );
                _scenarioContext.SetWebDriver(new ChromeDriver(FindDriverService()));
            }
        }

        //private ChromeDriver ChromeDriver(List<string> arguments)
        //{
        //    arguments.Add("no-sandbox");
        //    return new ChromeDriver(FindDriverService(),
        //                                         AddArguments(arguments)//,
        //                                         //TimeSpan.FromMinutes(_frameworkConfig.TimeOutConfig.CommandTimeout)
        //                                         );
        //}

        //private ChromeOptions AddArguments(List<string> arguments)
        //{
        //    var chromeOptions = new ChromeOptions();
        //    arguments.ForEach((x) => chromeOptions.AddArgument(x));
        //    return chromeOptions;
        //}

        private string FindDriverService()
        {
            string driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string driverName = "chromedriver.exe";

            FileInfo[] file = Directory.GetParent(driverPath).GetFiles(driverName, SearchOption.AllDirectories);

            var driverLocation = file.Length != 0 ? file[0].DirectoryName : driverPath;

           Console.WriteLine($"Driver Service should be available under: {driverLocation}");

            return driverLocation;
        }




        [BeforeScenario]
        public void IntialiseEnvironementVariables()
        {
            _scenarioContext.SetEnv(new EnvironmentSettings());
        }
    }
}
