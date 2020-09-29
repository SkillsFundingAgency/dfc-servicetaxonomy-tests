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
        private const string mask = "########################################################################################################################################";
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
                _scenarioContext.SetWebDriver(new ChromeDriver(FindDriverService(), new ChromeOptions(), TimeSpan.FromSeconds(_WebdriverTimeoutSeconds)));
            }
            else
            {
                _scenarioContext.SetWebDriver(new ChromeDriver(FindDriverService()));
            }
        }

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
            string value;
            string name;
            _scenarioContext.SetEnv(new EnvironmentSettings());

            if (_featureContext.ContainsKey("failAll") && (bool)_featureContext["failAll"] == true)
            {
                throw new Exception("Feature run aborted due to earlier failure");
            }

            PropertyInfo[] properties = typeof(EnvironmentSettings).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                name = property.Name;
                value = string.Empty;
                try
                {
                    if (property.PropertyType == typeof(Boolean))
                    {
                        value = ((bool)property.GetValue(_scenarioContext.GetEnv())).ToString();
                    }
                    else
                    {
                        value = (string)property.GetValue(_scenarioContext.GetEnv());
                        if (name.ToLower().Contains("key") || name.ToLower().Contains("password") || name.Contains("pwd") || name.Contains("secret"))
                        {
                            value = mask.Substring(0, value.Length);
                        }
                    }
                }
                catch { }
                Console.WriteLine($"Env: {property.Name} = {value}");
            }
        }
    }
}
