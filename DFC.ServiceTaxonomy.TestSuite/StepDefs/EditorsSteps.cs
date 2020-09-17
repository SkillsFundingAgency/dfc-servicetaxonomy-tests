using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using Neo4j.Driver.V1;
using AngleSharp.Css.Dom;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    class RowItem
    {
        public string uri { get; set; }
        public string test_name { get; set; }
        public string test_description { get; set; }
    }

    [Binding]
    public sealed class EditorsSteps
    {
        #region consts
        private const string cypher_activityByUri = "match(a:Activity { uri: $uri }) return a.skos__prefLabel as Title, a.uri as uri";
        private const string cypher_DayToDayTaskByUri = "match(a:DayToDayTask { uri: $uri }) return a.skos__prefLabel as Title, a.uri as Uri, a.Description as Description";
        private const string cypher_OtherRequirementByUri = "match(a:OtherRequirement { uri: $uri }) return a.skos__prefLabel as Title, a.uri as Uri, a.Description as Description";
        private const string cypher_FurtherInfoByUri = "match(a:FurtherInfo { uri: $uri }) return a.skos__prefLabel as Title, a.Link_url as Url, a.Link_text as LinkText";
        private const string cypher_UniverstyLinkByUri = "match(a:UniversityLink { uri: $uri }) return a.skos__prefLabel as Title, a.uri as Uri, a.Url as Description, a.Link_url as Url, a.Link_text as LinkText";
        private const string cypher_SharedContentByUri = "match(a:SharedContent { uri: $uri }) return a.skos__prefLabel as Title, a.Content as Content";
        private const string cypher_GenericItemWithDescriptionByUri = "match(a:@CONTENTTYPE@ { uri: $uri }) return a.skos__prefLabel as Title, a.uri as Uri, a.Description as Description";
        private const string cypher_GenericItemWithTextByUri = "match(a:@CONTENTTYPE@ { uri: $uri }) return a.skos__prefLabel as Title, a.uri as Uri, a.Text as Text";
        private const string cypher_TestItem = "match(a:@CONTENTTYPE@ { uri: $uri }) return a.skos__prefLabel as Title, a.uri as Uri @FIELDLIST";

        private const string sql_ContentItemIdPlaceholder = "__ContentItemId__";
        private const string sql_ContentItemIndexes = "select * from dbo.contentitemindex a where a.ContentItemId = '__ContentItemId__' order by ModifiedUtc desc ";

        private const string keyGeneratedUri = "GeneratedURI";
        private const string keyEditorDescriptionField = "Title";

        private const string sql_ClearDownAllContentItemsOfType = 
                                                                @"begin transaction t1
                                                                select DocumentId
                                                                into #tmpdocids
                                                                from [dbo].[ContentItemIndex]
                                                                where contentType = '@CONTENTTYPE@';
                                                                delete from [dbo].[ContentItemIndex] where DocumentId in ( select DocumentId from #tmpdocids ) ;
                                                                delete from [dbo].Document where id in ( select DocumentId from #tmpdocids );
                                                                drop table #tmpdocids
                                                                commit transaction t1";
        #endregion

        private readonly ScenarioContext _scenarioContext;
        private LogonScreen _logonScreen;
        private StartPage _startPage;
        private AddContentItemBase _addContentItemBase;
        private AddLinkItem _addLinkItem;
        private AddSharedContentItem _addSharedContent;
        private ManageContent _manageContent;
        private ModalOKCancel _modalOkCancel;
        private AddContentTypeBaseItem _addContentType;
        private EditContentType _editContentType;
        private GraphSyncPart _GraphSyncPart;

        private readonly Dictionary<string, string> cypherQueries = new Dictionary<string, string>() {
    {
        "page_with_html",
        @"match (h:HTML) <-[hasHTML]- (p:Page) 
          where p.uri =  '__URI__' 
          return p.skos__prefLabel as skos__prefLabel ,h.htmlbody_Html as htmlbody_Html" 
    },
    {
        "page_with_shared_content",
        @"match (p:Page) -[hasHTMLShared]-> (h:HTMLShared) -[hasSharedContent]-> (s:SharedContent)
         where p.uri =  '__URI__' 
         return p.skos__prefLabel as skos__prefLabel, s.skos__prefLabel as sharedContent" 
    },
    {
        "page_with_two_shared_content_in_same_widget",
        @"match (s1:SharedContent) <-[r1:hasSharedContent]- (h1:HTMLShared) <-[r2:hasHHTMLShared]- (p:Page) -[r3:hasHTMLShared]-> (h2:HTMLShared) -[r4:hasSharedContent]-> (s2:SharedContent)
         where p.uri =  '__URI1__' 
         and s1.uri = '__URI2__'
         and s1.uri <> s2.uri
         and h1.uri = h2.uri
         return p.skos__prefLabel as skos__prefLabel, s1.skos__prefLabel as sharedContent1, s2.skos__prefLabel as sharedContent2"
    },
    {
        "number_of_shared_content_on_widget_on_page",
        @"match (s:SharedContent) <-[hasSharedContent]- (HTMLShared) <-[hasHTMLShared]- (p:Page) 
         where p.uri =  '__URI__' 
         return count (s) as count_of_sharedContent"
    },
    {
        "page_widget_with_two_shared_content",
        @"match (s1:SharedContent) <-[r1:hasSharedContent]- (h:HTMLShared) -[r2:hasSharedContent]-> (s2:SharedContent)
         where h.uri =  '__URI1__'
         and s1.uri = '__URI2__'
         and s2.uri = '__URI3__'
         return s1.skos__prefLabel as SharedContent1, s2.skos__prefLabel as SharedContent2"
    },
    {
        "get_sharedhtml_uri_for_page",
        @"match (p:Page) -[hasHTMLShared]-> (h:HTMLShared)
          where p.uri =  '__URI__'  return h.uri as uri" 
    },
    {   
        "page_with_wiget_only",
        @"match (p:Page) -[hasHTMLShared]-> (h:HTMLShared) 
          where p.uri =  '__URI__'  
          and not (h) --> (:SharedContent)
          return p.skos__prefLabel as skos__prefLabel"
    },
    {
        "shared_content_with_no_related_items",
        @"match (s:SharedContent)
          where s.uri =  '__URI__'  
          and not (s) --> (n)
          return s.skos__prefLabel as sharedContent"
    },
    {
        "page_by_uri",
        @"match (p:Page) 
         where p.uri =  '__URI__'  
         return count(p) as pages_found" },
    {
        "page_location",
        @"match (t1:Taxonomy) <-[hasPageLocationsTaxonomy]- (p:Page) -[r1:hasPageLocation]-> (l:PageLocation) <-[r2:hasPageLocation]- (t2:Taxonomy) 
         where p.uri =  '__URI__'  
         and t1.uri = t2.uri
         return l.skos__prefLabel as location"
    },
    {
        "widget_by_uri",
        @"match (s:HTMLShared) 
          where s.uri =  '__URI__'  
          return count(s) as widgets_found"
    },
    {
        "shared_content_by_uri",
        @"match (s:SharedContent) 
          where s.uri =  '__URI__'  
          return count(s) as shared_content_found"  
    },
    {
        "shared_content_title_by_uri",
        @"match (s:SharedContent) 
          where s.uri =  '__URI__'  
          return s.skos__prefLabel as sharedContent"
    },
    {
        "remove_relationship_to_widget",
        @"match (n:Page) -[r]-> (s:HTMLShared) 
          where n.uri =  '__URI__' 
          detach delete(r)
          return n.skos__prefLabel as skos__prefLabel"
    },
    {
        "remove_widget",
        @"match (n:Page) --> (s:HTMLShared) 
          where n.uri =  '__URI__' 
          detach delete(s)
          return n.skos__prefLabel as skos__prefLabel"
    },
    {
        "remove_properties_from_page_to_widget_relationship",
        @"match (n:Page) -[r]-> (s:HTMLShared) 
          where n.uri =  '__URI__' 
          remove r.Alignment, r.Ordinal, r.Size
          return r.Alignment as alignment, r.Ordinal as ordinal, r.Size as size"
    },
    {
        "check_properties_for_page_to_widget_relationship",
        @"match (n:Page) -[r]-> (s:HTMLShared) 
          where n.uri =  '__URI__' 
          return r.Alignment as alignment, r.Ordinal as ordinal, r.Size as size"
    },
        {
        "check_for_additional_properties_on_page_to_widget_relationship",
        @"match (n:Page) -[r]-> (s:HTMLShared) 
          where n.uri =  '__URI__' 
          return r.Alignment as alignment, r.Ordinal as ordinal, r.Size as size, r.Additional as additional"
    },
    {
        "update_properties_for_page_to_widget_relationship",
        @"match (n:Page) -[r]-> (s:HTMLShared) 
          where n.uri =  '__URI__' 
          set r.Alignment = 'xxx'
          set r.Ordinal= 'yyy'
          set r.Size = 'zzz'
          return r.Alignment as alignment, r.Ordinal as ordinal, r.Size as size"
    },
    {
        "add_property_to_page_to_widget_relationship",
        @"match (n:Page) -[r]-> (s:HTMLShared) 
          where n.uri =  '__URI__' 
          set r.Additional = 'xxx'
          return r.Alignment as alignment, r.Ordinal as ordinal, r.Size as size, r.Additional as additional"
    }
                                                        };
        

        public EditorsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _logonScreen = new LogonScreen(scenarioContext);
            _startPage = new StartPage(scenarioContext);
            _addContentItemBase = new AddContentItemBase(scenarioContext);
            _addLinkItem = new AddLinkItem(scenarioContext);
            _addSharedContent = new AddSharedContentItem(scenarioContext);
            _manageContent = new ManageContent(scenarioContext);
            _modalOkCancel = new ModalOKCancel(scenarioContext);
            _addContentType = new AddContentTypeBaseItem(scenarioContext);
            _GraphSyncPart = new GraphSyncPart(scenarioContext);
            _editContentType = new EditContentType(scenarioContext);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private IEditorContentItem SetContentType(string contentType)
        {
            _scenarioContext[constants.ContentType] = contentType;
            switch (contentType)
            {
                case "DayToDayTask":
                    _scenarioContext[constants.responseType] = typeof(DayToDayTask);
                    _scenarioContext[constants.cypherQuery] = cypher_DayToDayTaskByUri;
                    return _addContentItemBase;
                case "FurtherInfo":
                    _scenarioContext[constants.responseType] = typeof(FurtherInfo);
                    _scenarioContext[constants.cypherQuery] = cypher_FurtherInfoByUri;
                    return _addLinkItem;
                case "Activity":
                    _scenarioContext[constants.responseType] = typeof(DFC.ServiceTaxonomy.TestSuite.Models.Activity);
                    _scenarioContext[constants.cypherQuery] = cypher_activityByUri;
                    return _addLinkItem;
                case "UniversityLink":
                    _scenarioContext[constants.responseType] = typeof(UniversityLink);
                    _scenarioContext[constants.cypherQuery] = cypher_UniverstyLinkByUri;
                    return _addLinkItem;
                case "RequirementsPrefix":
                case "UniversityRequirement":
                    _scenarioContext[constants.responseType] = typeof(GenericContent);
                    _scenarioContext[constants.cypherQuery] = cypher_GenericItemWithTextByUri.Replace("@CONTENTTYPE@", contentType);
                    return _addContentItemBase;
                case "SharedContent":
                    _scenarioContext[constants.responseType] = typeof(SharedContent);
                    _scenarioContext[constants.cypherQuery] = cypher_SharedContentByUri;
                    return _addSharedContent;
                case "Restriction":
                default:
                    _scenarioContext[constants.responseType] = typeof(GenericContent);
                    _scenarioContext[constants.cypherQuery] = cypher_GenericItemWithDescriptionByUri.Replace("@CONTENTTYPE@", contentType);
                    return _addContentItemBase;
            }
        }

        #region given steps

        [Given(@"I set up a data prefix for ""(.*)""")]
        public void GivenISetUpADataPrefixFor(string p0)
        {
            _scenarioContext[constants.prefix] = RandomString(5) + "_";
            _scenarioContext[constants.prefixField] = p0;
            _scenarioContext.StoreToken("__PREFIX__", (string)_scenarioContext[constants.prefix]);
        }

        [Given(@"I get the recipe files ready")]
        public void GivenIGetTheRecipeFilesReady()
        {
            if (_scenarioContext.ContainsKey(constants.prefix))
            {
                _scenarioContext.ReplaceTokensInDirectory(Directory.GetCurrentDirectory() + "/Recipes/" ,"@PREFIX@",(string)_scenarioContext[constants.prefix] );
            }
        }

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
            _scenarioContext.StoreUri(_addContentItemBase.GetGeneratedURI());
            
        }

        [Given(@"I capture the generated URI and tag it ""(.*)""")]
        public void GivenICaptureTheGeneratedURIGraphAndTagIt_UriId_Text(string tag)
        {
            _scenarioContext.StoreUri(_addContentItemBase.GetGeneratedURI(), tag);

        }

        [Given(@"I set the content type to be ""(.*)""")]
        public void GivenISetTheContentTypeToBe(string p0)
        {
            SetContentType(p0);
        }


        [Given(@"I record the new documentId")]
        public void GivenIRecordTheNewDocumentId()
        {
            _scenarioContext.GetEnv().sqlServerChecksEnabled.Should().BeTrue("Because sql server checks must be enabled for the step to execute");
            
            string displayName = (string)_scenarioContext[constants.Title];
            string contentType = (string)_scenarioContext[constants.ContentType];
            string prefix =  (string)_scenarioContext[constants.prefix];

            // get initial record count
            var result = _scenarioContext.GetSQLConnection().GetFieldValueFromRecord("ContentItemId", "ContentItemIndex", $"DisplayText = '{(displayName.StartsWith(prefix) ? string.Empty : prefix)}{displayName}' and ContentType = '{contentType}'");
            _scenarioContext.CloseSQLConnection();
            _scenarioContext.StoreRecordId(result);
        }

        [Given(@"I Enter the following form data")]
        public void GivenIEnterTheFollowingFormData(Table table)
        {
            string contentType = (string)_scenarioContext[constants.ContentType];
            string cypher = "match(a:@CONTENTTYPE@ { uri: $uri }) return a.skos__prefLabel as Title, a.uri as Uri";
            //_scenarioContext[constants.responseType] = typeof(DayToDayTask);

            Dictionary<string, string> expectedData = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                _addContentItemBase.SetFieldValueFromType(contentType, row[0], row[1], row[2]);
                if (row[0] != "Title")
                {
                    cypher += ", a." + row[0] + " as " + row[0];
                }
                expectedData.Add(row[0], row[1]);
            }
            _scenarioContext[constants.cypherQuery] = cypher.Replace("@CONTENTTYPE@", contentType);
            _scenarioContext[constants.responseType] = typeof(TestContent);
            //_scenarioContext[constants.requestVariables] = expectedData;
            _scenarioContext.SetEditorFields(expectedData);
        }

        [Given(@"I allow multiple items to be selected")]
        public void GivenIAllowMultipleItemsToBeSelected()
        {
            string contentType = (string)_scenarioContext[constants.ContentType];
            string FieldName = (string)_scenarioContext[constants.FieldName];
            _addContentType.SelectContentPickerAllowMultipleItems(contentType, FieldName);
        }

        [Given(@"I save the draft item")]
        public void GivenISaveTheDraftItem()
        {
            string id = _addContentItemBase.ContentItemIdFromUrl();
            _addContentItemBase.SaveActivity();

            if (id.Length == 0)
            {
                id = _addContentItemBase.ContentItemIdFromUrl();
            }
            if (id.Length > 0 )
            {
                _scenarioContext.StoreContentItemId(id);

                if (_scenarioContext.GetEnv().sqlServerChecksEnabled)
                {
                    var sqlInstance = _scenarioContext.GetSQLConnection();
                    _scenarioContext.StoreContentItemIndexList(sqlInstance.ExecuteObject<ContentItemIndexRow>(sql_ContentItemIndexes.Replace(sql_ContentItemIdPlaceholder, id)).ToList());
                    _scenarioContext.CloseSQLConnection();
                }
            }
        }

        [Then(@"the values displayed in the editor match")]
        public void ThenTheValuesDisplayedInTheEditorMatch(Table table)
        {
            string contentType = _scenarioContext.ContainsKey(constants.ContentType) ? (string)_scenarioContext[constants.ContentType] : "";
            foreach (var row in table.Rows)
            {
               foreach (var item in row)
                {
                    string newValue = item.Value;
                    if (_scenarioContext.ContainsKey(constants.prefix) && item.Key.Equals("Title") )
                    {
                        newValue = (string)_scenarioContext[constants.prefix] + newValue;
                    }
                    newValue.Should().Be(_editContentType.GetFieldValue( contentType,  item.Key));
                }
            }
        }

        [Then(@"the values displayed in the editor match the following values and types")]
        public void ThenTheValuesDisplayedInTheEditorMatchTheFollowingValuesAndTypes(Table table)
        {
            string contentType = _scenarioContext.ContainsKey(constants.ContentType) ? (string)_scenarioContext[constants.ContentType] : "";
            Dictionary<string, string> vars = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                string value = _editContentType.GetFieldValue(contentType,row[1], row[0]);
                value.Should().Be(row[2]);
                vars.Add(row[0], row[2]);
            }
            //_scenarioContext[constants.requestVariables] = vars;
            _scenarioContext.SetEditorFields(vars);
        }




        [Then(@"the editor field ""(.*)"" matches")]
        public void ThenTheEditorFieldMatches(string p0, string multilineText)
        {
            Dictionary<string, string> vars = _scenarioContext.ContainsKey(constants.requestVariables) ?  (Dictionary<string, string>)_scenarioContext[constants.requestVariables] : new Dictionary<string, string>();
            string contentType = _scenarioContext.ContainsKey(constants.ContentType) ? (string)_scenarioContext[constants.ContentType] : "";
            
            multilineText.Should().Be(_editContentType.GetFieldValue(contentType,"Html",p0));

            vars.Add(p0, multilineText);
            _scenarioContext.SetEditorFields(vars, true);
//            _scenarioContext[constants.requestVariables] = vars;
        }


        [Given(@"I Enter the following form data for ""(.*)""")]
        public void GivenIEnterTheFollowingFormDataFor(string p0, Table table)
        {
            IEditorContentItem iAddItem = SetContentType(p0);
            Dictionary<string, string> vars = new Dictionary<string, string>();
            foreach (var item in table.Rows.First().Select((value, index) => new { value, index }))
            {
                string newValue = item.value.Value;
                if (item.index == 0)
                {
                    newValue = ( _scenarioContext.ContainsKey(constants.prefix) && newValue.Length > 0 ? _scenarioContext[constants.prefix] : "" ) + newValue;
                    // store first field in scenario context
                    _scenarioContext.Set(newValue, item.value.Key);
                }
                vars.Add(item.value.Key, newValue);
                iAddItem.SetFieldValue(p0, item.value.Key, newValue);
            }
            _scenarioContext.SetEditorFields(vars);
            //_scenarioContext[constants.requestVariables] = vars;
        }

        [Given(@"I search for the ""(.*)""")]
        public void GivenISearchForThe(string searchTerm)
        {
            _manageContent.FindItem(_scenarioContext.Get<string>( searchTerm ));
        }

        [Given(@"I search for the text ""(.*)""")]
        public void GivenISearchForTheText(string searchTerm)
        {
            _manageContent.FindItem(searchTerm);
        }

        [Given(@"I select the first item that is found")]
        public void GivenISelectTheFirstItemThatIsFound()
        {
            _manageContent.EditFirstItem();
            _scenarioContext.StoreContentItemId(_addContentItemBase.ContentItemIdFromUrl());
        }

        [Given(@"I confirm the ""(.*)"" option is not available for the first item")]
        public void GivenIConfirmTheOptionIsNotAvailableForTheFirstItem(string p0)
        {
            _manageContent.CheckOptionAvailableToFirstItem(p0).Should().BeFalse($"Because {p0} was unexpectedly found in the action list");
        }

        [Given(@"I confirm the ""(.*)"" option is available for the first item")]
        public void GivenIConfirmTheOptionIsAvailableForTheFirstItem(string p0)
        {
            _manageContent.CheckOptionAvailableToFirstItem(p0).Should().BeTrue($"Because {p0} was unexpectedly not found in the action list");
        }

        //content type
        [Given(@"I add a new contentType called ""(.*)""")]
        public void GivenIAddANewContentTypeCalled(string p0 )
        {
            // navigate to /Admin/ContentTypes/List
            _scenarioContext[constants.ContentType] = p0;
            _addContentType.AddNew(p0);
 
        }

        [Given(@"I add a new graph contentType called ""(.*)""")]
        public void GivenIAddANewGraphContentTypeCalled(string p0)
        {
            _scenarioContext[constants.ContentType] = p0;
            _addContentType.AddNew(p0);

            // now add graph sync item with default settings
            GivenIEditThePart("Graph Sync");
            _GraphSyncPart.SelectSyncType();
          //  _GraphSyncPart.SetFieldValues(p0,_scenarioContext.GetGraphSyncPartSettings());
            _GraphSyncPart.SaveChanges();
        }

        [Given(@"I add a new graph contentType with bag called ""(.*)""")]
        public void GivenIAddANewGraphContentTypeWithBagCalled(string p0, Table table)
        {
            _scenarioContext[constants.ContentType] = p0;
            var stringArray = new string[] { "Bag" };
            _addContentType.AddNew(p0, stringArray);

            // edit bag part and select content type from table
            foreach (var row in table.Rows)
            {
                _addContentType.SelectBagContent(p0, row[0]);
            }
            _addContentType.SaveChanges();

            // now add graph sync item with default settings
            GivenIEditThePart("Graph Sync");
            _GraphSyncPart.SetFieldValues(p0, _scenarioContext.GetGraphSyncPartSettings());
            _GraphSyncPart.SaveChanges();
        }

        [Given(@"I select the following items from the displayed list")]
        public void GivenISelectTheFollowingItemsFromTheDisplayedList(Table table)
        {
            string contentType = (string)_scenarioContext[constants.ContentType];
      
            foreach (var row in table.Rows)
            {
                _addContentType.SelectContentPickerItems( row[0]);
            }
            _addContentType.SaveChanges();
        }

        //content type
        [Given(@"I edit the ""(.*)"" part")]
        public void GivenIEditThePart(string p0)
        {
            string contentType = (string)_scenarioContext[constants.ContentType];
            _addContentType.EditPart(contentType, p0);
        }

        [Given(@"I edit the ""(.*)"" field")]
        public void GivenIEditTheField(string p0)
        {
            string contentType = (string)_scenarioContext[constants.ContentType];
            _addContentType.EditField(contentType, p0);
            _scenarioContext[constants.FieldName] = p0;
        }

        //content type
        [Given(@"I try to delete content type ""(.*)""")]
        public void GivenITryToDeleteContentType(string p0)
        {
            _editContentType.DeleteContentType(p0);
        }

        //content item
        [Given(@"I delete any items of type ""(.*)""")]
        public void GivenIDeleteAnyItemsOfType(string p0)
        {
            _manageContent.DeleteAllItemsOfType(p0);
        }

        [Given(@"I set the following field values")]
        public void GivenISetTheFollowingFieldValues(Table table)
        {
            string contentType = (string)_scenarioContext[constants.ContentType];
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            _GraphSyncPart.SetFieldValues(contentType, dictionary);
        }

        [Given(@"I save the edited part")]
        public void GivenISaveTheEditedPart()
        {
            _GraphSyncPart.SaveChanges();
        }

        [Given(@"I click the Display Id checkbox")]
        public void GivenIClickTheDisplayIdCheckbox()
        {
            string contentType = (string)_scenarioContext[constants.ContentType];
            _GraphSyncPart.SetDisplayIdCheckbox(contentType);
        }


        [Given(@"I save the contentItem")]
        public void GivenISaveTheContentItem()
        {
            _addContentType.SaveChanges();
        }

        [Given(@"I add the following fields")]
        public void GivenIAddTheFollowingFields(Table table)
        {
            string contentType = (string)_scenarioContext[constants.ContentType];
            foreach (var row in table.Rows)
            {
                _addContentType.AddField(contentType, row[0], row[1], ( row.Count > 2 && row[2].Length>0? row[2] : null ) );
            }
        }

        [Given(@"I add a bag part containing the following content types")]
        public void GivenIAddABagPartContainingTheFollowingContentTypes(Table table)
        {
        //    _addContentType.AddPart("Bag");
            ScenarioContext.Current.Pending();
        }

        [Given(@"I pick content")]
        public void GivenIPickContent(Table table)
        {
            string prefix = (string)_scenarioContext[constants.prefix];
            foreach (var row in table.Rows)
            {
                _scenarioContext.GetWebDriver().SelectDropListItemByClass("multiselect__input", prefix + row[0]);
            }
        }

        [Given(@"I replace tokens in and then run the following graph update statement")]
        public void GivenIReplaceTokensInAndThenRunTheFollowingGraphUpdateStatement(string multilineText)
        {
            string token = "";
            string replaceString = "";
            string cypherStatement = multilineText;
            for (int i = 0; i < _scenarioContext.GetNumberOfStoredUris(); i++)
            {
                token = "@URI" + (i + 1) + "@";
                replaceString = _scenarioContext.GetUri(i);
                cypherStatement = cypherStatement.Replace(token, replaceString);

            }
            //TODO draft / publish graph
            _scenarioContext.GetGraphConnection(constants.publish).ExecuteTableQuery(cypherStatement, null);
        }

        [Given(@"Load the file ""(.*)""")]
        public void GivenLoadTheFile(string p0)
        {
            string error = "";
            try
            {
                _scenarioContext.GetWebDriver().Navigate().GoToUrl( _scenarioContext.GetEnv().editorBaseUrl +  "/Admin/OrchardCore.Deployment/Import/Index");
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


        [Given(@"I load recipe file ""(.*)""")]
        public void GivenILoadRecipeFile(string p0)
        {
            GivenINavigateTo("/Admin/DeploymentPlan/Import/Index");
            GivenLoadTheFile(Directory.GetCurrentDirectory() + "/Recipes/" + p0);
            //GivenIImportRecipesFromTheFile(Directory.GetCurrentDirectory() +"/" +p0);
        }


        [Given(@"I import recipes from the file ""(.*)""")]
        public void GivenIImportRecipesFromTheFile(string p0)
        {
            int counter = 0;
            string line;
            string filename;
            int recordCount = 0;
            bool fileInfoRow = true;
            Dictionary<string, int> tallies = new Dictionary<string, int>();
            string path = @"F:\temp\output.log";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("record_type,filesize,neo_record_count,elapsed_time,average_processing_time,status");
                }
            }

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"F:\temp\" + p0);
           
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith('#'))
                {
                    // have reached end of file section
                    fileInfoRow = false;
                    break;
                }

                if (fileInfoRow)
                {
                    filename = line.Split(':')[0];
                    if (line.Split(':').Count() > 1)
                    {
                        int.TryParse(line.Split(':')[1], out recordCount);
                    }
                    ImportRecipeFile(@"F:\temp\" + filename, recordCount, tallies);
                }
                //System.Console.WriteLine(line);
                counter++;
                if ( counter > 40)
                {
                  counter = 0;
                }
                Thread.Sleep(720000);
            }

            file.Close();
            Console.WriteLine("There were {0} lines.", counter);

        }

        [Given(@"I select the ""(.*)"" option for the first item that is found")]
        public void GivenISelectTheOptionFirstItemThatIsFound(string p0)
        {
            switch (p0.ToLower())
            {
                case "publish":
                    _manageContent.PublishFirstItem();
                    break;
                case "clone":
                    _manageContent.CloneFirstItem();
                    break;
                case "delete":
                    _manageContent.DeleteFirstItem();
                    break;
                case "unpublish":
                    _manageContent.UnpublishFirstItem();
                    break;
                case "discard draft":
                    _manageContent.DiscardDraftOfFirstItem();
                    break;
                default:
                    throw new Exception($"Action first item in list - Unsupported operation: {p0}");
            }
            
        }


        public string TransformTableName( string source)
        {
            string fileName = "";

            switch ( source )
            {
                case "JobCategories":
                    fileName = "JobCategory";
                    break;
                case "RequirementsPrefixes":
                    fileName = "RequirementsPrefix";
                    break;
                case "SocCodes":
                    fileName = "SOCCode";
                    break;
                default:
                    fileName = source.Substring(0, source.Length - 1);
                    break;
            }
            return fileName;
        }

        public int ImportRecipeFile(string filename, int recordCount, Dictionary<string, int> tallies)
        {
            _scenarioContext.GetEnv().sqlServerChecksEnabled.Should().BeTrue("Because sql server checks are required for this function");

            string path = @"F:\temp\output.log";
            int returnStatus = 0;
            Stopwatch timer = new Stopwatch();
            bool done = false;
            string error = "";
            string loadMessage = "";
            int returnedAfterSeconds = 0;
            int verifiedSqlCountAfterSeconds = 0;

            //SQLServerHelper sqlInstance = new SQLServerHelper();
            //sqlInstance.SetConnection(_scenarioContext.GetEnv().sqlServerConnectionString);

            // get table name
            var pattern = "[a-zA-Z]+";
            Regex rgx = new Regex(pattern);
            var table = rgx.Matches(filename).First().Value; ;
            table = filename.Split('.')[1];
            table = rgx.Match(filename.Split('.')[1]).Value;
            table = TransformTableName(table);


            // get initial record count
            var ds = _scenarioContext.GetSQLConnection().GetRecordCount("ContentItemIndex", constants.ContentType, table);
            
            int startingSQLRecordCount = (int)ds;

            try
            {
                _scenarioContext.GetWebDriver().Navigate().GoToUrl( _scenarioContext.GetEnv().editorBaseUrl +  "/Admin/OrchardCore.Deployment/Import/Index");
                var webElement = _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/form/nav/ul/li/input"));
                webElement.SendKeys(filename);
                var item = _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[text()='Import']"));
                timer.Start();
                item.Click();

                var serverError = _scenarioContext.GetWebDriver().FindElements(By.XPath(@"//*[@id='content']/div/fieldset/h2"));
                var otherError = _scenarioContext.GetWebDriver().FindElements(By.XPath("/html/body/div[1]/div[3]/form/nav/ul/li/input"));
                var successMessage = _scenarioContext.GetWebDriver().FindElements(By.XPath("/html/body/div[1]/div[3]/div"));

                if (serverError.Count > 0)
                {
                    loadMessage = "Page returned error: " + serverError[0].Text;
                    returnStatus = 1;
                }
                /*else if (otherError.Count > 0)
                {
                    Console.WriteLine("Server Error: " + otherError[0].Text);
                }*/
                else if (successMessage.Count > 0)
                {
                    loadMessage = "Page returned message: " + successMessage[0].Text;
                    returnStatus = 0;
                }
                else
                {
                    loadMessage = "Unhandled return";
                    returnStatus = 2;
                }
                returnedAfterSeconds = (int)timer.Elapsed.TotalSeconds;

            }
            catch (Exception e)
            {
                error = e.Message;
                loadMessage = "Error thrown: " + e.Message;
                Console.WriteLine(e);
            }

            // now need to check that / wait until all the records have arrived in sql database
            int tmMod = 5;
            int maxRecords = 0;
           
            if (recordCount == 0)
            {
                // dont have stats to perhaps just pause for x minutes??
                done = true;
            }
            int existingRows = 0;
            int discoveredRows = 0;
            if (tallies.ContainsKey(table))
            {
                existingRows = tallies[table];
            }
            while (!done)
            {
                ds = _scenarioContext.GetSQLConnection().GetRecordCount("ContentItemIndex", constants.ContentType, table);
                discoveredRows = (int)ds;
                if (ds.Equals(recordCount + startingSQLRecordCount))
                {
                    // we are done
                    done = true;
                }
                else
                {
                    if (timer.Elapsed.TotalSeconds > tmMod * recordCount)
                    {
                        // give up
                        done = true;
                        returnStatus = 3;
                    }
                    else
                    {
                        Thread.Sleep(30000);
                    }
                }
                
                if (ds > maxRecords)
                {
                    maxRecords = (int)ds;
                }

            }
            verifiedSqlCountAfterSeconds = (int) timer.Elapsed.TotalSeconds;
            _scenarioContext.CloseSQLConnection();
            // now check all neo4j records have been synced
            done = false;
            string cypher = "match(a:" + table + ") return count(a)";
            int neo4jRecordCount = 0;
            bool tmModExtended = false;
            while (!done)
            {
                try
                {
                    neo4jRecordCount = _scenarioContext.GetGraphConnection(constants.publish).ExecuteCountQuery(cypher, null);
                }
                catch 
                {
                    Thread.Sleep(120000);
                    tmMod = (tmModExtended ? tmMod : tmMod * 2 );
                    tmModExtended = true;
                    
                }
                
                if (neo4jRecordCount.Equals(recordCount + startingSQLRecordCount))
                {
                    // we are done
                    done = true;
                }
                else
                {
                    if (timer.Elapsed.TotalSeconds > tmMod * recordCount)
                    {
                        // give up
                        done = true;
                        returnStatus = 4;
                    }
                    else
                    {
                        Thread.Sleep(30000);
                    }
                }
            }
            timer.Stop();

            if (tallies.ContainsKey(table))
            {
                int newTally = tallies[table];
                newTally += recordCount;
                tallies[table] = newTally;
            }
            else
            {
                tallies.Add(table, maxRecords);
            }

            Console.WriteLine("File: " + filename);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Expected records: " + recordCount);
            Console.WriteLine("Discovered records: " + maxRecords);
            Console.WriteLine("Page return: " + loadMessage);
            Console.WriteLine("Page return after : " + returnedAfterSeconds);
            Console.WriteLine("Verified SQL Records after : " + verifiedSqlCountAfterSeconds);
            Console.WriteLine("Elapsed Time: " + timer.Elapsed.TotalSeconds);
            Console.WriteLine("-----------------------------------");

            using (StreamWriter sw = File.AppendText(path))
            {
                // sw.WriteLine("record_type,filesize,elapsed_time,status");
                sw.WriteLine(filename +", " + recordCount + ", " + neo4jRecordCount + ", " + timer.Elapsed.TotalSeconds + ", " + (double)((double)recordCount/ verifiedSqlCountAfterSeconds) + ", " + returnStatus);
            }
            return returnStatus;
        }



        #endregion
            #region when steps
        [When(@"I publish the item")]
        public void WhenIPublishTheItem()
        {
            string id = _addContentItemBase.ContentItemIdFromUrl();
            _addContentItemBase.PublishActivity();
            if (id.Length == 0)
            {
                id = _addContentItemBase.ContentItemIdFromUrl();
            }

            if (id.Length > 0)
            {
                _scenarioContext.StoreContentItemId(id);

                if (_scenarioContext.GetEnv().sqlServerChecksEnabled)
                {
                    var sqlInstance = _scenarioContext.GetSQLConnection();
                    _scenarioContext.StoreContentItemIndexList(
                                             sqlInstance.ExecuteObject<ContentItemIndexRow>(sql_ContentItemIndexes.Replace(sql_ContentItemIdPlaceholder, id)
                                                               ).ToList());
                    _scenarioContext.CloseSQLConnection();
                }
            }
        }

        [When(@"I save the draft item")]
        public void WhenISaveTheDraftItem()
        {
            string id = _addContentItemBase.ContentItemIdFromUrl();

            _addContentItemBase.SaveActivity();

            if (id.Length == 0)
            {
                id = _addContentItemBase.ContentItemIdFromUrl();
            }

            if (id.Length > 0)
            {
                _scenarioContext.StoreContentItemId(id);

                if (_scenarioContext.GetEnv().sqlServerChecksEnabled)
                {
                    var sqlInstance = _scenarioContext.GetSQLConnection();
                    _scenarioContext.StoreContentItemIndexList(
                                             sqlInstance.ExecuteObject<ContentItemIndexRow>(sql_ContentItemIndexes.Replace(sql_ContentItemIdPlaceholder, id)
                                                               ).ToList());
                    _scenarioContext.CloseSQLConnection();
                }
            }
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
        [Then(@"the item is published succesfully")]
        public void ThenTheItemIsPublishedSuccesfully()
        {
            _addContentItemBase.ConfirmPublishSuccess().Should().BeTrue();
        }

        [Then(@"the item is saved succesfully")]
        public void ThenTheAddTheItemIsSavedSuccesfully()
        {
            _addContentItemBase.ConfirmSaveDraftSuccess().Should().BeTrue();
        }


        [Then(@"an ""(.*)"" validation error is shown for ""(.*)""")]
        public void ThenAnValidationErrorIsShownFor(string validationType, string field)
        {
            switch (validationType)
            {
                case "EmptyField":
                    _addContentItemBase.ConfirmEmptyFieldError(field).Should().BeTrue();
                    break;
                default:
                    throw new Exception($"Unhandled validationType {validationType}");
            }
            //_scenarioContext.Remove(constants.requestVariables);
        }



        [Then(@"the edit action completes succesfully")]
        public void ThenTheEditActionCompletesSuccesfully()
        {
            _manageContent.ConfirmPublishedSuccessfully().Should().BeTrue();
        }

        [Then(@"the save action completes succesfully")]
        public void ThenTheSaveActionCompletesSuccesfully()
        {
            _manageContent.ConfirmSavedSuccessfully().Should().BeTrue();
        }

        [Then(@"the clone action completes succesfully")]
        public void ThenTheCloneActionCompletesSuccesfully()
        {
            _manageContent.ConfirmClonedSuccessfully().Should().BeTrue();
        }

        [Then(@"the unpublish action completes succesfully")]
        public void ThenTheUnpublishActionCompletesSuccesfully()
        {
            _manageContent.ConfirmUnpublishedSuccessfully().Should().BeTrue();
        }

        [Then(@"the discard action completes succesfully")]
        public void ThenTheDiscardActionCompletesSuccesfully()
        {
            _manageContent.ConfirmDiscardedSuccessfully().Should().BeTrue();
        }



        [Then(@"the delete action completes succesfully")]
        public void ThenTheDeleteActionCompletesSuccesfully()
        {
            _manageContent.ConfirmRemovedSuccessfully().Should().BeTrue();
        }

        [Then(@"the delete action could not be completed")]
        public void ThenTheDeleteActionCouldNotBeCompleted()
        {
            _manageContent.ConfirmRemovalFailed().Should().BeTrue();
        }


        public bool AreEqual(IDictionary<string, string> thisItems, IDictionary<string, string> otherItems)
        {
            if (thisItems.Count != otherItems.Count)
            {
                return false;
            }
            var thisKeys = thisItems.Keys;
            foreach (var key in thisKeys)
            {
                if (!(otherItems.TryGetValue(key, out var value) && string.Equals(thisItems[key], value, StringComparison.OrdinalIgnoreCase)) )
                {
                    return false;
                }
            }
            return true;
        }

        public string DictionaryToString(IDictionary<string, string> dict)
        {
            string output = "";
            foreach ( var kp in dict)
            {
                output += kp.Key + " - " + kp.Value + "\n";
            }
            return output;
        }

        [Then(@"the preview and publish graphs returns the expected results using the ""(.*)"" query")]
        public void ThenThePreviewAndPublishGraphsReturnsTheExpectedResultsUsingTheQuery(string p0, Table table)
        {
            ThenTheGraphMatchesTheExpectResultsUsingTheQuery(constants.preview, p0, table);
            ThenTheGraphMatchesTheExpectResultsUsingTheQuery(constants.publish, p0, table);
        }


        [Then(@"the ""(.*)"" graph matches the expect results using the ""(.*)"" query")]
        public void ThenTheGraphMatchesTheExpectResultsUsingTheQuery(string graphReference, string queryReference, Table expectedResults)
        {
            cypherQueries.Should().ContainKey(queryReference);
           // expectedResults = _scenarioContext.ReplaceTokensInTable(expectedResults);
            string uri = _scenarioContext.GetLatestUri().Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();

            if ( graphReference == constants.preview )
            {
                uri = _scenarioContext.ConvertUriToDraft(uri);
            }

            string message;
            bool match = matchGraphQueryResultsWithDictionary(cypherQueries[queryReference].Replace("__URI__", uri), expectedResults.SingleRowToDictionary(_scenarioContext), out message, graphReference);
            match.Should().BeTrue($"Because {message}");
        }

        [Then(@"the ""(.*)"" graph matches the expect results using the ""(.*)"" query and the ""(.*)"" Uri")]
        public void ThenTheGraphMatchesTheExpectResultsUsingTheQueryAndTheUri(string graphReference, string queryReference, string tag, Table expectedResults)
        {
            cypherQueries.Should().ContainKey(queryReference);
            // expectedResults = _scenarioContext.ReplaceTokensInTable(expectedResults);
            string uri = _scenarioContext.GetUri(tag).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();

            if (graphReference == constants.preview)
            {
                uri = _scenarioContext.ConvertUriToDraft(uri);
            }

            string message;
            bool match = matchGraphQueryResultsWithDictionary(cypherQueries[queryReference].Replace("__URI__", uri), expectedResults.SingleRowToDictionary(_scenarioContext), out message, graphReference);
            match.Should().BeTrue($"Because {message}");
        }

        [Then(@"within expected timescales the ""(.*)"" graph matches the expect results using the ""(.*)"" query and the ""(.*)"" Uri")]
        public void ThenWithinExpectedTimescalesTheGraphMatchesTheExpectResultsUsingTheQueryAndTheUri(string graphReference, string queryReference, string tag, Table expectedResults)
        {
            // get earliest time
            DateTime earliestTime = (DateTime)_scenarioContext["futureEvent"];
            // get latest time
            DateTime latestTime = (DateTime)_scenarioContext["futureEventLatest"];
            // get poll frequency
            TimeSpan pollFrequency = new TimeSpan(0, 0, 20);
            TimeSpan grace = new TimeSpan(0, 0, 5);

            cypherQueries.Should().ContainKey(queryReference);
            // expectedResults = _scenarioContext.ReplaceTokensInTable(expectedResults);
            string uri = _scenarioContext.GetUri(tag).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();

            if (graphReference == constants.preview)
            {
                uri = _scenarioContext.ConvertUriToDraft(uri);
            }

            bool success = false;
            while (!success && DateTime.Now < latestTime)
            {
                string message;
                bool match = matchGraphQueryResultsWithDictionary(cypherQueries[queryReference].Replace("__URI__", uri), expectedResults.SingleRowToDictionary(_scenarioContext), out message, graphReference);
                if (DateTime.Now < earliestTime - grace)
                {
                    match.Should().BeFalse("Because otherwise the event has been published too soon");
                }
                else if (match)
                {
                    success = true;
                    break;
                }
                Thread.Sleep(pollFrequency);
            }
            success.Should().BeTrue("Because otherwise the condition was not met within the expected timescale");
        }


        [Then(@"the ""(.*)"" graph matches the expect results using the ""(.*)"" query and the ""(.*)"" and ""(.*)"" Uris")]
        public void ThenTheGraphMatchesTheExpectResultsUsingTheQueryAndTheAndUris(string graphReference, string queryReference, string tag1, string tag2, Table expectedResults)
        {
            cypherQueries.Should().ContainKey(queryReference);
            // expectedResults = _scenarioContext.ReplaceTokensInTable(expectedResults);
            string uri1 = _scenarioContext.GetUri(tag1).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();
            string uri2 = _scenarioContext.GetUri(tag2).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();

            if (graphReference == constants.preview)
            {
                uri1 = _scenarioContext.ConvertUriToDraft(uri1);
                uri2 = _scenarioContext.ConvertUriToDraft(uri2);
            }

            string message;
            bool match = matchGraphQueryResultsWithDictionary(cypherQueries[queryReference].Replace("__URI1__", uri1).Replace("__URI2__", uri2), expectedResults.SingleRowToDictionary(_scenarioContext), out message, graphReference);
            match.Should().BeTrue($"Because {message}");
        }

        [Then(@"the ""(.*)"" graph matches the expect results using the ""(.*)"" query and ""(.*)"" and ""(.*)"" and ""(.*)"" Uris")]
        public void ThenTheGraphMatchesTheExpectResultsUsingTheQueryAndAndAndUris(string graphReference, string queryReference, string tag1, string tag2, string tag3, Table expectedResults)
        {
            cypherQueries.Should().ContainKey(queryReference);
            // expectedResults = _scenarioContext.ReplaceTokensInTable(expectedResults);
            string uri1 = _scenarioContext.GetUri(tag1).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();
            string uri2 = _scenarioContext.GetUri(tag2).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();
            string uri3 = _scenarioContext.GetUri(tag3).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();

            if (graphReference == constants.preview)
            {
                uri1 = _scenarioContext.ConvertUriToDraft(uri1);
                uri2 = _scenarioContext.ConvertUriToDraft(uri2);
                uri3 = _scenarioContext.ConvertUriToDraft(uri3);
            }

            string message;
            bool match = matchGraphQueryResultsWithDictionary(cypherQueries[queryReference].Replace("__URI1__", uri1).Replace("__URI2__", uri2).Replace("__URI3__",uri3), expectedResults.SingleRowToDictionary(_scenarioContext), out message, graphReference);
            match.Should().BeTrue($"Because {message}");
        }




        [Then(@"the ""(.*)"" graph matches the expect results using the ""(.*)"" query and the previous URI")]
        public void ThenTheGraphMatchesTheExpectResultsUsingTheQueryAndThePreviousURI(string graphReference, string queryReference, Table expectedResults)
        {
            cypherQueries.Should().ContainKey(queryReference);
            // expectedResults = _scenarioContext.ReplaceTokensInTable(expectedResults);
            string uri = _scenarioContext.GetUri(_scenarioContext.GetNumberOfStoredUris()-2).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();

            if (graphReference == constants.preview)
            {
                uri = _scenarioContext.ConvertUriToDraft(uri);
            }

            string message;
            bool match = matchGraphQueryResultsWithDictionary(cypherQueries[queryReference].Replace("__URI__", uri), expectedResults.SingleRowToDictionary(_scenarioContext), out message, graphReference);
            match.Should().BeTrue($"Because {message}");
        }

        [Then(@"the ""(.*)"" graph matches the expect results using the ""(.*)"" query and the first URI")]
        public void ThenTheGraphMatchesTheExpectResultsUsingTheQueryAndTheFirstURI(string graphReference, string queryReference, Table expectedResults)
        {
            cypherQueries.Should().ContainKey(queryReference);
            // expectedResults = _scenarioContext.ReplaceTokensInTable(expectedResults);
            string uri = _scenarioContext.GetUri(0).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();

            if (graphReference == constants.preview)
            {
                uri = _scenarioContext.ConvertUriToDraft(uri);
            }

            string message;
            bool match = matchGraphQueryResultsWithDictionary(cypherQueries[queryReference].Replace("__URI__", uri), expectedResults.SingleRowToDictionary(_scenarioContext), out message, graphReference);
            match.Should().BeTrue($"Because {message}");
        }



        [Given(@"I store the uri from the ""(.*)"" graph using the ""(.*)"" query")]
        public void GivenIStoreTheUriFromTheGraphUsingTheQuery(string graphReference, string queryReference)
        {
            GivenIStoreTheUriFromTheGraphAndTagItUsingTheQuery(graphReference, queryReference, string.Empty);
        }

        [Given(@"I store the uri from the ""(.*)"" graph and tag it ""(.*)"" using the ""(.*)"" query")]
        public void GivenIStoreTheUriFromTheGraphAndTagItUsingTheQuery(string graphReference, string tag, string queryReference)
        {
            cypherQueries.Should().ContainKey(queryReference);
            string uri = _scenarioContext.GetLatestUri().Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl).ToLower();

            if (graphReference == constants.preview)
            {
                uri = _scenarioContext.ConvertUriToDraft(uri);
            }

            var results = _scenarioContext.GetGraphConnection(graphReference).GetSingleRowAsDictionary(cypherQueries[queryReference].Replace("__URI__", uri));

            results.Count.Should().Be(1);
            results.Should().ContainKey("uri");

            _scenarioContext.StoreUri(results["uri"].Replace(_scenarioContext.GetEnv().contentApiBaseUrl.ToLower(), "<<contentapiprefix>>")
                                                    .Replace(_scenarioContext.GetEnv().contentApiDraftBaseUrl.ToLower(), "<<contentapiprefix>>"), tag);
        }

        public bool matchGraphQueryResultsWithDictionary( string cypherQuery, Dictionary<string,string> expectedresults, out string message, string graph = constants.publish)
        {
            bool match;
            message = "";
          
            var results = _scenarioContext.GetGraphConnection(graph).GetSingleRowAsDictionary(cypherQuery);

            // check for prefixed field
            if (_scenarioContext.ContainsKey("prefixField") && expectedresults.ContainsKey((string)_scenarioContext["prefixField"]) )
            {
                string field = (string)_scenarioContext["prefixField"];
                string value = expectedresults[field];
                string prefix = (string)_scenarioContext["prefix"];
                if (!value.StartsWith(prefix))
                {
                    expectedresults[field] = prefix + value;
                }
            }


            match = AreEqual(expectedresults, results);
            if (!match)
            {
                message = $"Checking the {graph} graph\n";
                message += $"Using:\n{cypherQuery}\n";
                message += $"Expected: \n{DictionaryHelper.DictionaryToString(expectedresults)}\n";
                message += $"Actual: \n{DictionaryHelper.DictionaryToString(results)}\n";
            }
            return match;
        }

        [Given(@"I confirm the following ""(.*)"" data is preset in the Graph Database")]
        public void GivenIConfirmTheFollowingDataIsPresetInTheGraphDatabase(string p0, Table table)
        {
            bool addPrefix = _scenarioContext.ContainsKey(constants.prefixField);
            foreach ( var r in table.Rows)
            {
                Dictionary<string, string> rowData = new Dictionary<string, string>();
                int count = 0;
                string cyperQuery = "match (i:" + p0 + ") where i.uri = '";
                string message;
                foreach ( var i in r)
                {
                    string newValue = i.Value;
                    if (addPrefix && i.Key == (string)_scenarioContext[constants.prefixField] ) 
                    {
                        newValue = (string)_scenarioContext[constants.prefix] + newValue;
                    }
                    count++;
                    rowData.Add(i.Key, _scenarioContext.ReplaceTokensInString(newValue) );
                    if (count == 1)
                    {
                        cyperQuery += newValue + "' return i.uri as uri";
                    }
                    else
                    {
                        cyperQuery += " ,i." + i.Key + " as " + i.Key;
                    }
                }
                var match = matchGraphQueryResultsWithDictionary(cyperQuery, rowData, out message);
                if (!match)
                {
                    Console.WriteLine("**confirm the following data is preset in the Graph Database**");
                    Console.WriteLine("Mismatch between expected and actual results");
                    Console.WriteLine(message);
                }
                match.Should().BeTrue();
            }
        }

        [Then(@"I can navigate to the content item ""(.*)"" in Orchard Core core")]
        public void ThenICanNavigateToTheContentItemInOrchardCoreCore(string p0)
        {
            //_manageContent.FindItem(p0);
            _manageContent.EditItem(p0);
        }

        [Given(@"I delete ""(.*)"" Graph data for content type ""(.*)""")]
        public void GivenIDeleteGraphDataForContentType(string target, string type)
        {
            Neo4JHelper neo4JHelper;
            //TODO_DRAFT improve connection handling
            switch (target)
            {
                case constants.draft:
                case constants.preview:
                    neo4JHelper = _scenarioContext.GetGraphConnection(constants.preview);
                    break;
                case constants.publish:
                case constants.published:
                    neo4JHelper = _scenarioContext.GetGraphConnection(constants.publish);
                    break;
                default:
                    neo4JHelper = null;
                    "found".Should().Be("false","because target must be {constants.draft}, {constants.preview}, {constants.publish} or {constants.published}");
                    break;
            }
            string cypher = "match (n) where any(l in labels(n) where l starts with '" + _scenarioContext.ReplaceTokensInString(type) + "') detach delete n";
            neo4JHelper.ExecuteTableQuery(cypher, null);
        }


        //[Given(@"I delete Graph data for content type ""(.*)""")]
        //public void GivenIDeleteGraphDataForContentType(string type)
        //{
        //    //todo make use of extension method
        //    string cypher = "match (n) where any(l in labels(n) where l starts with '" + _scenarioContext.ReplaceTokensInString(type) + "') detach delete n";
        //    Neo4JHelper neo4JHelper = new Neo4JHelper();
        //    neo4JHelper.connect(_scenarioContext.GetEnv().neo4JUrl,
        //                        _scenarioContext.GetEnv().neo4JUid,
        //                        _scenarioContext.GetEnv().neo4JPassword);
        //    neo4JHelper.ExecuteTableQuery(cypher, null);
        //}

        [Given(@"I delete SQL Server data for content type ""(.*)""")]
        public void GivenIDeleteSQLServerDataForContentType(string p0)
        {
            if (!_scenarioContext.GetEnv().sqlServerChecksEnabled)
                return;

            string sqlCommand = sql_ClearDownAllContentItemsOfType;
            sqlCommand = sqlCommand.Replace("@ContentType@", p0);
            int count = _scenarioContext.GetSQLConnection().ExecuteNonQuery(sqlCommand,null);
            _scenarioContext.CloseSQLConnection();
            Console.WriteLine("Deleted " + count + " records from sql server equating to " + count / 2 + "content items of type " + p0);
        }

        [Given(@"I generate and store a new URI")]
        public void GivenIGenerateAndStoreANewURI()
        {
            string newUri = Guid.NewGuid().ToString();
            _scenarioContext.StoreUri(newUri);
        }


        //TODO_DRAFT move this to helper / extension?
        private bool CheckDataIsPresentInGraph( string target, string query, Dictionary<string, string> parameters, Dictionary<string,string> compareValues, out string message, bool checkData = true)
        {
            string uriTokenValue;
            bool match = true;
            message = "";
            Neo4JHelper neo4JHelper;

            //TODO_DRAFT improve connection handling
            switch (target)
            {
                case constants.draft:
                case constants.preview:
                    neo4JHelper = _scenarioContext.GetGraphConnection(constants.preview);
                    uriTokenValue = _scenarioContext.GetEnv().contentApiDraftBaseUrl;
                    break;
                case constants.publish:
                case constants.published:
                    neo4JHelper = _scenarioContext.GetGraphConnection(constants.publish);
                    uriTokenValue = _scenarioContext.GetEnv().contentApiBaseUrl;

                    break;
                default:
                    message = $"target must be {constants.draft}, {constants.preview}, {constants.publish} or {constants.published}";
                    return false;
            }

            if (parameters.ContainsKey("uri"))
            {
                parameters["uri"] = parameters["uri"].Replace("<<contentapiprefix>>", uriTokenValue).ToLower();
            }

            Console.WriteLine("Check data is present in graph:");
            Console.WriteLine($"Query: {query}");
            Console.WriteLine($"uri: {DictionaryToString(parameters)}");

            Type requiredType = (Type)_scenarioContext[constants.responseType];
            var returnObject = neo4JHelper.GetResultsList(requiredType, query, parameters.ToDictionary(pair => pair.Key, pair => (object)pair.Value));

            if (returnObject.Count > 0)
            {
                if( checkData)
                { 
                    object first = returnObject[0];

                    //Dictionary<string, string> vars = (Dictionary<string, string>)_scenarioContext.GetEditorFields();

                    foreach (var var in compareValues)
                    {
                        Type myType = returnObject[0].GetType();
                        PropertyInfo propertyInfo = myType.GetProperty(var.Key);
                        string varValue = "";
                        try
                        {
                            varValue = (string)propertyInfo.GetValue(returnObject[0], null);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        string rawValue = varValue;
                        //Todo keep track of type so tags can only be removed for non html fields rather than by name
                        switch (var.Key)
                        {
                            case "Content":
                                break;
                            default:
                                rawValue = Regex.Replace(varValue, @"<[^>]*>", String.Empty);
                                break;
                        }
                        if (var.Value != rawValue)
                        {
                            message += $"{target} graph - comparing {var.Key}:\nexpected: {var.Value}\nactual: {rawValue}\n";
                            match = false;
                        }
                    }
                }
            }
            else
            {
                match = false;
            }
            return match;
        }

        [Then(@"the intial data is present in the DRAFT Graph database")]
        public void ThenTheIntialDataIsPresentInTheDRAFTGraphDatabase()
        {
            string message;
            CheckDataIsPresentInGraph(constants.draft,
                                      (string)_scenarioContext[constants.cypherQuery],
                                      new Dictionary<string, string> { { "uri", _scenarioContext.GetUri(0) } },
                                      (Dictionary<string, string>)_scenarioContext.GetEditorFields(true),
                                      out message).Should().BeTrue($"because {message}");
        }

        [Then(@"the data is present in the DRAFT Graph database")]
        public void ThenTheDataIsPresentInTheDRAFTGraphDatabase()
        {
            string message;
            CheckDataIsPresentInGraph(constants.draft,
                                      (string)_scenarioContext[constants.cypherQuery],
                                      new Dictionary<string, string> { { "uri", _scenarioContext.GetUri(0) } },
                                      (Dictionary<string, string>)_scenarioContext.GetEditorFields(),
                                      out message).Should().BeTrue($"because {message}");
        }


        [Then(@"the data is present in the PUBLISH Graph database")]
        public void ThenTheNewDataIsPresentInThePublishGraphDatabases()
        {
            string message;
            CheckDataIsPresentInGraph(constants.publish,
                                      (string)_scenarioContext[constants.cypherQuery],
                                      new Dictionary<string, string> { { "uri", _scenarioContext.GetUri(0) } },
                                      (Dictionary<string, string>)_scenarioContext.GetEditorFields(),
                                      out message).Should().BeTrue($"because {message}");
        }


        [Then(@"the intial data is present in the PUBLISH Graph database")]
        public void ThenTheInitialDataIsPresentInThePublishGraphDatabases()
        {
            string message;
            CheckDataIsPresentInGraph(constants.publish,
                                      (string)_scenarioContext[constants.cypherQuery],
                                      new Dictionary<string, string> { { "uri", _scenarioContext.GetUri(0) } },
                                      (Dictionary<string, string>)_scenarioContext.GetEditorFields(true),
                                      out message).Should().BeTrue($"because {message}");
        }

        private void AssertDataNotPresentInGraph( string graph)
        {
            string message;
            graph = (graph == constants.published) ? constants.publish : graph;

            CheckDataIsPresentInGraph( graph,
                                       (string)_scenarioContext[constants.cypherQuery],
                                        new Dictionary<string, string> { { "uri", _scenarioContext.GetUri(0) } },
                                       null,
                                       out message,
                                       false).Should().BeFalse($"Because the record should not be present in the {graph} graph database");
            //Neo4JHelper neo4JHelper = new Neo4JHelper();
            //neo4JHelper.connect(graph == constants.publish ? _scenarioContext.GetEnv().neo4JUrl : _scenarioContext.GetEnv().neo4JUrlDraft,
            //                    _scenarioContext.GetEnv().neo4JUid,
            //                    _scenarioContext.GetEnv().neo4JPassword); ;
        }

        [Then(@"the data is not present in the PUBLISH Graph database")]
        public void ThenTheDataIsNotPresentInThePUBLISHGraphDatabase()
        {
            AssertDataNotPresentInGraph(constants.publish);
        }

        [Then(@"the data is not present in the DRAFT Graph database")]
        public void ThenTheDataIsNotPresentInTheDraftGraphDatabase()
        {
            AssertDataNotPresentInGraph(constants.preview);
        }



        [Then(@"the data is not present in the Graph databases")]
        public void ThenTheDataIsNotPresentInTheGraphDatabases()
        {
            string uri = _scenarioContext.GetUri(0).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiBaseUrl.ToLower());
            var statementTemplate = (string)_scenarioContext[constants.cypherQuery];
            var statementParameters = new Dictionary<string, object> { { "uri", uri } };

            var results = _scenarioContext.GetGraphConnection(constants.publish).ExecuteTableQuery(statementTemplate, statementParameters);
            int count = results.Count();
            count.Should().Be(0, "Because the record should not be present in the graph publish database");

            uri = _scenarioContext.GetUri(0).Replace("<<contentapiprefix>>", _scenarioContext.GetEnv().contentApiDraftBaseUrl.ToLower());
            statementParameters = new Dictionary<string, object> { { "uri", uri } };

            results = _scenarioContext.GetGraphConnection(constants.preview).ExecuteTableQuery(statementTemplate, statementParameters);
            count = results.Count();
            count.Should().Be(0, "Because the record should not be present in the graph database");
        }



        [Then(@"the following graph query returns (.*) record")]
        public void ThenTheFollowingGraphQueryReturnsRecord(int p0, string multilineText)
        {
            string token = "";
            string replaceString = "";
            string cypherStatement = multilineText;
            for (int i = 0; i < _scenarioContext.GetNumberOfStoredUris(); i++)
            {
                token = "@URI" + (i + 1) + "@";
                replaceString = _scenarioContext.GetUri(i);
                cypherStatement = cypherStatement.Replace(token, replaceString);

            }
            int count = _scenarioContext.GetGraphConnection(constants.publish).ExecuteCountQuery(cypherStatement, null);
            count.Should().Be(p0, "Because the repaired record should now be present in the graph database");
        }

  
    #endregion
    }
}
