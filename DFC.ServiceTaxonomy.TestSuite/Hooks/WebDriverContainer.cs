﻿using System;
using System.Collections.Generic;

using DFC.ServiceTaxonomy.SharedResources.Helpers;

using OpenQA.Selenium.Chrome;


namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    public sealed class WebDriverContainer
    {
        private ChromeDriver driver = null;
        private Dictionary<string, Neo4JHelper> graphConnections = null;
        private static readonly Lazy<WebDriverContainer> lazy =
            new Lazy<WebDriverContainer>(() => new WebDriverContainer());

        public static WebDriverContainer Instance { get { return lazy.Value; } }

        public ChromeDriver GetWebDriver(string path, int timeoutPeriod = 0)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            if (driver == null)
            {
                if (timeoutPeriod > 0)
                {
                    driver = new ChromeDriver(path, options, TimeSpan.FromSeconds(timeoutPeriod));
                }
                else
                {
                    driver = new ChromeDriver(path, options);
                }
            }
            return driver;
        }

        public void CloseDriver()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
                driver = null;
            }
        }

        public Neo4JHelper GetGraphConnection(string key, string graphName, string graphUri, string userId, string password)
        {
            if (graphConnections == null)
            {
                graphConnections = new Dictionary<string, Neo4JHelper>();
            }
            if (!graphConnections.ContainsKey(key))
            {
                Neo4JHelper newConn = new Neo4JHelper(graphName);
                newConn.Connect(graphUri,
                                    userId,
                                    password);
                graphConnections[key] = newConn;
            }
            graphConnections[key].Verify();
            return graphConnections[key];
        }
    }
}
