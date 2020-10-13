using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddEditPageLocation : AddContentItemBase, IEditorContentItem
    {
        private const string _contentType = "PageLocation";
        ScenarioContext scenarioContext;

        public AddEditPageLocation (ScenarioContext context) : base(context)
        {
            scenarioContext = context;
            
        }

        new private By getLocator( String field)
        {
           
            switch (field)
            {
                case "Breadcrumb":
                    return By.Id($"PageLocation_BreadcrumbText_Text");
                case "Path":
                    return By.Id("TitlePart_Title");
                default:
                    return null;
            }
        }

        new public void SetFieldValue( string field, string value)
        {
            try
            {
                EnterText(field, value, getLocator(field));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set field value {field} - {e.Message}");
            }
        }
     }
}
