using System;
using System.Collections.Generic;
using System.Text;
using DFC.ServiceTaxonomy.TestSuite;
using OpenQA.Selenium;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class WebDriverExtension
    {
        public static bool ClickButton (this IWebDriver driver, string buttonText)
        {
            if (ClickButtonByText(driver, buttonText)) return true;
            if (ClickButtonById(driver, buttonText)) return true;
            if (ClickButtonByLinkText(driver, buttonText)) return true;
            if (ClickButtonByCssSelector(driver, buttonText)) return true;
            if (ClickButtonByContainsText(driver, buttonText)) return true;

            throw new Exception("Unable to locate button");

        }

        public static bool ClickButtonByText(this IWebDriver driver, string buttonText)
        {
            try
            {
                driver.FindElement(By.XPath("//button[text()='" + buttonText + "']")).Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public static bool ClickButtonByCssSelector(this IWebDriver driver, string cssSelector)
        {
            try
            {
                driver.FindElement(By.CssSelector(cssSelector)).Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        
        public static bool ClickButtonByContainsText(this IWebDriver driver, string buttonText)
        {
            try
            {
                driver.FindElement(By.XPath("//*[text()[contains(.,'" + buttonText + "')]]")).Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ClickButtonById(this IWebDriver driver, string buttonId)
        {
            try
            {
                driver.FindElement(By.Id(buttonId)).Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ClickButtonByLinkText(this IWebDriver driver, string linkText)
        {
            try
            {
                driver.FindElement(By.LinkText(linkText)).Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}

