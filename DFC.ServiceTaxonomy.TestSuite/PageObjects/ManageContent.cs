using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects 
{
    class ManageContent// : PageBase
    {
        #region constants
        const string remove = "removed";
        const string publish = "published";

        #endregion
        ScenarioContext _scenarioContext;

        public ManageContent(ScenarioContext context)// : base(context)
        {
            _scenarioContext = context;
        }

        public ManageContent FindItem( string title)
        {
            _scenarioContext.GetWebDriver().Navigate().GoToUrl(_scenarioContext.GetEnv().editorBaseUrl + "/Admin/Contents/ContentItems");
            _scenarioContext.GetWebDriver().FindElement(By.Id("Options_DisplayText")).Clear();
            _scenarioContext.GetWebDriver().FindElement(By.Id("Options_DisplayText")).SendKeys(title);
            _scenarioContext.GetWebDriver().FindElement(By.Id("Options_DisplayText")).SendKeys(Keys.Return);
            return this;
        }

        public ManageContent EditItem(string title)
        {
            FindItem(title);
            _scenarioContext.GetWebDriver().ClickButton("Edit");
            return this;
        }


        public ManageContent DeleteAllItemsOfType(string type)
        {
            string typeViewUrl = _scenarioContext.GetEnv().editorBaseUrl + "/Admin/Contents/ContentItems?Options.SelectedContentType=" + type;
            try
            {
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(typeViewUrl);
            }
            catch (Exception e)
            {
                throw e;
            }

            var check = _scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()='The page could not be found.']"));
            if (check.Count > 0)
            {
                // not items found
                return this;

            }

            bool done = false;
            while (!done)
            {
                try
                {
                    DeleteFirstItem();
                }
                catch
                {
                    done = true;
                }
            }

            // check they've all gone
            try
            {
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(typeViewUrl);
            }
            catch (Exception e)
            {
                throw e;
            }
            check = _scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()='The page could not be found.']"));
            if (check.Count == 0)
            {
                throw new Exception("Unexpected items found of type:" + type);

            }
            return this;
        }


        public ManageContent SelectFirstItem()
        {
            try
            {
                // should just get first Edit button in list
                _scenarioContext.GetWebDriver().ClickButton("Edit");
                //_scenarioContext.GetWebDriver().FindElement(By.ClassName("list-group-item"))
                //                           .FindElement(By.LinkText("Edit"))
                //                           .Click();

            }
            catch
            {

            }

            return this;
        }

        public ManageContent DeleteFirstItem()
        {

            try
            {
                var actionButtons = _scenarioContext.GetWebDriver().FindElements(By.CssSelector(".btn-secondary"));
                _scenarioContext.GetWebDriver().ClickButton(".btn-secondary");
                _scenarioContext.GetWebDriver().ClickButton("Delete");
                _scenarioContext.GetWebDriver().ClickButton("modalOkButton");

                if (! ConfirmRemovedSuccessfully() )
                {
                    throw new Exception("Unable to confirm the item has been removed");
                }
            }
            catch ( Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }

        public bool ConfirmRemovedSuccessfully()
        {
            return ConfirmActionSuccess(remove);
        }

        public bool ConfirmPublishedSuccessfully()
        {
            return ConfirmActionSuccess(publish);
        }

        public bool ConfirmActionSuccess(string action)
        {
            bool returnValue = false;
            try
            {
                var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'has been " + action + ".')]]"));
                returnValue = ( elements.Count == 1 );
            }
            catch
            {

            }
            return returnValue;
        }


    }
}
      