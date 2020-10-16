using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class EditPageLocationTaxonomy 
    {
        ScenarioContext scenarioContext;

        public EditPageLocationTaxonomy(ScenarioContext context) 
        {
            scenarioContext = context;
        }

        private By GetLocator( String field)
        {
           
            switch (field)
            {
                case "RedirectLocations":
                    return By.Id($"Page_RedirectLocations_Text");
                case "Description":
                    return By.Id("Page_Description_Text");
                default:
                    return null;
            }
        }

        public bool AddPageLocation()
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                driver.ClickButton("Add");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to add page location - {e.Message}");
                return false;
            }
            return true;
        }


        public bool EditPageLocation(string name)
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                var elements = driver.FindElements(By.XPath($"//span[text()='{name}']/.."));
                elements[0].FindElement(By.LinkText("Edit")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to edit page location {name} - {e.Message}");
                return false;
            }
            return true;
        }

        public bool DeletePageLocation(string name)
        {
            bool result = false;
            var driver = scenarioContext.GetWebDriver();
            try
            {
                var elements = driver.FindElements(By.XPath($"//span[text()='{name}']/.."));
                foreach (var element in elements)
                {
                    element.FindElement(By.LinkText("Delete")).Click();
                    ConfirmDelete();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to delete page location {name} - {e.Message}");
                return false;
            }
            return result;
        }

        public void ConfirmDelete()
        {
            try
            {
                scenarioContext.GetWebDriver().FindElement(By.Id("modalOkButton"))
                                               .Click();
            }
            catch ( Exception e)
            {
                Console.WriteLine($"Unable to confirm action - {e.Message}");
            }
        }
    }
}
