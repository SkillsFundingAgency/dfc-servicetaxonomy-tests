using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Helpers
{
    public class Utilities
    {
        public static void SelectFromDropdown(IWebElement elementLocator, string textToSelect)
        {
            var selector = new SelectElement(elementLocator);
            selector.SelectByText("TextToSelect");
        }

        public static void Hover(IWebDriver driver, IWebElement elementLocator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(elementLocator);
            action.Build();
            action.Perform();
        }
    }
}
