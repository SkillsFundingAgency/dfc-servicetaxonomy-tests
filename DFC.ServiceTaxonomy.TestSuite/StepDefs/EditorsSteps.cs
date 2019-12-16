using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using Neo4j.Driver.V1;


namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class EditorsSteps
    {
        #region consts
        private const string cypher_activityByUri = "match(a:ncs__Activity { uri: { uri} }) return a.skos__prefLabel as activity, a.uri as uri";
        private const string keyGeneratedUri = "GeneratedURI";
        private const string keyEditorDescriptionField = "Title";
        #endregion

        private readonly ScenarioContext _scenarioContext;
        private LogonScreen _logonScreen;
        private StartPage _startPage;
        private AddActivity _addActivity;
        private ManageContent _manageContent;
        private ModalOKCancel _modalOkCancel;


        public EditorsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _logonScreen = new LogonScreen(scenarioContext);
            _startPage = new StartPage(scenarioContext);
            _addActivity = new AddActivity(scenarioContext);
            _manageContent = new ManageContent(scenarioContext);
            _modalOkCancel = new ModalOKCancel(scenarioContext);
        }

        #region given steps
        [Given(@"I logon to the editor")]
        public void GivenILogonToTheEditor()
        {

            _logonScreen.SubmitLogonDetails();
        }

        [Given(@"I Navigate to ""(.*)""")]
        public void GivenINavigateTo(string relativeUrl)
        {
            _startPage.NavigateTo( relativeUrl ) ;
        }
       
        [Given(@"I capture the generated URI")]
        public void GivenICaptureTheGeneratedURIGraph_UriId_Text()
        {
            _scenarioContext.Set( _addActivity.GetGeneratedURI(), keyGeneratedUri );
        }

        [Given(@"I Enter the following form data")]
        public void GivenIEnterTheFollowingFormData(Table table)
        {
            foreach (var item in table.Rows.First().Select((value, index) => new { value, index }))
            {
                if (item.index == 0)
                {
                    // store first field in scenario context
                    _scenarioContext.Set(item.value.Value, item.value.Key);
                }
                _addActivity.SetFieldValue(item.value.Key, item.value.Value); ;
             }
        }

        [Given(@"I search for the ""(.*)""")]
        public void GivenISearchForThe(string searchTerm)
        {
            _manageContent.FindItem(_scenarioContext.Get<string>( searchTerm ));
        }

        [Given(@"I select the first item that is found")]
        public void GivenISelectTheFirstItemThatIsFound()
        {
            _manageContent.SelectFirstItem();
        }
        #endregion
        #region when steps
        [When(@"I publish the item")]
        public void WhenIPublishTheItem()
        {
            _addActivity.PublishActivity();
        }

        [When(@"I delete the item")]
        public void WhenIDeleteTheItem()
        {
            _manageContent.DeleteFirstItem();
        }


        [When(@"I confirm the delete action")]
        public void WhenIConfirmTheDeleteAction()
        {
            _modalOkCancel.ConfirmDelete();
        }
        #endregion
        #region then steps
        [Then(@"the add action completes succesfully")]
        public void ThenTheAddActionCompletesSuccesfully()
        {
            _addActivity.ConfirmSuccess().Should().BeTrue();
        }

        [Then(@"the edit action completes succesfully")]
        public void ThenTheEditActionCompletesSuccesfully()
        {
            _manageContent.ConfirmPublishedSuccessfully().Should().BeTrue();
        }

        [Then(@"the delete action completes succesfully")]
        public void ThenTheDeleteActionCompletesSuccesfully()
        {
            _manageContent.ConfirmRemovedSuccessfully().Should().BeTrue();
        }

        [Then(@"the new data is present in the Graph databases")]
        public void ThenTheNewDataIsPresentInTheGraphDatabases()
        {
            var statementTemplate = cypher_activityByUri;
            var statementParameters = new Dictionary<string, object> { { "uri", _scenarioContext.Get<string>( keyGeneratedUri ) } };

            Neo4JHelper neo4JHelper = new Neo4JHelper();
            neo4JHelper.connect(_scenarioContext.GetEnv().neo4JUrl,
                                _scenarioContext.GetEnv().neo4JUid,
                                _scenarioContext.GetEnv().neo4JPassword);

            var activities = neo4JHelper.GetResultsList<Activity>(statementTemplate, statementParameters);
            activities.Count.Should().Be(1);
            activities[0].activity.Should().Be(_scenarioContext.Get<string>(keyEditorDescriptionField));
            activities[0].uri.Should().Be(_scenarioContext.Get<string>( keyGeneratedUri ));

        }

        [Then(@"the data is not present in the Graph databases")]
        public void ThenTheDataIsNotPresentInTheGraphDatabases()
        {
            var statementTemplate = cypher_activityByUri;
            var statementParameters = new Dictionary<string, object> { { "uri", _scenarioContext.Get<string>( keyGeneratedUri ) } };


            Neo4JHelper neo4JHelper = new Neo4JHelper();
            neo4JHelper.connect(_scenarioContext.GetEnv().neo4JUrl,
                                _scenarioContext.GetEnv().neo4JUid,
                                _scenarioContext.GetEnv().neo4JPassword);

            var activities = neo4JHelper.GetResultsList<Activity>(statementTemplate, statementParameters);
            activities.Count.Should().Be(0);
        }

        #endregion
    }   
}
