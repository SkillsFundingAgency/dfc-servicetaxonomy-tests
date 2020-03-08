using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Interfaces
{
    public interface IEditorContentItem
    {
        By getLocator(String field);
        void SetFieldValue(string field, string value);
    }
}
