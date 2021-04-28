using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;

namespace rolling_test_harness
{
    class TestBase
    {
        public IConfiguration _config {get;set;}

        public TestBase()
        {
            _config = BuildConfiguration();
        }

        public IWebElement WaitUntilElementFound(IWebDriver driver, By elementId)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5, 0));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementId));
        }

        public IWebDriver IntialiseWebDriver()
        {
            return new ChromeDriver(FindDriverService(), new ChromeOptions(), TimeSpan.FromSeconds(360));
            //           return new ChromeDriver(FindDriverService());
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

        public IConfiguration BuildConfiguration()
        {

            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory());

            configurationBuilder
                   .AddJsonFile("appsettings.json", false, true);

            return configurationBuilder.Build();

        }



    }
}
