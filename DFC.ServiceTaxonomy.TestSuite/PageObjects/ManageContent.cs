﻿using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects 
{
    class ManageContent// : PageBase
    {
        #region constants
        const string remove = "removed";
        const string publish = "published";
        const string save = "saved";
        const string actionPlaceHolder = "{action}";
        const string confirmationMessage = "has been {action}.";
        const string confirmationMessageClone = "Successfully cloned.";

        #endregion
        ScenarioContext _scenarioContext;

        public ManageContent(ScenarioContext context)
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

        public ManageContent ActionFirstItem( string action )
        {
            try
            {
                //_scenarioContext.GetWebDriver().SelectButtonGroupClass("btn-group", 3);
                _scenarioContext.GetWebDriver().ClickButton(".btn-secondary");
                _scenarioContext.GetWebDriver().ClickButton(action);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to {action} first item. {e.Message}");
            }
            return this;
        }

        public ManageContent PublishFirstItem()
        {
            return ActionFirstItem("Publish Draft");
        }

        public ManageContent CloneFirstItem()
        {
            return ActionFirstItem("Clone");
        }

        public ManageContent DeleteFirstItem()
        {
            ActionFirstItem("Delete");
            _scenarioContext.GetWebDriver().ClickButton("modalOkButton");
            if (!ConfirmRemovedSuccessfully())
            {
                throw new Exception("Unable to confirm the item has been removed");
            }
             return this;
        }

        public ManageContent EditFirstItem()
        {
            try
            {
                // should just get first Edit button in list
                _scenarioContext.GetWebDriver().ClickButton("Edit");
            }
            catch ( Exception e)
            {
                throw new Exception($"Unable to Edit first item. {e.Message}");
            }
            return this;
        }
        public bool ConfirmRemovedSuccessfully()
        {
            return ConfirmActionSuccess(confirmationMessage.Replace(actionPlaceHolder,remove));
        }

        public bool ConfirmPublishedSuccessfully()
        {
            return ConfirmActionSuccess(confirmationMessage.Replace(actionPlaceHolder, publish));
        }

        public bool ConfirmSavedSuccessfully()
        {
            return ConfirmActionSuccess(confirmationMessage.Replace(actionPlaceHolder, save));
        }

        public bool ConfirmClonedSuccessfully()
        {
            return ConfirmActionSuccess(confirmationMessageClone);
        }

        public bool ConfirmActionSuccess(string message)
        {
            bool returnValue = false;
            try
            {
                var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath($"//*[text()[contains(.,'{message}')]]"));
                returnValue = ( elements.Count == 1 );
            }
            catch
            {}
            return returnValue;
        }
    }
}
      