using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
//using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Context
{
    public class EditorContextOld
    {
        private IWebDriver _driver;

        //public class CalculatorContext()
        //    {}

        private bool getBool() { return true; }

        public void SetupWebDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver GetWebDriver()
        {
            return _driver;
        }
    }
}
