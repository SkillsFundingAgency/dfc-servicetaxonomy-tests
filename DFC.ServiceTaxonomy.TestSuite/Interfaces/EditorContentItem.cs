using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite.Interfaces
{
    public interface IEditorContentItem
    {
        By GetLocator(String field);
        void SetFieldValue(string type, string field, string value);
        void SetFieldValue( string field, string value);
    }
}
