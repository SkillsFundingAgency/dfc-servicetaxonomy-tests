using System;

using DFC.ServiceTaxonomy.TestSuite.Extensions;

using OpenQA.Selenium;

using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class LogonScreen
    {
        private readonly ScenarioContext _scenarioContext;

        public LogonScreen(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        public LogonScreen NavigateToLoginPage(string url)
        {
            _scenarioContext.GetWebDriver().Url = url;
            return this;
        }

        public LogonScreen EnterUsername(string username)
        {
            _scenarioContext.GetWebDriver().FindElement(By.Id("UserName")).SendKeys(username);
            return this;
        }

        public LogonScreen EnterPassword(string password)
        {
            _scenarioContext.GetWebDriver().FindElement(By.Id("Password")).SendKeys(password);
            _scenarioContext.GetWebDriver().FindElement(By.Id("Password")).SendKeys(Keys.Return);
            return this;
        }

        public StartPage SubmitLogonDetails()
        {
            Console.WriteLine("Attempt to logon");
            Console.WriteLine("----------------");
            Console.WriteLine("URL: " + _scenarioContext.GetEnv().EditorBaseUrl);
            Console.WriteLine("UID: " + _scenarioContext.GetEnv().EditorUid);
            Console.WriteLine("PWD (length): " + _scenarioContext.GetEnv().EditorPassword.Length);
            try
            {
                NavigateToLoginPage(_scenarioContext.GetEnv().EditorBaseUrl);

                // are we already logged in?
                if (_scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'Welcome to Orchard')]]")).Count == 0)
                {
                    if (_scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'Begin by browsing the menu.')]]")).Count == 0)
                    {
                        EnterUsername(_scenarioContext.GetEnv().EditorUid);
                        EnterPassword(_scenarioContext.GetEnv().EditorPassword);

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
                Console.WriteLine(@"Logon failed:" + e.Message);
                throw;
            }
            Console.WriteLine($"Logon complete.\nURL is now: {_scenarioContext.GetWebDriver().Url}");
            return new StartPage(_scenarioContext);
        }
    }
}
