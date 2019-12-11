using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using DFC.ServiceTaxonomy.TestSuite.Context;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class LogonScreen
    {
        //private IWebDriver driver;
        //EnvironmentSettings env = new EnvironmentSettings();
        private EditorContext testContext;

        public LogonScreen(EditorContext context)
        {
            testContext = context;
            //this.driver = driver;
            //PageFactory.InitElements(driver, this);
        }

        public LogonScreen navigateToLoginPage(string url)
        {
            testContext.GetWebDriver().Url = url;
            return this;
        }

        public LogonScreen enterUsername(string username)
        {
            testContext.GetWebDriver().FindElement(By.Id("UserName")).SendKeys(username);
            return this;
        }

        public LogonScreen enterPassword(string password)
        {
            testContext.GetWebDriver().FindElement(By.Id("Password")).SendKeys(password);
            testContext.GetWebDriver().FindElement(By.Id("Password")).SendKeys(Keys.Return);
            return this;
        }

        public StartPage SubmitLogonDetails ()
        {
            navigateToLoginPage(testContext.editorBaseUrl);
            enterUsername(testContext.editorUid);
            enterPassword(testContext.editorPassword);
            return new StartPage(testContext);
        }
    }


}
