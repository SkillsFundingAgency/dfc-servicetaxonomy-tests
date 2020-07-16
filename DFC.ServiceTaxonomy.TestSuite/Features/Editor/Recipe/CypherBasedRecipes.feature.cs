﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.3.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DFC.ServiceTaxonomy.TestSuite.Features.Editor.Recipe
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CypherBasedRecipes")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class CypherBasedRecipesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "CypherBasedRecipes.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CypherBasedRecipes", "\tThis feature covers Content from cypher recipe and  Update neo4j recipe", ProgrammingLanguage.CSharp, new string[] {
                        "webtest"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
 #line hidden
#line 6
 testRunner.Given("I set up a data prefix for \"test__Name\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.And("I get the recipe files ready", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
 testRunner.Given("I logon to the editor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
 testRunner.And("I try to delete content type \"CypherItem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("I delete Graph data for content type \"test__CypherItem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And("I delete SQL Server data for content type \"CypherItem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.And("I add a new contentType called \"CypherItem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.And("I edit the \"Graph Sync\" part", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table92 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table92.AddRow(new string[] {
                        "RelationshipType",
                        ""});
            table92.AddRow(new string[] {
                        "NodeNameTransform",
                        "$\"test__{ContentType}\""});
            table92.AddRow(new string[] {
                        "PropertyNameTransform",
                        ""});
            table92.AddRow(new string[] {
                        "CreateRelationshipType",
                        ""});
            table92.AddRow(new string[] {
                        "IDPropertyName",
                        "uri"});
            table92.AddRow(new string[] {
                        "GenerateIDValue",
                        "$\"http://data.europa.eu/esco/occupation/{ContentType.ToLowerInvariant()}/{Value}\"" +
                            ""});
#line 16
 testRunner.And("I set the following field values", ((string)(null)), table92, "And ");
#line hidden
#line 24
 testRunner.And("I save the edited part", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table93 = new TechTalk.SpecFlow.Table(new string[] {
                        "Display Name",
                        "Type"});
            table93.AddRow(new string[] {
                        "TextField",
                        "Text Field"});
            table93.AddRow(new string[] {
                        "ValueField",
                        "Numeric Field"});
#line 25
 testRunner.And("I add the following fields", ((string)(null)), table93, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I use recipes to create neo4j content and import it into orchard core")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("ignore")]
        public virtual void IUseRecipesToCreateNeo4JContentAndImportItIntoOrchardCore()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "ignore"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I use recipes to create neo4j content and import it into orchard core", null, new string[] {
                        "Editor",
                        "ignore"});
#line 32
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 this.FeatureBackground();
#line hidden
#line 34
 testRunner.Given("I load recipe file \"create_neo4j_content.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table94 = new TechTalk.SpecFlow.Table(new string[] {
                            "uri",
                            "test__Name",
                            "test__Description"});
                table94.AddRow(new string[] {
                            "uri::thing1",
                            "Test Thing 1",
                            "test description"});
                table94.AddRow(new string[] {
                            "uri::thing2",
                            "Test Thing 2",
                            "test description"});
#line 35
 testRunner.And("I confirm the following \"test__CypherItem\" data is preset in the Graph Database", ((string)(null)), table94, "And ");
#line hidden
#line 42
 testRunner.And("I load recipe file \"import_neo4j_data.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
 testRunner.Then("I can navigate to the content item \"Test Thing 1\" in Orchard Core core", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table95 = new TechTalk.SpecFlow.Table(new string[] {
                            "Uri",
                            "Title"});
                table95.AddRow(new string[] {
                            "uri::thing1",
                            "Test Thing 1"});
#line 44
 testRunner.And("the values displayed in the editor match", ((string)(null)), table95, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
