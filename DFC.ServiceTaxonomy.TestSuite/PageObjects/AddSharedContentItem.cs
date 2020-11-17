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
    class AddSharedContentItem : AddContentItemBase, IEditorContentItem
    {
        private const string _contentType = "SharedContent";
        public AddSharedContentItem(ScenarioContext context) : base(context)
        {
        }

        private By getContentTypeSpecificLocator(String type, String field)
        {
            _htmlView = false;
            switch (field)
            {
                case "CanonicalName":
                    return By.Id($"{type}_CanonicalName_Text");
                case "Content":
                    _htmlView = true;
                    return By.Id("SharedContent_Content_Html");
                    //return By.ClassName("trumbowyg-editor");
                default:
                    return null;
            }
        }

        private By getLocator(String type, String field)
        {
            return (GetLocatorBase(field) ?? getContentTypeSpecificLocator(type, field));

        }

        public new void SetFieldValue(string type, string field, string value)
        {
            EnterText(field, value, getLocator(type, field));
        }

        public new void SetFieldValue(string field, string value)
        {
            base.EnterText(field, value, getLocator(_contentType, field));
        }

    }
}
