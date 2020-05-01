using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddContentItemBase : IEditorContentItem
    {
        protected ScenarioContext _scenarioContext;

        public AddContentItemBase(ScenarioContext context)//IWebDriver driver, ScenarioContext context)
        {
            _scenarioContext = context;
        }

        protected By getLocatorBase(String field)
        {
            switch (field)
            {
                case "Title":
                    return By.Id("TitlePart_Title");
                case "Text":
                case "Description":
                    return By.ClassName("trumbowyg-editor");
                case "Uri":
                    return By.Id("GraphSyncPart_Text");
                default:
                    return null;
            }
        }

        protected By getLocatorFromType(String contentType, String type, String field)
        {
            switch (type)
            {
                case "Text Field":
                    return By.Id(contentType + "_TextField_Text");
                 case "Numeric Field":
                    return By.Id(contentType + "_ValueField_Value");
                case "Title":
                    return getLocatorBase(field);
                default:
                    return null;
            }
        }

        public By getLocator(string field)
        {
            return getLocatorBase(field);
        }

        public string GetGeneratedURI()
        {
            //return _scenarioContext.GetWebDriver().FindElement(By.Id("Graph_UriId_Text")).GetAttribute("value");
            return _scenarioContext.GetWebDriver().FindElement(By.Id("GraphSyncPart_Text")).GetAttribute("value");
            
        }

        //public AddContentItemBase SetFieldValue( string field, string value, string itemType = "")
        //{
        //    string id;
        //    IWebElement item = null ;
        //    try
        //    {
        //        switch (field)
        //        {
        //            case "Title":
        //                id = "TitlePart_Title";
        //                item = _scenarioContext.GetWebDriver().FindElement(By.Id(id));
        //                break;
        //            case "Description":
        //                id = "/html/body/div[2]/div[3]/form/div[2]/div/div[2]/div[2]/div/div[2]/p";
        //                ///html/body/div[2]/div[3]/form/div[2]/div/div[2]/div[2]/div/div[2]/p
        //                //item = _scenarioContext.GetWebDriver()FindElement(By.XPath(id));
        //                item = _scenarioContext.GetWebDriver().FindElement(By.ClassName("trumbowyg-editor"));
        //                ///html/body/div[2]/div[3]/form/div[2]/div/div[2]/div[2]/div/div[2]/p
        //                break;
        //            default:
        //                id = "";
        //                break;
        //        }
        //        item.Click();
        //        item.Clear();
        //        item.SendKeys(value);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }

        //    return this;
        //}

        public AddContentItemBase PublishActivity()
        {
            _scenarioContext.GetWebDriver().FindElement(By.Name("submit.Publish")).Click();
            //.XPath("/html/body/div[1]/div[3]/form/div[2]/div/div[3]/div/button[1]")).Click();
            return this;
        }

        public AddContentItemBase EnterText(string field, string value, By locator)
        {
            IWebElement item = null;
            try
            {
                item = _scenarioContext.GetWebDriver().FindElement(locator);
                // item = _scenarioContext.GetWebDriver().FindElement( OverrideLocator(field) ?? getLocatorBase(field));
                item.Click();
                item.Clear();
                item.SendKeys(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        public string GetFieldValue(string fieldName)
        {
            //only currently works with base types
            string value = "";
            try
            {
                value = _scenarioContext.GetWebDriver().FindElement(getLocatorBase(fieldName)).GetAttribute("value");
            }
            catch
            {
            }
            return value;

        }

        public void SetFieldValue(string type, string field, string value)//, Func <String, By> OverrideLocator)
        {
             EnterText( field, value, getLocatorBase(field)) ;
        }

        public void SetFieldValueFromType(string contenType, string field, string value, string type)//, Func <String, By> OverrideLocator)
        {
            EnterText(field, value, getLocatorFromType(contenType, type, field));
        }

        public bool ConfirmSuccess()
        {
            //return _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/div")).Text.Contains("Your Activity has been published.") ;
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'has been published.')]]"));
            return ( elements.Count == 1 );
            //return _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[2]/div[3]/div[1]")).Text.Contains("has been published.");
           
        }
    }
}
