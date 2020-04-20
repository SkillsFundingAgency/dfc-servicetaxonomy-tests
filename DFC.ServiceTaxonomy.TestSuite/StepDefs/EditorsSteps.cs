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
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
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
        private const string cypher_activityByUri = "match(a:ncs__Activity { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as uri";
        private const string cypher_DayToDayTaskByUri = "match(a:ncs__DayToDayTask { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Description as Description";
        private const string cypher_OtherRequirementByUri = "match(a:ncs__OtherRequirement { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Description as Description";
        private const string cypher_FurtherInfoByUri = "match(a:ncs__FurtherInfo { uri: { uri} }) return a.skos__prefLabel as Title, a.ncs__Link_url as Url, a.ncs__Link_text as LinkText";
        private const string cypher_UniverstyLinkByUri = "match(a:ncs__UniversityLink { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Url as Description, a.ncs__Link_url as Url, a.ncs__Link_text as LinkText";
        private const string cypher_GenericItemWithDescriptionByUri = "match(a:ncs__@CONTENTTYPE@ { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Description as Description";
        private const string cypher_GenericItemWithTextByUri = "match(a:ncs__@CONTENTTYPE@ { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri, a.ncs__Text as Text";
        private const string cypher_TestItem = "match(a:ncs__@CONTENTTYPE@ { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri @FIELDLIST";

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
        private AddActivity _addActivity;
        private AddContentItemBase _addContentItemBase;
        private AddLinkItem _addLinkItem;
        private ManageContent _manageContent;
        private ModalOKCancel _modalOkCancel;
        private AddContentTypeBaseItem _addContentType;
        private EditContentType _editContentType;
        private GraphSyncPart _GraphSyncPart;


        public EditorsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _logonScreen = new LogonScreen(scenarioContext);
            _startPage = new StartPage(scenarioContext);
            _addActivity = new AddActivity(scenarioContext);
            _addContentItemBase = new AddContentItemBase(scenarioContext);
            _addLinkItem = new AddLinkItem(scenarioContext);
            _manageContent = new ManageContent(scenarioContext);
            _modalOkCancel = new ModalOKCancel(scenarioContext);
            _addContentType = new AddContentTypeBaseItem(scenarioContext);
            _GraphSyncPart = new GraphSyncPart(scenarioContext);
            _editContentType = new EditContentType(scenarioContext);
        }

        #region given steps

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Given(@"I set up a data prefix for ""(.*)""")]
        public void GivenISetUpADataPrefixFor(string p0)
        {
            _scenarioContext["prefix"] = RandomString(5) + "_";
            _scenarioContext["prefixField"] = p0;
        }

        [Given(@"I get the recipe files ready")]
        public void GivenIGetTheRecipeFilesReady()
        {
            if (_scenarioContext.ContainsKey("prefix"))
            {
                _scenarioContext.ReplaceTokensInDirectory(Directory.GetCurrentDirectory() + "/Recipes/" ,"@PREFIX@",(string)_scenarioContext["prefix"] );
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
            _scenarioContext.Set( _addActivity.GetGeneratedURI(), keyGeneratedUri );
        }

        [Given(@"I Enter the following form data")]
        public void GivenIEnterTheFollowingFormData(Table table)
        {
            string contentType = (string)_scenarioContext["ContentType"];
            string cypher = "match(a:ncs__@CONTENTTYPE@ { uri: { uri} }) return a.skos__prefLabel as Title, a.uri as Uri";
            //_scenarioContext["ResponseType"] = typeof(DayToDayTask);

            Dictionary<string, string> expectedData = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                _addContentItemBase.SetFieldValueFromType(contentType, row[0], row[1], row[2]);
                if (row[0] != "Title")
                {
                    cypher += ", a.ncs__" + row[0] + " as " + row[0];
                }
                expectedData.Add(row[0], row[1]);
            }
            _scenarioContext["CypherQuery"] = cypher.Replace("@CONTENTTYPE@", contentType);
            _scenarioContext["ResponseType"] = typeof(TestContent);
            _scenarioContext["RequestVariables"] = expectedData;
            /*            foreach (var item in table.Rows.First().Select((value, index) => new { value, index }))
                        {
                            if (item.index == 0)
                            {
                                // store first field in scenario context
                                _scenarioContext.Set(item.value.Value, item.value.Key);
                            }
                            _addContentItemBase.SetFieldValueFromType( item.value.Key, item.value.Value,"Title");

                         }*/
        }



        [Then(@"the values displayed in the editor match")]
        public void ThenTheValuesDisplayedInTheEditorMatch(Table table)
        {
            foreach (var row in table.Rows)
            {
               foreach (var item in row)
                {
                    string newValue = item.Value;
                    if (_scenarioContext.ContainsKey("prefix") && item.Key.Equals("Title") )
                    {
                        newValue = (string)_scenarioContext["prefix"] + newValue;
                    }
                    newValue.Should().Be(_editContentType.GetFieldValue( item.Key));
                }
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
                    iAddItem = _addContentItemBase;
                    break;
                case "FurtherInfo":
                    _scenarioContext["ResponseType"] = typeof(FurtherInfo);
                    _scenarioContext["CypherQuery"] = cypher_FurtherInfoByUri;
                    iAddItem = _addLinkItem;
                    break;
                case "Activity":
                    _scenarioContext["ResponseType"] = typeof(DFC.ServiceTaxonomy.TestSuite.Models.Activity);
                    _scenarioContext["CypherQuery"] = cypher_activityByUri;
                    iAddItem = _addLinkItem;
                    break;
                case "UniversityLink":
                    _scenarioContext["ResponseType"] = typeof(UniversityLink);
                    _scenarioContext["CypherQuery"] = cypher_UniverstyLinkByUri;
                    iAddItem = _addLinkItem;
                    break;
                case "RequirementsPrefix":
                case "UniversityRequirement":
                    _scenarioContext["ResponseType"] = typeof(GenericContent);
                    _scenarioContext["CypherQuery"] = cypher_GenericItemWithTextByUri.Replace("@CONTENTTYPE@", p0);
                    break;
                case "Restriction":
                default:
                    _scenarioContext["ResponseType"] = typeof(GenericContent);
                    _scenarioContext["CypherQuery"] = cypher_GenericItemWithDescriptionByUri.Replace("@CONTENTTYPE@", p0);
                    //addItem = _addDayToDayTask;
                    break;
            }


            Dictionary<string, string> vars = new Dictionary<string, string>();
            foreach (var item in table.Rows.First().Select((value, index) => new { value, index }))
            {
                string newValue = item.value.Value;
                if (item.index == 0)
                {
                    newValue = ( _scenarioContext.ContainsKey("prefix") ? _scenarioContext["prefix"] : "" ) + newValue;
                    // store first field in scenario context
                    _scenarioContext.Set(item.value.Value, item.value.Key);
                }
                vars.Add(item.value.Key, newValue);
                iAddItem.SetFieldValue(p0, item.value.Key, newValue);
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

        //content type
        [Given(@"I add a new contentType called ""(.*)""")]
        public void GivenIAddANewContentTypeCalled(string p0)
        {
            // navigate to /Admin/ContentTypes/List
            _scenarioContext["ContentType"] = p0;
            _addContentType.AddNew(p0);
 
        }

        //content type
        [Given(@"I edit the ""(.*)"" part")]
        public void GivenIEditThePart(string p0)
        {
            string contentType = (string)_scenarioContext["ContentType"];
            _addContentType.EditPart(contentType, p0);
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
            string contentType = (string)_scenarioContext["ContentType"];
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
           // _scenarioContext["ResponseType"] = typeof(TestContent);
           // _scenarioContext["CypherQuery"] = cypher_TestItem;
            _GraphSyncPart.SetFieldValues(contentType, dictionary);
        }


        [Given(@"I save the edited part")]
        public void GivenISaveTheEditedPart()
        {
            _GraphSyncPart.SaveChanges();
        }

        [Given(@"I save the contentItem")]
        public void GivenISaveTheContentItem()
        {
            _addContentType.SaveChanges();
        }

        [Given(@"I add the following fields")]
        public void GivenIAddTheFollowingFields(Table table)
        {
            string contentType = (string)_scenarioContext["ContentType"];
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            foreach (var item in dictionary)
            {
                _addContentType.AddField(contentType, item.Key, item.Value);
            }
        }


        [Given(@"My Test Step")]
        public void GivenMyTestStep()
        {
            try
            {
                var item = _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/form/nav/ul/li/input"));
                var webElement = _scenarioContext.GetWebDriver().FindElement(By.XPath("/html/body/div[1]/div[3]/form/nav/ul/li/input"));
                webElement.SendKeys(@"F:\recipeFiles\20200326\14. QCFLevels0.zip");
                _scenarioContext.GetWebDriver().FindElement(By.XPath("//button[contains(text(),'Import']"));
                item.Click();
            }
            catch
            {

            }
        }


        [Given(@"Load the file ""(.*)""")]
        public void GivenLoadTheFile(string p0)
        {
            bool successIntitiating = true;
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
                successIntitiating = false;
                error = e.Message;
                Console.WriteLine(e);
            }
     /*       bool finished = false;
            int count = 0;
            while (!finished)
            {
                count++;
                try
                {


                    var checksafter = _scenarioContext.GetWebDriver().FindElements(By.XPath(@"//*[@id='content']/div/fieldset/h2"));
                    var checksafter2 = _scenarioContext.GetWebDriver().FindElements(By.XPath("/html/body/div[1]/div[3]/div"));
                    var checksafter3 = _scenarioContext.GetWebDriver().FindElements(By.XPath("/html/body/div[1]/div[3]/form/nav/ul/li/input"));
                    bool failScreen = false;
                    if (checksafter2.Count > 0)
                    {
                        failScreen = checksafter2[0].Text.Contains("Deployment package imported");
                    }
                    if (!failScreen && checksafter3.Count > 0)
                    {
                        var text = checksafter3[0].Text;
                        failScreen = checksafter3[0].Text.Contains("");
                    }

                    if (checksafter.Count > 0)
                    {
                        finished = true;
                    }
                    if (failScreen)
                    {
                        finished = true;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
                if (!finished)
                {
                    Thread.Sleep(10000);
                }
                if ( count > 40 )
                {
                    Console.WriteLine("");
                }
            }*/
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
            string recordCountString;
            int recordCount = 0;
            bool fileInfoRow = true;
            bool summaryInfoRow = false;
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

            string path = @"F:\temp\output.log";
            int returnStatus = 0;
            Stopwatch timer = new Stopwatch();
            bool successIntitiating = true;
            bool done = false;
            string error = "";
            string loadMessage = "";
            int returnedAfterSeconds = 0;
            int verifiedSqlCountAfterSeconds = 0;

            SQLServerHelper sqlInstance = new SQLServerHelper();
            sqlInstance.SetConnection(_scenarioContext.GetEnv().sqlServerConnectionString);


            // get table name
            var pattern = "[a-zA-Z]+";
            Regex rgx = new Regex(pattern);
            var table = rgx.Matches(filename).First().Value; ;
            table = filename.Split('.')[1];
            table = rgx.Match(filename.Split('.')[1]).Value;
            table = TransformTableName(table);


            // get initial record count
            var ds = sqlInstance.GetRecordCount("ContentItemIndex", "ContentType", table);
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
                   // Console.WriteLine("Page returned message: " + successMessage[0].Text);
                    loadMessage = "Page returned message: " + successMessage[0].Text;
                    returnStatus = 0;
                }
                else
                {
                    //Console.WriteLine("Unhandled situation");
                    loadMessage = "Unhandled return";
                    returnStatus = 2;
                    //throw new Exception("Unhandled situation");
                }
                returnedAfterSeconds = (int)timer.Elapsed.TotalSeconds;

            }
            catch (Exception e)
            {
                successIntitiating = false;
                error = e.Message;
                loadMessage = "Error thrown: " + e.Message;
                Console.WriteLine(e);
            }

            // now need to check that / wait until all the records have arrived in sql database


            int count = 0;
            int tmMod = 5;
            bool status = true;
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
                ds = sqlInstance.GetRecordCount("ContentItemIndex", "ContentType", table);
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
                        status = false;
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

            // now check all neo4j records have been synced
            done = false;
            string cypher = "match(a:ncs__" + table + ") return count(a)";
            int neo4jRecordCount = 0;
            bool tmModExtended = false;
            while (!done)
            {
                // check neo count
                Neo4JHelper neo4JHelper = new Neo4JHelper();
                try
                {
                    neo4JHelper.connect(_scenarioContext.GetEnv().neo4JUrl,
                                    _scenarioContext.GetEnv().neo4JUid,
                                    _scenarioContext.GetEnv().neo4JPassword);
                    /* var countInfo = neo4JHelper.ExecuteTableQuery(cypher,null);
                     var returnObject = neo4JHelper.GetRecordCount(cypher, null);
                     foreach (IRecord record in countInfo)
                     {
                         string a = record.Values["count(a)"].ToString(); ;
                         int.TryParse(a, out neo4jRecordCount);
                     }*/
                    neo4jRecordCount = neo4JHelper.ExecuteCountQuery(cypher, null);
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
                        status = false;
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

        public bool AreEqual(IDictionary<string, string> thisItems, IDictionary<string, string> otherItems)
        {
            if (thisItems.Count != otherItems.Count)
            {
                return false;
            }
            var thisKeys = thisItems.Keys;
            foreach (var key in thisKeys)
            {
                if (!(otherItems.TryGetValue(key, out var value)
                     && string.Equals(thisItems[key], value, StringComparison.OrdinalIgnoreCase))
                    )
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


            public bool matchGraphQueryResultsWithDictionary( string cypherQuery, Dictionary<string,string> expectedresults, out string message)
        {
            bool match;
            message = "";
            Neo4JHelper neo4JHelper = new Neo4JHelper();
            neo4JHelper.connect(_scenarioContext.GetEnv().neo4JUrl,
                                _scenarioContext.GetEnv().neo4JUid,
                                _scenarioContext.GetEnv().neo4JPassword);
           
            var results = neo4JHelper.GetSingleRowAsDictionary(cypherQuery);

            match = AreEqual(expectedresults, results);
            if (!match)
            {
                message = "Expected: \n" + DictionaryToString(expectedresults) + "\n";
                message += "Actual: \n" + DictionaryToString(results) + "\n";
            }
            return match;
        }


        [Given(@"I confirm the following ""(.*)"" data is preset in the Graph Database")]
        public void GivenIConfirmTheFollowingDataIsPresetInTheGraphDatabase(string p0, Table table)
        {
            bool addPrefix = _scenarioContext.ContainsKey("prefixField");
            foreach ( var r in table.Rows)
            {
                Dictionary<string, string> rowData = new Dictionary<string, string>();
                int count = 0;
                string cyperQuery = "match (i:" + p0 + ") where i.uri = '";
                string message;
                foreach ( var i in r)
                {
                    string newValue = i.Value;
                    if (addPrefix && i.Key == (string)_scenarioContext["prefixField"] ) 
                    {
                        newValue = (string)_scenarioContext["prefix"] + newValue;
                    }
                    count++;
                    rowData.Add(i.Key, newValue);
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

        [Given(@"I delete Graph data for content type ""(.*)""")]
        public void GivenIDeleteGraphDataForContentType(string p0)
        {
            //todo make use of extension method
            string cypher = "match (n) where any(l in labels(n) where l starts with '" + p0 + "') detach delete n";
            Neo4JHelper neo4JHelper = new Neo4JHelper();
            neo4JHelper.connect(_scenarioContext.GetEnv().neo4JUrl,
                                _scenarioContext.GetEnv().neo4JUid,
                                _scenarioContext.GetEnv().neo4JPassword);
            neo4JHelper.ExecuteTableQuery(cypher, null);
        }

        [Given(@"I delete SQL Server data for content type ""(.*)""")]
        public void GivenIDeleteSQLServerDataForContentType(string p0)
        {
            string sqlCommand = sql_ClearDownAllContentItemsOfType;
            sqlCommand = sqlCommand.Replace("@ContentType@", p0);
            SQLServerHelper sqlInstance = new SQLServerHelper();
            sqlInstance.SetConnection(_scenarioContext.GetEnv().sqlServerConnectionString);
            int count = sqlInstance.ExecuteNonQuery(sqlCommand,null);
            Console.WriteLine("Deleted " + count + " records from sql server equating to " + count / 2 + "content items of type " + p0);
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
            var returnObject = neo4JHelper.GetResultsList(requiredType, statementTemplate, statementParameters);

            object first = returnObject[0];
  
            Dictionary<string, string> vars = ( Dictionary<string, string> )_scenarioContext["RequestVariables"];

            foreach ( var var in vars)
            {
                Type myType = returnObject[0].GetType();
                PropertyInfo propertyInfo = myType.GetProperty(var.Key);
                string varValue = "";
                try
                {
                    varValue = (string)propertyInfo.GetValue(returnObject[0], null);
                }
                catch ( Exception e ){
                    Console.WriteLine(e.Message);
                }
                
                string rawValue = Regex.Replace(varValue, @"<[^>]*>", String.Empty);
                
                var.Value.Should().Be(rawValue);

            }
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

            var activities = neo4JHelper.GetResultsList<DFC.ServiceTaxonomy.TestSuite.Models.Activity>(statementTemplate, statementParameters);
            activities.Count.Should().Be(0);
        }

        #endregion
    }
}
