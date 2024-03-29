﻿using System;
using System.Threading;

using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;

using OpenQA.Selenium;

using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    class AddEditPage : AddContentItemBase, IEditorContentItem
    {
        readonly ScenarioContext scenarioContext;

        public AddEditPage(ScenarioContext context) : base(context)
        {
            scenarioContext = context;
        }

        new private By GetLocator(String field)
        {
            return field switch
            {
                "RedirectLocations" => By.Id($"Page_RedirectLocations_Text"),
                "Description" => By.Id("Page_Description_Text"),
                "URL Name" => By.Id("PageLocationPart_UrlName"),
                _ => null,
            };
        }

        new public void SetFieldValue(string field, string value)
        {
            if (!EnterText(field, value, GetLocator(field)))
                base.SetFieldValue(field, value);
        }

        public bool SetBasePageLocation()
        {
            try
            {
                scenarioContext.GetWebDriver().ClickOnItem("Page_PageLocations_TermEntries_0__Selected");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set base page location - {e.Message}");
                return false;
            }
            return true;
        }

        public bool SetPageLocation(string location)
        {
            try
            {
                scenarioContext.GetWebDriver().FindElement(By.XPath("//label[@class='custom-control-label' and contains(text(),'" + location + "')]")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set page location - {e.Message}");
                return false;
            }
            return true;
        }

        public AddEditPage OpenWidgetMenu()
        {
            try
            {
                scenarioContext.GetWebDriver().WaitUntilElementFound(By.XPath("//button[@title='Add Widget']")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to open widget menu");
            }
            return this;
        }

        public bool AddHtmlItem(string htmlValue)
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                SelectTab("Content");
                OpenWidgetMenu();
                var element = driver.FindElement(By.LinkText("HTML"));
                element.Click();
                element = driver.WaitUntilElementFound(By.XPath("//label[contains(@for,'HtmlBodyPart_Html')]/..//div[@class='trumbowyg-editor']"));
                element.SendKeys(htmlValue);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to add HTML Item - {e.Message}");
                return false;
            }
            return true;
        }

        public bool AddSharedContentItem(string name)
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                SelectTab("Content");
                OpenWidgetMenu();
                var element = driver.FindElement(By.LinkText("HTML Shared"));
                element.Click();
                element = driver.WaitUntilElementFound(By.ClassName("multiselect__tags"));
                element.Click();
                element = driver.WaitUntilElementFound(By.ClassName("multiselect__input"));
                element.SendKeys(name);
                Thread.Sleep(500);
                //TODO use selenium wait
                element.SendKeys(Keys.Enter);



            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable add Shared Content item- {e.Message}");
                return false;
            }
            return true;
        }

        public bool AddSharedContentItemToExistingWidget(string name)
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                SelectTab("Content");
                var element = driver.WaitUntilElementFound(By.ClassName("multiselect__tags"));
                element.Click();
                element = driver.WaitUntilElementFound(By.ClassName("multiselect__input"));
                element.SendKeys(name);
                Thread.Sleep(500);
                //TODO use selenium wait
                element.SendKeys(Keys.Enter);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable add Shared Content item- {e.Message}");
                return false;
            }
            return true;
        }

        public bool InsertHtmlItem(int position = 0)
        {
            try
            {
                //todo
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set base page location - {e.Message}");
                return false;
            }
            return true;
        }

        public bool InsertSharedHtmlItem(int position)
        {
            try
            {
                //todo
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to set base page location - {e.Message}");
                return false;
            }
            return true;
        }

        public bool SetPublishLaterDate(DateTime dateTime)
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                var element = driver.FindElement(By.Id("PublishLaterPart_ScheduledPublishLocalDateTime"));
                element.SendKeys(dateTime.Day.ToString());
                element.SendKeys(dateTime.Month.ToString());
                element.SendKeys(dateTime.Year.ToString());
                element.SendKeys(Keys.Tab);
                element.SendKeys(dateTime.Hour.ToString());
                element.SendKeys(dateTime.Minute.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to publish later date - {e.Message}");
                return false;
            }
            return true;
        }

        public bool SetArchiveLaterDate(DateTime dateTime)
        {
            //todo
            return true;
        }

        public bool PublishLater()
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                driver.ClickButton("Publish Later");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to publish later - is the feature enabled? - {e.Message}");
                return false;
            }
            return true;
        }

        public bool ArchiveLater()
        {
            var driver = scenarioContext.GetWebDriver();
            try
            {
                driver.ClickButton("Archive Later");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to unpublish later - is the feature enabled? - {e.Message}");
                return false;
            }
            return true;
        }
    }
}
