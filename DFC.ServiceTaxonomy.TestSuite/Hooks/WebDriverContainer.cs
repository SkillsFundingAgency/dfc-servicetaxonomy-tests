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
using System.Runtime;


namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    public sealed class WebDriverContainer
    {
        private ChromeDriver driver = null;
        private Dictionary<string, Neo4JHelper> graphConnections = null;
        private static readonly Lazy<WebDriverContainer>
            lazy =
            new Lazy<WebDriverContainer>
                (() => new WebDriverContainer());

        public static WebDriverContainer Instance { get { return lazy.Value; } }

        public ChromeDriver GetWebDriver( string path, int timeoutPeriod = 0)
        {
            if (driver == null)
            {
                if (timeoutPeriod > 0)
                { 
                    driver = new ChromeDriver(path, new ChromeOptions(), TimeSpan.FromSeconds(timeoutPeriod));
                }
                else
                {
                    driver = new ChromeDriver(path);
                }
            }
            return driver;
        }

        public void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Close();
                driver = null;
            }
        }
    }
}
