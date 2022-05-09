using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

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

        public static void HoverClick(IWebDriver driver, IWebElement elementLocator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(elementLocator);
            action.Click();
            action.Perform();
        }

        public static void ScrollIntoView(IWebDriver driver, IWebElement elementLocator)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", elementLocator);
        }

        public static void Wait(IWebDriver driver, IWebElement elementLocator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }

        public static void WaitVisible(IWebDriver driver, By elementLocator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }

        public static bool isElementDisplayed(IWebDriver driver, By locator)
        {
            return driver.FindElement(locator).Displayed;
        }

        public static void javascriptClick(IWebDriver driver, By locator)
        {
            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("arguments[0].click();", locator);
        }

        public static void javascriptScrollUp(IWebDriver driver)
        {
            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight);");
        }
    }
}
