using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
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
        private const string cypher_DayToDayTaskByUri = "match(a:ncs__DayToDayTask { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Description as Description";
        private const string cypher_OtherRequirementByUri = "match(a:ncs__OtherRequirement { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Description as Description";
        private const string cypher_FurtherInfoByUri = "match(a:ncs__FurtherInfo { uri: { uri} }) return a.skos__prefLabel as Title, a.ncs__Link_url as Url, a.ncs__Link_text as LinkText";
        private const string cypher_UniverstyLinkByUri = "match(a:ncs__UniversityLink { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Url as Description, a.ncs__Link_url as Url, a.ncs__Link_text as LinkText";
        private const string cypher_GenericItemWithDescriptionByUri = "match(a:ncs__@CONTENTTYPE@ { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Description as Description";
        private const string cypher_GenericItemWithTextByUri = "match(a:ncs__@CONTENTTYPE@ { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Text as Text";

        private const string keyGeneratedUri = "GeneratedURI";
        private const string keyEditorDescriptionField = "Title";
        #endregion

        private readonly ScenarioContext _scenarioContext;
        private LogonScreen _logonScreen;
        private StartPage _startPage;
        private AddActivity _addActivity;
        private AddContentItemBase _addContentItemBase;
        private AddFurtherInfo _addFurtherInfo;
        private ManageContent _manageContent;
        private ModalOKCancel _modalOkCancel;


        public EditorsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _logonScreen = new LogonScreen(scenarioContext);
            _startPage = new StartPage(scenarioContext);
            _addActivity = new AddActivity(scenarioContext);
            _addContentItemBase = new AddContentItemBase(scenarioContext);
            _addFurtherInfo = new AddFurtherInfo(scenarioContext);
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

        [Given(@"I Enter the following form data for ""(.*)""")]
        public void GivenIEnterTheFollowingFormDataFor(string p0, Table table)
        {
           // AddContentItemBase addItem = _addContentItemBase;
            IEditorContentItem iAddItem = _addContentItemBase;


            switch (p0)
            {
                case "DayToDayTask":
                    _scenarioContext["ResponseType"] = typeof(DayToDayTask);
                    _scenarioContext["CypherQuery"] = cypher_DayToDayTaskByUri;
                    //addItem = _addDayToDayTask;
                    break;
                case "FurtherInfo":
                    _scenarioContext["ResponseType"] = typeof(FurtherInfo);
                    _scenarioContext["CypherQuery"] = cypher_FurtherInfoByUri;
                    iAddItem = _addFurtherInfo;
                    break;
                case "UniversityLink":
                    _scenarioContext["ResponseType"] = typeof(UniversityLink);
                    _scenarioContext["CypherQuery"] = cypher_UniverstyLinkByUri;
                    iAddItem = _addFurtherInfo;
                    break;
                case "RequirementsPrefix":
                case "Restriction":
                case "UniversityRequirement":
                    _scenarioContext["ResponseType"] = typeof(GenericContent);
                    _scenarioContext["CypherQuery"] = cypher_GenericItemWithTextByUri.Replace("@CONTENTTYPE@", p0);
                    break;
                default:
                    _scenarioContext["ResponseType"] = typeof(GenericContent);
                    _scenarioContext["CypherQuery"] = cypher_GenericItemWithDescriptionByUri.Replace("@CONTENTTYPE@", p0);
                    //addItem = _addDayToDayTask;
                    break;
            }


            Dictionary<string, string> vars = new Dictionary<string, string>();
            foreach (var item in table.Rows.First().Select((value, index) => new { value, index }))
            {
                if (item.index == 0)
                {
                    // store first field in scenario context
                    _scenarioContext.Set(item.value.Value, item.value.Key);
                }
                vars.Add(item.value.Key, item.value.Value);
                iAddItem.SetFieldValue(item.value.Key, item.value.Value);
            }
            _scenarioContext["RequestVariables"] = vars;


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
            var statementTemplate = (string)_scenarioContext["CypherQuery"]; 
            var statementParameters = new Dictionary<string, object> { { "uri", _scenarioContext.Get<string>( keyGeneratedUri ) } };

            Neo4JHelper neo4JHelper = new Neo4JHelper();
            neo4JHelper.connect(_scenarioContext.GetEnv().neo4JUrl,
                                _scenarioContext.GetEnv().neo4JUid,
                                _scenarioContext.GetEnv().neo4JPassword);
            Type requiredType = (Type)_scenarioContext["ResponseType"];
           // var dayToDayTask = neo4JHelper.GetResultsList<DayToDayTask> (statementTemplate, statementParameters);
            var returnObject = neo4JHelper.GetResultsList(requiredType, statementTemplate, statementParameters);

            object first = returnObject[0];
            //first.
            //string test = returnObject[0]["Uri"]
;

         //   var typedObject = Convert.ChangeType(returnObject, requiredType);
         ////   Convert.ChangeType(item, type)
         //   dayToDayTask.Count.Should().Be(1);

            Dictionary<string, string> vars = ( Dictionary<string, string> )_scenarioContext["RequestVariables"];

            foreach ( var var in vars)
            {
                Type myType = returnObject[0].GetType();
                PropertyInfo propertyInfo = myType.GetProperty(var.Key);
                string varValue = (string)propertyInfo.GetValue(returnObject[0], null);
                string rawValue = Regex.Replace(varValue, @"<[^>]*>", String.Empty);
                
                var.Value.Should().Be(rawValue);

            }
            
            //foreach ( var item in activities)
            //{
            //    item. = "2";
            //    foreach ( var property in item.Get)
            //    {

            //    }
            //}
            //dayToDayTask[0].Description.Should().Be("<p>" + _scenarioContext.Get<string>(keyEditorDescriptionField +"</p>"));
            //dayToDayTask[0].Uri.Should().Be(_scenarioContext.Get<string>( keyGeneratedUri ));

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
