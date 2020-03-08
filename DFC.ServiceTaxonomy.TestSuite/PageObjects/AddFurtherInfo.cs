using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddFurtherInfo : AddContentItemBase, IEditorContentItem
    {
        public AddFurtherInfo(ScenarioContext context) : base(context)
        {
        }

        private By getFurtherInfoLocator(String field)
        {
            switch (field)
            {
                case "Url":
                    return By.Id("FurtherInfo_Link_Url");
                case "LinkText":
                    return By.Id("FurtherInfo_Link_Text");
                default:
                    return null;
            }
        }

        private new By getLocator(String field)
        {
            return (getLocatorBase(field) ?? getFurtherInfoLocator(field));

        }

        public new void SetFieldValue(string field, string value)
        {
            EnterText(field, value, getLocator(field));
        }
    }
}

