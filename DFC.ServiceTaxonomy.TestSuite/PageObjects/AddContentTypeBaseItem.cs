﻿using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    public class AddContentTypeBaseItem
    {
        protected ScenarioContext _scenarioContext;

        public AddContentTypeBaseItem(ScenarioContext context)//IWebDriver driver, ScenarioContext context)
        {
            _scenarioContext = context;
        }

        public AddContentTypeBaseItem AddNew(string name, string[] additionalParts = null)
        {
            try
            {
                // navigate to /Admin/ContentTypes/List
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(_scenarioContext.GetEnv().editorBaseUrl + "/Admin/ContentTypes/List");
                // click on "Create new type"
                _scenarioContext.GetWebDriver().FindElement(By.Id("btnCreate")).Click();

                // enter DisplayName
                _scenarioContext.GetWebDriver().FindElement(By.Id("DisplayName")).Clear();
                _scenarioContext.GetWebDriver().FindElement(By.Id("DisplayName")).SendKeys(name);

                // enter TechnicalName ( not required as it autofills on entry to DisplayName
                //_scenarioContext.GetWebDriver().FindElement(By.Id("Name")).Clear();
                //_scenarioContext.GetWebDriver().FindElement(By.Id("Name")).SendKeys(name);
                _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[4]/button")).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create new content type called {name}.\nException: {e.message}");
            }
            Console.WriteLine($"new content type created called {name}");
            try
            {
                SelectPart("Title");
                SelectPart("Graph Sync");

                if (additionalParts != null)
                {
                    foreach (var item in additionalParts)
                    {
                        SelectPart(item);
                    }
                }
                _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[3]/button")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add default parts to {name}.\nException: {e.message}");
            }
            Console.WriteLine($"default parts added to {name}");


            return this;
        }



        private bool SelectPart( String partName)
        {
            try
            {
                _scenarioContext.GetWebDriver().FindElement(By.XPath("//label[@class='custom-control-label' and contains(text(),'" + partName + "')]")).Click();

            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool EditPart(String contentType, String partName)
        {
            try
            {
                var url = _scenarioContext.GetEnv().editorBaseUrl + "/Admin/ContentTypes/" + contentType + "/ContentParts/" + partName.Replace(" ", "") + "Part/Edit";
               
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(url);

            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool EditField(string contentType, string FieldName)
        {
            try
            {
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(_scenarioContext.GetEnv().editorBaseUrl + "/Admin/ContentParts/" + contentType + "/Fields/" + FieldName + "/Edit?returnUrl=%2FAdmin%2FContentTypes%2FEdit%2F" + contentType);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        //ContentParts/testtype/Fields/testbool/Edit?returnUrl=%2FAdmin%2FContentTypes%2FEdit%2Ftesttype
        //ContentTypes/testtype/ContentParts/TitlePart/Edit
        //public bool EditItem(string contentType, string itemType, string itemName)
        //{
        //    try
        //    {
        //        var url = _scenarioContext.GetEnv().editorBaseUrl + "/Admin/ContentTypes/" + contentType + "/ContentParts/" + itemName.Replace(" ", "") + "Part/Edit";

        //        _scenarioContext.GetWebDriver().Navigate().GoToUrl(url);

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return true;
        //}


        public AddContentTypeBaseItem AddField( string contentType, string displayName, string fieldType, string editorType = "")
        {
            try
            {
                // click Add button
                //_scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Add Field']")).Click();
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(_scenarioContext.GetEnv().editorBaseUrl + "/Admin/ContentTypes/AddFieldsTo/" + contentType + "?returnUrl=%2FAdmin%2FContentTypes%2FEdit%2F" + contentType);
          
                // enter name
                var textField = _scenarioContext.GetWebDriver().FindElement(By.Id("DisplayName"));
                textField.Clear();
                textField.SendKeys(displayName);

                // select radio button
                _scenarioContext.GetWebDriver().FindElement(By.XPath("//label[@class='custom-control-label' and contains(text(),'" + fieldType + "')]")).Click();

                // click Save button
               _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Save']")).Click();

                if (editorType.Length > 0)
                {
                    // also set the editor type
                    SetFieldEditorType(contentType, displayName, editorType);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }

        public AddContentTypeBaseItem SetFieldEditorType ( string contentType, string displayName, string editorType)
        {

            //https://dfc-sit-stax-editor-as.azurewebsites.net/Admin/ContentParts/TestContentPicker1/Fields/Description/Edit?returnUrl=%2FAdmin%2FContentTypes%2FEdit%2FTestContentPicker1
            try
            {
                // click Add button
                //_scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Add Field']")).Click();
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(_scenarioContext.GetEnv().editorBaseUrl + "/Admin/ContentParts/" + contentType +"/Fields/" + displayName + "/Edit?returnUrl=%2FAdmin%2FContentTypes%2FEdit%2F" + contentType);
                _scenarioContext.GetWebDriver().SelectDropListItemById("field-editor-select", editorType);
                _scenarioContext.GetWebDriver().ClickButton("Save");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        public AddContentTypeBaseItem SelectBagContent (string parentContentType, string contentType)
        {
            try
            {
                EditPart(parentContentType, "Bag");
                _scenarioContext.GetWebDriver().FindElement(By.XPath("//label[@class='custom-control-label' and contains(text(),'" + contentType + "')]")).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        public AddContentTypeBaseItem SelectContentPickerItems( string contentType)
        {
            try
            {
                _scenarioContext.GetWebDriver().FindElement(By.XPath("//label[@class='custom-control-label' and contains(text(),'" + contentType + "')]")).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        public AddContentTypeBaseItem SelectContentPickerAllowMultipleItems(string contentType, string ItemName)
        {
            string id = contentType + "_" + ItemName + "_ContentPickerFieldSettingsDriver_Multiple";

//TestCollectionOfTypes_PickContent_ContentPickerFieldSettingsDriver_Multiple
            try
            {
                var cb = _scenarioContext.GetWebDriver().FindElement(By.Id(id));
       
                cb.SendKeys(" ");

                                            

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }



        public AddContentTypeBaseItem SaveChanges()
        {
            try
            {
                var webElement = _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Save']"));
                webElement.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }
    }
}