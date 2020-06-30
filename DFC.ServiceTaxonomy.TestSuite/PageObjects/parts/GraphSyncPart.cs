using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class GraphSyncPart
    {
        protected ScenarioContext _scenarioContext;

        public GraphSyncPart(ScenarioContext context)//IWebDriver driver, ScenarioContext context)
        {
            _scenarioContext = context;
        }



        public By GetLocator(string contentType, string lookup)
        {
            switch(lookup)
            {
                case "RelationshipType":
                    return By.Id(contentType +"_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_BagPartContentItemRelationshipType");
                case "NodeNameTransform":
                    return By.Id(contentType + "_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_NodeNameTransform");
                case "PropertyNameTransform":
                    return By.Id(contentType + "_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_PropertyNameTransform");
                case "CreateRelationshipType":
                    return By.Id(contentType + "_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_CreateRelationshipType");
                case "IDPropertyName":
                    return By.Id(contentType + "_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_IdPropertyName");
                case "GenerateIDValue":
                    return By.Id(contentType + "_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_GenerateIdPropertyValue");
            }
            return null;
        }
        public GraphSyncPart SetFieldValues(string contentType, Dictionary<string, string> fieldValues)
        {
            foreach (var item in fieldValues)
            {
                try
                {
                    var webElement = _scenarioContext.GetWebDriver().FindElement(GetLocator(contentType, item.Key));
                    webElement.Clear();
                    webElement.SendKeys(item.Value);
                }
                catch ( Exception e)
                {
                    Console.WriteLine($"Error setting field value\n{ e.Message}");

                }
            }
            return this;
        }

        public GraphSyncPart SelectSyncType(string syncType = "NCS")
        {

            try
            {
                _scenarioContext.GetWebDriver().SelectDropListItemById("ddlSelectSettings", syncType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
     
           return this;
        }
        public GraphSyncPart SetDisplayIdCheckbox(string contentType, bool selected = true)
        {

            try
            {
                var element = _scenarioContext.GetWebDriver().FindElement(By.Id($"{contentType}_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_DisplayId"));
                if (element.Selected != selected)
                {

                    Actions builder = new Actions(_scenarioContext.GetWebDriver());
                    var mouseUp = builder.MoveToElement(element)
                                             .Click()
                                             .Build(); ;
                    mouseUp.Perform();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        

        public GraphSyncPart SaveChanges()
        {
            try
            {
               var webElement = _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[contains(text(),'Save')]"));
               webElement.Click();
            }
            catch (Exception e)
            {
               Console.WriteLine(e);
            }
            return this;
        }
        //public GraphSyncPart SetRelationshipType( string relationshipType)
        //{
        //    var item = _scenarioContext.GetWebDriver().FindElement(By.Id("MyTestPart11_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_BagPartContentItemRelationshipType"));
        //    item.Clear();
        //    item.SendKeys(relationshipType);
        //    return this;
        //}

        //public GraphSyncPart SetNodeNameTransform(string relationshipType)
        //{
        //    var item = _scenarioContext.GetWebDriver().FindElement(By.Id("MyTestPart11_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_BagPartContentItemRelationshipType"));
        //    item.Clear();
        //    item.SendKeys(relationshipType);
        //    return this;
        //}
        //public GraphSyncPart SetPropertyNameTransform(string relationshipType)
        //{
        //    var item = _scenarioContext.GetWebDriver().FindElement(By.Id("MyTestPart11_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_PropertyNameTransform"));
        //    item.Clear();
        //    item.SendKeys(relationshipType);
        //    return this;
        //}

        //public GraphSyncPart SetCreateRelationshipType(string relationshipType)
        //{
        //    var item = _scenarioContext.GetWebDriver().FindElement(By.Id("MyTestPart11_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_BagPartContentItemRelationshipType"));
        //    item.Clear();
        //    item.SendKeys(relationshipType);
        //    return this;
        //}

        //public GraphSyncPart SetIDPropertyName(string relationshipType)
        //{
        //    var item = _scenarioContext.GetWebDriver().FindElement(By.Id("MyTestPart11_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_BagPartContentItemRelationshipType"));
        //    item.Clear();
        //    item.SendKeys(relationshipType);
        //    return this;
        //}

        //public GraphSyncPart SetGenerateIDValue(string relationshipType)
        //{
        //    var item = _scenarioContext.GetWebDriver().FindElement(By.Id("MyTestPart11_GraphSyncPart_GraphSyncPartSettingsDisplayDriver_BagPartContentItemRelationshipType"));
        //    item.Clear();
        //    item.SendKeys(relationshipType);
        //    return this;
        //}


        public GraphSyncPart SetPreexistingNode(bool value)
        {
            return this;
        }

        public GraphSyncPart SetIncludeInIndex(bool value)
        {
            return this;
        }

    }
}


