using DFC.ServiceTaxonomy.TestSuite;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class ScenarioContentExtension
    {
        #region contants
        private const string WebDriverKey = "webdriver";
        private const string EnvSettingsKey = "envsettings";
        #endregion

        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            Set(context, webDriver, WebDriverKey);
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return Get<IWebDriver>(context, WebDriverKey);
        }

        public static void SetEnv(this ScenarioContext context, EnvironmentSettings envSettings)
        {
            Set(context, envSettings, EnvSettingsKey);
        }

        public static EnvironmentSettings GetEnv(this ScenarioContext context)
        {
            return Get<EnvironmentSettings>(context, EnvSettingsKey);
        }

        private static void Set<T>(ScenarioContext context, T value, string key)
        {
            context.Set(value, key);
        }

        public static T Get<T>(ScenarioContext context, string key)
        {
            return context.Get<T>(key);
        }
    }
}
