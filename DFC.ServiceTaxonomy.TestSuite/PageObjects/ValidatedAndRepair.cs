using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    public class ValidatedAndRepairResults
    {
        int RecordsCheck { get; set; }
        int RecordsInvalid { get; set; }
        int RecordsRepaired { get; set; }
    }

    public class ValidatedAndRepair
    {
        private ScenarioContext _scenarioContext;
        private EnvironmentSettings _env;
        private IWebDriver _driver;

        public ValidatedAndRepair(ScenarioContext context)//IWebDriver driver, ScenarioContext context)
        {
            _scenarioContext = context;
            _env = context.GetEnv();
            _driver = context.GetWebDriver();
        }

        public ValidatedAndRepair RunValidateAndRepair()
        {
            _driver.Navigate().GoToUrl(_env.editorBaseUrl + "/Admin/DFC.ServiceTaxonomy.GraphSync/GraphSync/TriggerSyncValidation");
            return this;
        }

        public bool CheckForSuccess()
        {
            var elements = _driver.FindElements(By.XPath("/html/body/div[1]/div[3]/div[1]"));
            return (elements.Count == 1);
        }

        public ValidatedAndRepair  GetResults()
        {
            
            //try
            //{
            //    var elements = _driver.FindElements(By.XPath("//*[@id='results']/li[1]"));
            //    string text;
            //    foreach (var element in elements)
            //    {
            //        text = element.GetAttribute("Value");
            //        text = element.Text;

            //    }

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            return this;
        }


        private IWebElement FindReportSection(string sectionReference)
        {
            string id = "";
            switch (sectionReference)
            {
                case "Validated":
                    id = "validated";
                    break;
                case "Failed Validation":
                    id = "failed-validation";
                    break;
                case "Repaired":
                    id = "repaired";
                    break;
                default:
                    break;
            }
            var elements = _driver.FindElements(By.Id(id));
            if ( elements.Count > 0 )
            {
                return elements[0];
            }
            else
            {
                return null;
            }

        }
        public bool FindRecordInSection( string sectionReference, string recordId)
        {
            bool success = false;
            var item = FindReportSection(sectionReference);

            try
            {
            //    Actions builder = new Actions(_driver);
            //    var mouseUp = builder.MoveToElement(item)
            //                     .Click()
            //                     .Build(); ;
            //    mouseUp.Perform();

                var listItems = item.FindElements(By.TagName("li"));


                foreach (var listItem in listItems)
                {
                    string text = listItem.Text;
                    string text2 = listItem.GetAttribute("textContent");
                    success = text2.Contains(recordId);
                    if (success)
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //try
            //{
            //   var matches = item.FindElements(By.XPath("//*[contains(text(),'" + recordId + "')]")).Count;
            //   success = ( matches > 0 );
            //}
            //catch( Exception e)
            //{

            //}

            return success;
        }

        public bool CheckForMessage ( string sectionReference, string recordId, string message)
        {
            try
            {
                var details = _driver.FindElement(By.Id("valfail-" + recordId));
            }
            catch
            { }

            bool success = false;
            var item = FindReportSection(sectionReference);
            var listItems = item.FindElements(By.TagName("li"));

            foreach (var listItem in listItems)
            {
                string recordName = listItem.GetAttribute("textContent");
                bool located = recordName.Contains(recordId);
                if (located)
                {
                    var details = listItem.FindElements(By.XPath(".//*")) ;
                    foreach ( var code in details)
                    {
                        string text = code.Text;
                        string text2 = code.GetAttribute("textContent");
                        if (text2.Contains(message))
                        {
                            success = true;
                            break;
                        }
                    }
                }
            }


            //try
            //{
            //    var matches = item.FindElements(By.XPath("//*[text()[contains(.,'" + recordId + "')]]"));
            //    foreach (var match in matches)
            //    {
            //        success = (match.FindElements(By.XPath("//*[text()[contains(.,'" + message + "')]]")).Count > 0);
            //        if (success)
            //            break;
            //    }
            //}
            //catch (Exception e)
            //{

            //}
            return success;
        }
    }
}
