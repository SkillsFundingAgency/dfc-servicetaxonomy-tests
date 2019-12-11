using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using DFC.ServiceTaxonomy.TestSuite.Context;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    [Binding]
    public sealed class setupContext
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario( EditorContext  editorContext)
        {
            editorContext.SetupWebDriver(new ChromeDriver(Environment.CurrentDirectory));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
