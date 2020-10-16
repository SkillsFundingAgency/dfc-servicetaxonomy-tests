using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using TechTalk.SpecFlow;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
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
            _scenarioContext.GetWebDriver().Manage().Window.Maximize();
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




        [BeforeScenario  (Order = 1)]
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

        [BeforeScenario(Order = 5)]
        public void CheckConnections()
        {
            // check SQL connection
            var conn = _scenarioContext.GetSQLConnection();
            if (!conn.CheckPermissions(new [] { "SELECT","DELETE"}))
            {
                _featureContext["failAll"] = true;
                throw new Exception("Unable to verify permission on SQL connection");
            }

            // check Graph connections
            try
            {
                _scenarioContext.GetGraphConnection(constants.publish);
            }
            catch( Exception e)
            {
                _featureContext[constants.featureFailAll] = true;
                Console.WriteLine("Unable to verify connection to publish graph");
                throw e;
            }

            try
            {
                _scenarioContext.GetGraphConnection(constants.preview);
            }
            catch (Exception e)
            {
                _featureContext[constants.featureFailAll] = true;
                Console.WriteLine("Unable to verify connection to preview graph");
                throw e;
            }

            if (_scenarioContext.GetEnv().neo4JUrl1.Length > 0)
            {
                try
                {
                    _scenarioContext.GetGraphConnection(constants.publish, 1);
                }
                catch (Exception e)
                {
                    _featureContext["failAll"] = true;
                    Console.WriteLine("Unable to verify connection to publish1 graph");
                    throw e;
                }
            }

            if (_scenarioContext.GetEnv().neo4JUrlDraft1.Length > 0)
            {
                try
                {
                    _scenarioContext.GetGraphConnection(constants.preview, 1);
                }
                catch (Exception e)
                {
                    _featureContext[constants.featureFailAll] = true;
                    Console.WriteLine("Unable to verify connection to preview1 graph");
                    throw e;
                }
            }
        }
    }
}
