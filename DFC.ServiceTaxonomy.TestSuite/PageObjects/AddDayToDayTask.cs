using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddDayToDayTask: AddContentItemBase
    {
        public AddDayToDayTask(ScenarioContext context) : base ( context )
        {
        }

        private By getDayToDayTaskLocator(String field)
        {
         return null;
        }

        private new By  getLocator(String field)
        {
            return (getLocatorBase(field) ?? getDayToDayTaskLocator(field));
            //{
            //switch (field)
            //{
            //    case "Title":
            //        return By.Id("TitlePart_Title");
            //    case "Description":
            //        return By.ClassName("trumbowyg-editor");
            //    case "Uri":
            //        return By.Id("GraphSyncPart_Text");
            //    default:
            //        return null;
            //}
        }

        public  AddDayToDayTask SetFieldValue(string field, string value, string itemType = "")
        {
            IWebElement item = null;
            try
            {
                item = _scenarioContext.GetWebDriver().FindElement(getLocator(field));
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

    }
}
