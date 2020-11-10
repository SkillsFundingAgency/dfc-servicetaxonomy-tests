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
    static class FeatureHooks
    {


        private static FeatureContext _featureContext;

        //static FeatureHooks()
        //{
        //    //_featureContext = fContext;
        //}

        //[BeforeFeature(Order = 20)]
        //public static void IntialiseWebDriver()
        //{
        //    //string DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    //if (_WebdriverTimeoutSeconds > 0)
        //    //{
        //    //    _featureContext.SetWebDriver(new ChromeDriver(FindDriverService(), new ChromeOptions(), TimeSpan.FromSeconds(_WebdriverTimeoutSeconds)));
        //    //}
        //    //else
        //    //{
        //        _featureContext.SetWebDriver(new ChromeDriver(FindDriverService()));
        //    //}
        //    //_scenarioContext.GetWebDriver().Manage().Window.Maximize();
        //}

        //private static string FindDriverService()
        //{
        //    string driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    string driverName = "chromedriver.exe";

        //    FileInfo[] file = Directory.GetParent(driverPath).GetFiles(driverName, SearchOption.AllDirectories);

        //    var driverLocation = file.Length != 0 ? file[0].DirectoryName : driverPath;

        //    Console.WriteLine($"Driver Service should be available under: {driverLocation}");

        //    return driverLocation;
        //}


        //[AfterFeature(/*TODO TAGGING?*/Order = 20)]
        //public static void CloseWebDriver()
        //{
        //    _featureContext.GetWebDriver().Close();
        //    _featureContext.GetWebDriver().Quit();
        //}
    }


}

