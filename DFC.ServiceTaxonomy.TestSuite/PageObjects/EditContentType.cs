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
    class EditContentType : AddContentItemBase
    {

        //ScenarioContext _scenarioContext;

        public EditContentType(ScenarioContext context) : base(context)
        {
            _scenarioContext = context;
        }

        EditContentType OpenContentType( string contentTypeName)
        {
            string url = _scenarioContext.GetEnv().editorBaseUrl + "/Admin/ContentTypes/Edit/" + contentTypeName;
            try
            {
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(url);
            }
            catch { }
            return this;
        }

        bool ClickButton(IWebDriver driver,  string buttonText)
        {
            try
            {
                driver.FindElement(By.LinkText(buttonText)).Click();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public EditContentType DeleteContentType(string contentTypeName)
        {
            try
            {
                OpenContentType(contentTypeName);
                _scenarioContext.GetWebDriver().ClickButton("Delete");
                _scenarioContext.GetWebDriver().ClickButton("modalOkButton");
            }
            catch
            {}
            return this;
        }

  
    }
}

