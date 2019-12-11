using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.Context;


namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class EditorsSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private EditorContext _editorContext;
        private LogonScreen _logonScreen;
        private StartPage _startPage;
        private AddActivity _addActivity;
        //private IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory);

        public EditorsSteps(ScenarioContext scenarioContext, EditorContext editorContext)
        {
            _scenarioContext = scenarioContext;
            _editorContext = editorContext;
        }

        [Given(@"I run this")]
        public void GivenIRunThis()
        {
        }

        [Given(@"run test")]
        public void GivenRunTest()
        {
            _logonScreen = new LogonScreen(_editorContext);
            _startPage = _logonScreen.SubmitLogonDetails();
            _addActivity = _startPage.NavigateToNewActivity();
            _addActivity.EnterAction("Test Action")
                        .EnterURI("Test URI");

        }
        
        
        
        





    }
}
