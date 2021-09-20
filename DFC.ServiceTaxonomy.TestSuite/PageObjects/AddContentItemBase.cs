using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;

using OpenQA.Selenium;

using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddContentItemBase : IEditorContentItem
    {
        private const string emptyFieldValidationMessage = "A value is required for ";

        protected ScenarioContext _scenarioContext;
        protected bool _htmlView = false;
        private string _contentType;

        public AddContentItemBase(ScenarioContext context)//IWebDriver driver, ScenarioContext context)
        {
            _scenarioContext = context;
        }

        protected By GetLocatorBase(String field)
        {
            switch (field)
            {
                case "Title":
                    return By.Id("TitlePart_Title");
                case "Text":
                case "Description":
                    return By.ClassName("trumbowyg-editor");
                case "Uri":
                    return By.Id("GraphSyncPart_Text");
                default:
                    return null;
            }
        }

        protected By GetLocatorFromType(String contentType, String type, String field)
        {
            switch (type)
            {
                case "Text Field":
                    return By.Id(contentType + "_TextField_Text");
                case "Numeric Field":
                    return By.Id(contentType + "_ValueField_Value");
                case "Title":
                    return GetLocatorBase(field);
                default:
                    return null;
            }
        }

        public AddContentItemBase AsA(string type)
        {
            _contentType = type;
            return this;
        }

        public By GetLocator(string field)
        {
            return GetLocatorBase(field);
        }

        public By GetLocator(string contentType, string fieldType, string fieldName)
        {
            switch (fieldType)
            {
                case "Text":
                case "Html":
                    return By.Id($"{contentType}_{fieldName.Replace(" ", "")}_{fieldType}");
                default:
                    return GetLocatorBase(fieldName);
            }
        }

        public string GetGeneratedURI()
        {
            return _scenarioContext.GetWebDriver().FindElement(By.Id("GraphSyncPart_Text")).GetAttribute("value");
        }

        public string ContentItemIdFromUrl()
        {
            string pattern = @"[a-zA-Z0-9]{26}";
            string url = _scenarioContext.GetWebDriver().Url;
            Match m = Regex.Match(url, pattern);
            if (m.Success)
            {
                return m.Value;
            }
            return "";
        }


        public AddContentItemBase PublishActivity()
        {
            var button = _scenarioContext.GetWebDriver().FindElements(By.Name("submit.Publish"))?.FirstOrDefault(e => e.GetAttribute("value").Equals("submit.Publish"));
            if (button != null && button.Displayed is false)
            {
                _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".btn-success.dropdown-toggle.dropdown-toggle-split"))?.Click();

            }
            button?.Click();
            return this;
        }

        public AddContentItemBase SaveActivity()
        {
            if (_scenarioContext.GetWebDriver().Url.Contains("?returnUrl"))
            {
                _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".btn-info.dropdown-toggle.dropdown-toggle-split"))?.Click();
            }

            _scenarioContext.GetWebDriver().FindElements(By.Name("submit.Save"))?.FirstOrDefault(e => e.GetAttribute("value").Equals("submit.Save"))?.Click();
            return this;
        }

        public bool EnterText(string field, string value, By locator)
        {
            IWebElement item = null;
            try
            {
                if (_htmlView)
                {
                    item = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-viewHTML-button > svg"));
                    item.Click();
                }
                item = _scenarioContext.GetWebDriver().FindElement(locator);
                item.Click();
                item.Clear();
                item.SendKeys(value);
                if (_htmlView)
                {
                    item = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-viewHTML-button > svg"));
                    item.Click();
                    _htmlView = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public string GetFieldValue(string contentType, string fieldName)
        {
            //only currently works with base types
            string value = "";
            try
            {
                value = _scenarioContext.GetWebDriver().FindElement(GetLocatorBase(fieldName)).GetAttribute("value");
            }
            catch
            {
            }
            return value;

        }
        public string GetFieldValue(string contentType, string fieldType, string fieldName)
        {
            string value = "";
            try
            {
                value = _scenarioContext.GetWebDriver().FindElement(GetLocator(contentType, fieldType, fieldName)).GetAttribute("value");
            }
            catch
            {
            }
            return value;

        }

        public void SetFieldValue(string field, string value)//, Func <String, By> OverrideLocator)
        {
            EnterText(field, value, GetLocatorBase(field));
        }

        public void SetFieldValue(string type, string field, string value)//, Func <String, By> OverrideLocator)
        {
            EnterText(_contentType, value, GetLocatorBase(field));
        }

        public void SetFieldValueFromType(string contenType, string field, string value, string type)//, Func <String, By> OverrideLocator)
        {
            EnterText(field, value, GetLocatorFromType(contenType, type, field));
        }

        public bool ConfirmPublishSuccess()
        {
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'has been published.')]]"));
            return (elements.Count == 1);
        }

        public bool ConfirmSaveDraftSuccess()
        {
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath("//*[text()[contains(.,'has been saved.')]]"));
            return (elements.Count == 1);
        }

        public bool ConfirmEmptyFieldError(string field)
        {
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath($"//*[text()[contains(.,'{emptyFieldValidationMessage}{field}')]]"));
            return (elements.Count > 0);
        }

        public bool ConfirmMessageDisplayed(string message)
        {
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath($"//*[text()[contains(.,\"{message}\")]]"));
            return (elements.Count > 0);
        }

        public bool ConfirmEditorContainsHTML(string html)
        {
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath($"//*[contains(@class, \"{html}\")]"));
            return (elements.Count > 0);
        }

        public bool ConfirmEditorContainsMediaHTML(string p0)
        {
            var elements = _scenarioContext.GetWebDriver().FindElements(By.XPath($"//iframe[contains(@src, \"{p0}\")]"));
            return (elements.Count > 0);
        }

        public void InsertYoutubeLink(Dictionary<string, string> vars)
        {
            var imageButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-image-button"));
            imageButton.Click();

            var insertYoutubeLinkButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector($".trumbowyg-youtubeLink-dropdown-button"));
            insertYoutubeLinkButton.Click();

            var urlInput = _scenarioContext.GetWebDriver().FindElement(By.Name("url"));
            urlInput.SendKeys(vars["Url"]);
            var titleInput = _scenarioContext.GetWebDriver().FindElement(By.Name("title"));
            titleInput.SendKeys(vars["VidTitle"]);

            var confirm = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-modal-submit"));
            confirm.Click();
        }

        public void viewHTML()
        {
            var viewHTMLButton = _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[@title='View HTML']"));
            viewHTMLButton.Click();
        }

        public void SelectSectionBreak()
        {
            var sectionButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-sectionBreak-button"));
            sectionButton.Click();
            var sectionBreak = _scenarioContext.GetWebDriver().FindElement(By.CssSelector($".trumbowyg-defaultSectionBreak-dropdown-button"));
            sectionBreak.Click();
        }

        public void SelectNumbertList()
        {
            var numberList = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-numberList-button"));
            numberList.Click();
        }

        public void SelectBulletList()
        {
            var bulletList = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-bulletList-button"));
            bulletList.Click();
        }

        public void SelectList()
        {
            var list = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-list-button"));
            list.Click();
        }

        public void SelectFontWeight()
        {
            var boldButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-fontWeight-button"));
            boldButton.Click();
        }

        public void SelectFontSize(string size)
        {
            var fontSizeButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-fontSize-button"));
            fontSizeButton.Click();
            var fontSize = _scenarioContext.GetWebDriver().FindElement(By.CssSelector($".trumbowyg-fontSize_{size}-dropdown-button"));
            fontSize.Click();
        }

        public void SelectParagraph(string paragragh)
        {
            var paragrapghButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-paragraph-button"));
            paragrapghButton.Click();
            var optionButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector($".trumbowyg-paragraph_{paragragh}-dropdown-button"));
            optionButton.Click();
        }

        public void SelectHeading(string header)
        {
            var headingButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".trumbowyg-heading-button"));
            headingButton.Click();
            var headerButton = _scenarioContext.GetWebDriver().FindElement(By.CssSelector($".trumbowyg-{header}-button"));
            headerButton.Click();
        }

        public AddContentItemBase PublishAndContinueActivity()
        {
            _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".btn-success.dropdown-toggle")).Click();
            _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".publish-continue")).Click();
            return this;
        }

        public void EnterComment(string comment)
        {
            if (_scenarioContext.TryGetValue("contentType", out string value) && value.Equals("Page"))
            {
                SelectTab("Content");
                _scenarioContext.GetWebDriver().WaitUntilElementFound(By.Id("AuditTrailPart_Comment"));
            }
            var commentInput = _scenarioContext.GetWebDriver().FindElement(By.Id("AuditTrailPart_Comment"));
            commentInput.SendKeys(comment);
        }

        public void SelectTab(string tabName)
        {
            try
            {
                _scenarioContext.GetWebDriver().WaitUntilElementFound(By.XPath($"//a[text()='{tabName}']")).Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to select tab {tabName}- {e.Message}");
            }
        }

    }
}
