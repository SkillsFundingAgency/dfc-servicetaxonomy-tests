using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Text;
using DFC.ServiceTaxonomy.TestSuite.Context;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddActivity
    {
       // private IWebDriver driver;
        private EditorContext testContext;

        public AddActivity(EditorContext context)//IWebDriver driver, ScenarioContext context)
        {
            testContext = context;
            //this.driver = driver;
            //PageFactory.InitElements(driver, this);
        }

        public AddActivity EnterAction (string action)
        {
            testContext.GetWebDriver().FindElement(By.Id("TitlePart_Title")).SendKeys(action);
            return this;
           
        }

        public AddActivity EnterURI(string uri)
        {
            testContext.GetWebDriver().FindElement(By.Id("UriId_URI_Text")).SendKeys(uri);
            testContext.GetWebDriver().FindElement(By.Id("UriId_URI_Text")).SendKeys(Keys.Return);
            return this;
        }
    }
}
