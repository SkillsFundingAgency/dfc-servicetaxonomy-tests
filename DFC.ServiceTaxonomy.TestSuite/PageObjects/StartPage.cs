using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using DFC.ServiceTaxonomy.TestSuite.Context;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class StartPage
    {
        //private IWebDriver driver;
        //EnvironmentSettings env = new EnvironmentSettings();
        private EditorContext testContext;

        public StartPage(EditorContext context)
        {
            testContext = context;

        }
        public AddActivity NavigateToNewActivity()
        {
            testContext.GetWebDriver().Url = testContext.editorBaseUrl + "/Admin/Contents/ContentTypes/Activity/Create";
            return new AddActivity (testContext);
        }

    }
}
