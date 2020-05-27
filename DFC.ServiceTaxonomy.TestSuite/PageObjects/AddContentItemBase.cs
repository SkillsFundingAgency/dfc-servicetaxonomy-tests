using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddContentItemBase : IEditorContentItem
    {
        private const string emptyFieldValidationMessage = "A value is required for ";

        protected ScenarioContext _scenarioContext;
        protected bool _htmlView = false;

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

        public By getLocator(string contentType, string fieldType, string fieldName)
        {
            switch (fieldType)
            {
                case "Text":
                case "Html":
                    return By.Id($"{contentType}_{fieldName.Replace(" ","")}_{fieldType}");
                default:
                    return getLocatorBase(fieldName);
            }
        }

        public string GetGeneratedURI()
        {
            //return _scenarioContext.GetWebDriver().FindElement(By.Id("Graph_UriId_Text")).GetAttribute("value");
            return _scenarioContext.GetWebDriver().FindElement(By.Id("GraphSyncPart_Text")).GetAttribute("value");
            
        }

        public string ContentItemIdFromUrl()
        {
            string pattern = @"[a-zA-Z0-9]{26}";
            string url = _scenarioContext.GetWebDriver().Url;
            Match m = Regex.Match(url, pattern);
            if (m.Success)
            {
                return m.Value;
            }
            return "";
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

        public AddContentItemBase SaveActivity()
        {
            _scenarioContext.GetWebDriver().FindElement(By.Name("submit.Save")).Click();
            //.XPath("/html/body/div[1]/div[3]/form/div[2]/div/div[3]/div/button[1]")).Click();
            return this;
        }

        public AddContentItemBase EnterText(string field, string value, By locator)
        {
            IWebElement item = null;
            try
            {
                if (_htmlView)
                {
                   item = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-viewHTML-button > svg"));
                   item.Click();
                }
                item = _scenarioContext.GetWebDriver().FindElement(locator);
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

        public string GetFieldValue(string contentType, string fieldName)
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
        public string GetFieldValue(string contentType, string fieldType, string fieldName)
        {
            string value = "";
            try
            {
                value = _scenarioContext.GetWebDriver().FindElement(getLocator(contentType, fieldType, fieldName)).GetAttribute("value");
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
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'has been published.')]]"));
            return ( elements.Count == 1 );
        }

        public bool ConfirmEmptyFieldError(string field)
        {
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath($"//*[text()[contains(.,'{emptyFieldValidationMessage}{field}')]]"));
            return (elements.Count == 1);
         }
    }
}
