﻿using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddLinkItem : AddContentItemBase, IEditorContentItem
    {
        private string _contentType;

        public AddLinkItem(ScenarioContext context) : base(context)
        {
        }

        new public AddLinkItem AsA(string type)
        {
            _contentType = type;
            return this;
        }

        private By getContentTypeSpecificLocator(String type, String field)
        {
            switch (field)
            {
                case "Url":
                    return By.Id( type + "_Link_Url");
                case "LinkText":
                    return By.Id( type + "_Link_Text");
                default:
                    return null;
            }
        }

        private By getLocator(String type, String field)
        {
            return (GetLocatorBase(field) ?? getContentTypeSpecificLocator( type, field));

        }

        public new void SetFieldValue(string type, string field, string value)
        {
            EnterText(field, value, getLocator(type, field));
        }

        public new void SetFieldValue( string field, string value)
        {
            EnterText(field, value, getLocator(_contentType, field));
        }
    }
}

