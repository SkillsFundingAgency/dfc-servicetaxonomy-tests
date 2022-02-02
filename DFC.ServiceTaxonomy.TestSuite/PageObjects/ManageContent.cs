using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class ManageContent
    {
        #region constants
        const string remove = "removed";
        const string publish = "published";
        const string unpublish = "unpublished";
        const string save = "saved";
        const string actionPlaceHolder = "{action}";
        const string confirmationMessage = "has been {action}.";
        const string confirmationMessageClone = "Successfully cloned.";

        #endregion
        readonly ScenarioContext _scenarioContext;
        JobProfilesPage _jobProfilesPage;

        public ManageContent(ScenarioContext context)
        {
            _scenarioContext = context;
            _jobProfilesPage = new JobProfilesPage(context);
        }

        public ManageContent FindItem(string title)
        {
            _scenarioContext.GetWebDriver().Navigate().GoToUrl(_scenarioContext.GetEnv().EditorBaseUrl + "/Admin/Contents/ContentItems");
            _scenarioContext.GetWebDriver().FindElement(By.Id("Options_SearchText")).Clear();
            _scenarioContext.GetWebDriver().FindElement(By.Id("Options_SearchText")).SendKeys(title);
            _scenarioContext.GetWebDriver().FindElement(By.Id("Options_SearchText")).SendKeys(Keys.Return);
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
            string typeViewUrl = _scenarioContext.GetEnv().EditorBaseUrl + "/Admin/Contents/ContentItems?Options.SelectedContentType=" + type;
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

        public bool CheckOptionAvailableToFirstItem(string action)
        {
            try
            {
                _scenarioContext.GetWebDriver().ClickButton(".btn-secondary");
                _scenarioContext.GetWebDriver().FindElement(By.LinkText(action));
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                var esc = _scenarioContext.GetWebDriver().FindElements(By.CssSelector(".btn-secondary"));
                if (esc.Count > 0)
                {
                    esc[0].SendKeys(Keys.Escape);
                }
            }
            return true;
        }

        public ManageContent ActionFirstItem(string action)
        {
            try
            {
                //_scenarioContext.GetWebDriver().SelectButtonGroupClass("btn-group", 3);
                _scenarioContext.GetWebDriver().ClickButton(".btn-secondary.actions");
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
            //if (!ConfirmRemovedSuccessfully())
            //{
            //    throw new Exception("Unable to confirm the item has been removed");
            //}
            return this;
        }

        public ManageContent UnpublishFirstItem()
        {
            ActionFirstItem("Unpublish");
            _scenarioContext.GetWebDriver().ClickButton("modalOkButton");
            if (!ConfirmUnpublishedSuccessfully())
            {
                throw new Exception("Unable to confirm the item has been unpublished");
            }
            return this;
        }

        public ManageContent DiscardDraftOfFirstItem()
        {
            ActionFirstItem("Discard Draft");
            _scenarioContext.GetWebDriver().ClickButton("modalOkButton");
            if (!ConfirmDiscardedSuccessfully())
            {
                throw new Exception("Unable to confirm the draft item has been removed");
            }
            return this;
        }


        public ManageContent EditFirstItem()
        {
            try
            {
                // should just get first Edit button in list
                _scenarioContext.GetWebDriver().ClickButtonByCssSelector(".list-group-item .contentitem a");
                //_scenarioContext.GetWebDriver().ClickButton("Edit");
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to Edit first item. {e.Message}");
            }
            return this;
        }
        public bool ConfirmRemovedSuccessfully()
        {
            return ConfirmDisplayMessage(confirmationMessage.Replace(actionPlaceHolder, remove));
        }

        public bool ConfirmRemovalFailed()
        {
            return ConfirmDisplayMessage("could not be removed");
        }

        public bool ConfirmItemStillListed(string id)
        {
            var items = _scenarioContext.GetWebDriver().FindElements(By.XPath($"//a[contains(@href,'{id}')]"));
            return items.Count > 0;
        }

        public bool ConfirmUnpublishedSuccessfully()
        {
            return ConfirmDisplayMessage(confirmationMessage.Replace(actionPlaceHolder, unpublish));
        }

        public bool ConfirmDiscardedSuccessfully()
        {
            return ConfirmDisplayMessage(confirmationMessage.Replace(actionPlaceHolder, remove));
        }

        public bool ConfirmPublishedSuccessfully()
        {
            return ConfirmDisplayMessage(confirmationMessage.Replace(actionPlaceHolder, publish));
        }

        public bool ConfirmSavedSuccessfully()
        {
            return ConfirmDisplayMessage(confirmationMessage.Replace(actionPlaceHolder, save));
        }

        public bool ConfirmClonedSuccessfully()
        {
            return ConfirmDisplayMessage(confirmationMessageClone);
        }

        public bool ConfirmDraftDiscardedSuccessfully()
        {
            return ConfirmDisplayMessage(confirmationMessageClone);
        }

        public bool ConfirmDisplayMessage(string message)
        {
            bool returnValue = false;
            try
            {
                var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath($"//*[text()[contains(.,'{message}')]]"));
                returnValue = (elements.Count == 1);
            }
            catch
            { /**/ }
            return returnValue;
        }

        IList<IWebElement> all;
        int i;
        String[] allText;

        public string[] GetManageContentTitles()
        {
            all = _scenarioContext.GetWebDriver().FindElements(By.CssSelector(".contentitem.mr-2 > a"));
            String[] allText = new String[all.Count];
            i = 0;

            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

            return allText;
        }

        public bool ItemsCompare()
        {
            all = _scenarioContext.GetWebDriver().FindElements(By.CssSelector(".contentitem.mr-2 > a"));
            allText = new String[all.Count];
            int i = 0;
            bool titlePresent = false;

            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

            for (i = 0; i < all.Count; i++)
            {
                if (allText[i] == DigitalSkills.JobProfileTitle)
                {
                    titlePresent = true;
                }
                break;
            }

            return titlePresent;
        }

        public void CleanUpManageContent()
        {
            string locator = "Options_SearchText";

            IList<IWebElement> itemsCheckBox;

            do
            {
                _scenarioContext.GetWebDriver().FindElement(By.Id(locator)).Clear();
                _scenarioContext.GetWebDriver().FindElement(By.Id(locator)).SendKeys("_Auto_");
                _scenarioContext.GetWebDriver().FindElement(By.Id(locator)).SendKeys(Keys.Enter);
                Utilities.HoverClick(_scenarioContext.GetWebDriver(), _scenarioContext.GetWebDriver().FindElement(By.Id("select-all")));

                itemsCheckBox = _scenarioContext.GetWebDriver().FindElements(By.CssSelector("input[name='itemIds'] + label")).ToList();

                if (_scenarioContext.GetWebDriver().FindElement(By.Id("bulk-action-menu-button")).Displayed)
                {
                    Utilities.HoverClick(_scenarioContext.GetWebDriver(), _scenarioContext.GetWebDriver().FindElement(By.Id("bulk-action-menu-button")));
                    Utilities.HoverClick(_scenarioContext.GetWebDriver(), _scenarioContext.GetWebDriver().FindElement(By.XPath("//*[@class='dropdown-menu dropdown-menu-right show']/a[contains(text(), 'Delete')]")));
                    Utilities.Wait(_scenarioContext.GetWebDriver(), _scenarioContext.GetWebDriver().FindElement(By.Id("modalCancelButton")));
                    var bulkActionOk = _scenarioContext.GetWebDriver().FindElement(By.Id("modalOkButton"));
                    bulkActionOk.Click();
                }
                
            }
            while (itemsCheckBox.Count > 1);

            if(itemsCheckBox.Count == 1)
            {
                _scenarioContext.GetWebDriver().FindElement(By.XPath("(//div[@class='summary d-flex flex-column flex-md-row']//a)[1]")).Click();
                Utilities.Wait(_scenarioContext.GetWebDriver(), _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".item-label.d-flex.menu-configuration")));
                _jobProfilesPage.ClickDelete();
                _jobProfilesPage.ClickModalDelete();
            }
        }
    }
}

