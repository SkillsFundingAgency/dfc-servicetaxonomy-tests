using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    public class AddContentTypeBaseItem
    {
        protected ScenarioContext _scenarioContext;

        public AddContentTypeBaseItem(ScenarioContext context)//IWebDriver driver, ScenarioContext context)
        {
            _scenarioContext = context;
        }

        public AddContentTypeBaseItem AddNew(string name)
        {
            try
            {
                // navigate to /Admin/ContentTypes/List
                _scenarioContext.GetWebDriver().Navigate().GoToUrl("https://dfc-dev-stax-editor-as.azurewebsites.net/Admin/ContentTypes/List");
                // click on "Create new type"
                _scenarioContext.GetWebDriver().FindElement(By.Id("btnCreate")).Click();

                // enter DisplayName
                _scenarioContext.GetWebDriver().FindElement(By.Id("DisplayName")).Clear();
                _scenarioContext.GetWebDriver().FindElement(By.Id("DisplayName")).SendKeys(name);

                // enter TechnicalName ( not required as it autofills on entry to DisplayName
                //_scenarioContext.GetWebDriver().FindElement(By.Id("Name")).Clear();
                //_scenarioContext.GetWebDriver().FindElement(By.Id("Name")).SendKeys(name);
                _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[4]/button")).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                SelectPart("Title");
                SelectPart("Graph Sync");

               _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[3]/button")).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }

        private bool SelectPart( String partName)
        {
            try
            {
                _scenarioContext.GetWebDriver().FindElement(By.XPath("//label[@class='custom-control-label' and contains(text(),'" + partName + "')]")).Click();

            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool EditPart(String contentType, String partName)
        {
            try
            {
                var url = "https://dfc-dev-stax-editor-as.azurewebsites.net/Admin/ContentTypes/" + contentType + "/ContentParts/" + partName.Replace(" ", "") + "Part/Edit";
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(url);

            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public AddContentTypeBaseItem AddField( string contentType, string displayName, string fieldType)
        {
            try
            {
                // click Add button
                //_scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Add Field']")).Click();
                _scenarioContext.GetWebDriver().Navigate().GoToUrl("https://dfc-dev-stax-editor-as.azurewebsites.net/Admin/ContentTypes/AddFieldsTo/" + contentType + "?returnUrl=%2FAdmin%2FContentTypes%2FEdit%2F" + contentType);
          
                // enter name
                var textField = _scenarioContext.GetWebDriver().FindElement(By.Id("DisplayName"));
                textField.Clear();
                textField.SendKeys(displayName);

                // select radio button
                _scenarioContext.GetWebDriver().FindElement(By.XPath("//label[@class='custom-control-label' and contains(text(),'" + fieldType + "')]")).Click();

                // click Save button
               _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Save']")).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }

        public AddContentTypeBaseItem SaveChanges()
        {
            try
            {
                var webElement = _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Save']"));
                webElement.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }
    }
}
