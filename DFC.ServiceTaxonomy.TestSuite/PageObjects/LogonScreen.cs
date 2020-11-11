using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class LogonScreen
    {
        private ScenarioContext _scenarioContext;

        public LogonScreen(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        public LogonScreen navigateToLoginPage(string url)
        {
            _scenarioContext.GetWebDriver().Url = url;
            return this;
        }

        public LogonScreen enterUsername(string username)
        {
            _scenarioContext.GetWebDriver().FindElement(By.Id("UserName")).SendKeys(username);
            return this;
        }

        public LogonScreen enterPassword(string password)
        {
            _scenarioContext.GetWebDriver().FindElement(By.Id("Password")).SendKeys(password);
            _scenarioContext.GetWebDriver().FindElement(By.Id("Password")).SendKeys(Keys.Return);
            return this;
        }

        public StartPage SubmitLogonDetails ()
        {
            Console.WriteLine("Attempt to logon");
            Console.WriteLine("----------------");
            Console.WriteLine("URL: " + _scenarioContext.GetEnv().editorBaseUrl);
            Console.WriteLine("UID: " + _scenarioContext.GetEnv().editorUid);
            Console.WriteLine("PWD (length): " + _scenarioContext.GetEnv().editorPassword.Length);
            try
            {
                navigateToLoginPage(_scenarioContext.GetEnv().editorBaseUrl);

                // are we already logged in?
                if (_scenarioContext.GetWebDriver().Url != _scenarioContext.GetEnv().editorBaseUrl)
                {
                    if (_scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'Begin by browsing the menu.')]]")).Count == 0)
                    {
                        enterUsername(_scenarioContext.GetEnv().editorUid);
                        enterPassword(_scenarioContext.GetEnv().editorPassword);

                        var url = _scenarioContext.GetWebDriver().Url;
                        var error = _scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'Invalid login attempt')]]"));
                        if (url.ToLower().Contains("login") || error.Count > 0)
                        {
                            Console.WriteLine("Login Failed: Errors " + error.ToString());
                            throw new Exception("Login Failed");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Already logged in");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Logon failed:"+ e.Message);
                throw e;
            }
            Console.WriteLine($"Logon complete.\nURL is now: {_scenarioContext.GetWebDriver().Url}");
            return new StartPage(_scenarioContext);
        }
    }


}
