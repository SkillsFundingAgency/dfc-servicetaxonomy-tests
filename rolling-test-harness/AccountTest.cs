using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace rolling_test_harness
{
    class AccountTest: TestBase, ITest
    {
        private string url;
        private string uid;
        private string pwd;
        private string outputDir;

        public AccountTest( string _url, string _uid, string _pwd, string _outputDir)
        {
            url = _url;
            uid = _uid;
            pwd = _pwd;
            outputDir = _outputDir;
        }

        public void RunTest()
        {
            bool done = false;
            string message = "";
            string outputFile = $"{outputDir}rollingCheck.log";
            while (!done)
            {
                bool fail = false;
                var driver = IntialiseWebDriver();
                driver.Manage().Window.Maximize();
 
                try
                {
                    message = "load page";

                    driver.Navigate().GoToUrl(url);
                    var login = WaitUntilElementFound(driver, By.Id("emailCustom"));
                    login.SendKeys(uid);
                    var password = driver.FindElement(By.Id("passwordCustom"));
                    password.SendKeys(pwd);
                    driver.FindElement(By.Id("preSubmit")).Click();

                    message = "attempt login";

                    By expected = By.Id("homeGovUkLinkYour-details");
                    By notWorking = By.XPath("//*[contains(text(),'This page isn')]");
                    By problem = By.XPath("//*[contains(text(),'problem with this service')]");
                    By unavailable = By.XPath("//*[contains(text(),'service unavailable')]");
                    By locatorOfElementThatIsPresent = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 240)).Until(driver => {
                        // findElements does not throw when element not found, so I skip try-catch
                        if (driver.FindElements(expected).Count > 0) return expected;
                        if (driver.FindElements(notWorking).Count > 0) return notWorking;
                        if (driver.FindElements(problem).Count > 0) return problem;
                        if (driver.FindElements(unavailable).Count > 0) return unavailable;
                        return null; // neither found, so the method will be retried until timeout
                    });



                    if (locatorOfElementThatIsPresent != expected)
                    {
                        throw new Exception("Home page not loaded");
                    }

                    message = "logon complete";
                    using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter(outputFile, true))
                    {
                        file.WriteLine($"{DateTime.Now} logon succesful");
                    }
                    message = "attempt to load action plan";
                    //
                    driver.FindElement(By.XPath("//a[contains(@href,'/action-plans/')]")).Click();

                    expected = By.XPath("//a[contains(@href,'/action-plans/view-goal')]");
                    locatorOfElementThatIsPresent = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 240)).Until(driver => {
                        // findElements does not throw when element not found, so I skip try-catch
                        if (driver.FindElements(expected).Count > 0) return expected;
                        if (driver.FindElements(notWorking).Count > 0) return notWorking;
                        if (driver.FindElements(problem).Count > 0) return problem;
                        if (driver.FindElements(unavailable).Count > 0) return unavailable;
                        return null; // neither found, so the method will be retried until timeout
                    });

                    if (locatorOfElementThatIsPresent != expected)
                    {
                        throw new Exception("Action Plan not loaded");
                    }

                    message = "action plan loaded";
                    using (System.IO.StreamWriter file =
new System.IO.StreamWriter(outputFile, true))
                    {
                        file.WriteLine($"{DateTime.Now} navigate succesful");
                    }
                }
                catch (Exception e)
                {
                    fail = true;
                    Console.WriteLine("Failure: " + e.Message);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(outputFile, true))
                    {
                        file.WriteLine($"{DateTime.Now} Failed to load XXXXXXXXXXXXXXXXXX {message} XXXXXXXXXXXXXXXXXXX {e.Message}");
                    }
                }
                if (fail)
                {
                    try
                    {
                        var screenshotName = $"{_config["testRunner:OutputDir"]}{ DateTime.Now:HH-mm-ss}_fail.png".Replace("/", string.Empty)
                                                                                                                    .Replace("\"", "'");

                        ITakesScreenshot screenshotHandler = driver as ITakesScreenshot;
                        Screenshot screenshot = screenshotHandler.GetScreenshot();
                        screenshot.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);


                    }
                    catch (Exception e)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFile, true))
                        {
                            file.WriteLine($"{DateTime.Now} problem withscreenshot {e.Message}");
                        }

                    }
                }
                driver.Close();
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
