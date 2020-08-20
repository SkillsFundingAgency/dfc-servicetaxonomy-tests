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
    class AddEditPage //: AddContentItemBase
    {
        private const string _contentType = "Page";
        ScenarioContext scenarioContext;

        public AddEditPage(ScenarioContext context)// : base(context)
        {
            scenarioContext = context;
        }

        private By getLocator( String field)
        {
           
            switch (field)
            {
                case "RedirectLocations":
                    return By.Id($"Page_RedirectLocations_Text");
                case "Description":
                    return By.Id("Page_Description_Text");
                //return By.ClassName("trumbowyg-editor");
                default:
                    return null;
            }
        }

        public bool SetFieldValue( string field, string value)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set field value {field} - {e.Message}");
                return false;
            }
            return true;
        }

        public bool SetBasePageLocation()
        {
            try
            {
                scenarioContext.GetWebDriver().ClickOnItem("Page_PageLocations_TermEntries_0__Selected");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set base page location - {e.Message}");
                return false;
            }
            return true;
        }

        public AddEditPage OpenWidgetMenu()
        {
            try
            {
                scenarioContext.GetWebDriver().FindElement(By.XPath("//button[@title='Add Widget']")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to open widget menu");
            }
            return this;
        }

        public bool AddHtmlItem(string htmlValue)
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                OpenWidgetMenu();
                var element = driver.FindElement(By.LinkText("HTML"));
                element.Click();
                element = driver.WaitUntilElementFound(By.ClassName("trumbowyg-editor"));
                element.SendKeys(htmlValue);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to add HTML Item - {e.Message}");
                return false;
            }
            return true;
        }

        public bool AddSharedContentItem(string name)
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                OpenWidgetMenu();
                var element = driver.FindElement(By.LinkText("HTML Shared"));
                element.Click();
                element = driver.WaitUntilElementFound(By.ClassName("multiselect__tags"));
                element.Click();
                element = driver.WaitUntilElementFound(By.ClassName("multiselect__input"));
                element.SendKeys(name);
                Thread.Sleep(500);
                //TODO use selenium wait
                element.SendKeys(Keys.Enter);



            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable add Shared Content item- {e.Message}");
                return false;
            }
            return true;
        }

        public bool AddSharedContentItemToExistingWidget(string name)
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                //OpenWidgetMenu();
                //var element = driver.WaitUntilElementFound(By.ClassName("multiselect__tags"));
                //element.Click();
                var element = driver.WaitUntilElementFound(By.ClassName("multiselect__tags"));
                element.Click();
                element = driver.WaitUntilElementFound(By.ClassName("multiselect__input"));
                element.SendKeys(name);
                Thread.Sleep(500);
                //TODO use selenium wait
                element.SendKeys(Keys.Enter);



            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable add Shared Content item- {e.Message}");
                return false;
            }
            return true;
        }

        public bool InsertHtmlItem(int position = 0)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set base page location - {e.Message}");
                return false;
            }
            return true;
        }

        public bool InsertSharedHtmlItem(int position)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set base page location - {e.Message}");
                return false;
            }
            return true;
        }
    }
}
