using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using OrchardCore.Entities;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class RecipeSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private OrchardCore.Entities.DefaultIdGenerator _IdGenerator;


        public RecipeSteps(ScenarioContext context, FeatureContext fContext)
        {
            _scenarioContext = context;
            _featureContext = fContext;
            _IdGenerator = new OrchardCore.Entities.DefaultIdGenerator();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Given(@"I prepare the test recipes")]
        public void GivenIPrepareTheTestRecipes()
        {
            // get prefix or set if not set
            string prefix;

            if (_scenarioContext.ContainsKey("prefix"))
            {
                prefix = (string)_scenarioContext["prefix"];
            }
            else
            {
                prefix = RandomString(5);
                _scenarioContext["prefix"] = prefix;
                //todo change to constant
                _scenarioContext["prefixField"] = "skos__prefLabel";
                //_scenarioContext["prefixField"] = p0;
            }
            //create subdirectory
            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/{prefix}");

            //copy recipefiles into folder
            DirectoryInfo diSource = new DirectoryInfo($"{Directory.GetCurrentDirectory()}/recipes/testdata");
            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = diSource.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(di.FullName, file.Name);
                file.CopyTo(temppath, false);
            }

            // replace tokens
            _scenarioContext.ReplaceTokensInDirectory($"{Directory.GetCurrentDirectory()}/{prefix}", "@PREFIX@", (string)_scenarioContext["prefix"]);

            _scenarioContext.ReplaceTokensInDirectory($"{Directory.GetCurrentDirectory()}/{prefix}", "__PREFIX__", (string)_scenarioContext["prefix"]);
            // replace ID tokens
            int id = 1;
            //todo sort out a way of detecting last token while not stopping on gaps
            while (id < 800)
            {
                _scenarioContext.ReplaceTokensInDirectory($"{Directory.GetCurrentDirectory()}/{prefix}", $"TESTCONTENTID_{id}\"", $"{_IdGenerator.GenerateUniqueId()}\"");
                id++;
            }
            Console.WriteLine($"Finished replacing tokens.{id} distinct content ids detected");
        }

        [Given(@"I load the test recipes")]
        public void GivenILoadTheTestRecipes()
        {
            string prefix = (string)_scenarioContext["prefix"];
            string path = $"{Directory.GetCurrentDirectory()}/{prefix}";

            DirectoryInfo diSource = new DirectoryInfo(path);
            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = diSource.GetFiles();
            foreach (FileInfo file in files)
            {
                // do import
                LoadRecipeFile(file.FullName);
            }

            // delete directory
            diSource.Delete(true);

        }

        public void LoadRecipeFile(string p0)
        {
            string error = "";
            try
            { 
                Console.WriteLine($"Loading recipe file: {p0}");
                _scenarioContext.GetWebDriver().Navigate().GoToUrl(_scenarioContext.GetEnv().editorBaseUrl + "/Admin/OrchardCore.Deployment/Import/Index");
                var webElement = _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/form/nav/ul/li/input"));
                webElement.SendKeys(p0);
                var item = _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Import']"));
                item.Click();

                var serverError = _scenarioContext.GetWebDriver().FindElements(By.XPath(@"//*[@id='content']/div/fieldset/h2"));
                var otherError = _scenarioContext.GetWebDriver().FindElements(By.XPath("/html/body/div[1]/div[3]/form/nav/ul/li/input"));
                var successMessage = _scenarioContext.GetWebDriver().FindElements(By.XPath("/html/body/div[1]/div[3]/div"));

                if (serverError.Count > 0)
                {

                }
                /*else if (otherError.Count > 0)
                {
                    Console.WriteLine("Server Error: " + otherError[0].Text);
                }*/
                else if (successMessage.Count > 0)
                {
                    Console.WriteLine("Page returned message: " + successMessage[0].Text);
                }
                else
                {
                    Console.WriteLine("Unhandled situation");
                    //throw new Exception("Unhandled situation");
                }

            }
            catch (Exception e)
            {
                error = e.Message;
                Console.WriteLine(e);
            }
            Console.WriteLine("Finished import");
        }


    }
}
