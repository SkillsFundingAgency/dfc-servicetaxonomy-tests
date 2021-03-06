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
 testRunner.And("I delete \"Preview\" Graph data for content type \"__TYPE__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And("I delete \"Publish\" Graph data for content type \"__TYPE__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 13
 testRunner.And("I delete SQL Server data for content type \"CypherItem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.And("I add a new contentType called \"CypherItem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.And("I edit the \"Graph Sync\" part", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table317 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table317.AddRow(new string[] {
                        "RelationshipType",
                        ""});
            table317.AddRow(new string[] {
                        "NodeNameTransform",
                        "$\"test__{ContentType}\""});
            table317.AddRow(new string[] {
                        "PropertyNameTransform",
                        ""});
            table317.AddRow(new string[] {
                        "CreateRelationshipType",
                        ""});
            table317.AddRow(new string[] {
                        "IDPropertyName",
                        "uri"});
            table317.AddRow(new string[] {
                        "GenerateIDValue",
                        "$\"http://data.europa.eu/esco/occupation/{ContentType.ToLowerInvariant()}/{Value}\"" +
                            ""});
#line 17
 testRunner.And("I set the following field values", ((string)(null)), table317, "And ");
#line hidden
#line 25
 testRunner.And("I save the edited part", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table318 = new TechTalk.SpecFlow.Table(new string[] {
                        "Display Name",
                        "Type"});
            table318.AddRow(new string[] {
                        "TextField",
                        "Text Field"});
            table318.AddRow(new string[] {
                        "ValueField",
                        "Numeric Field"});
#line 26
 testRunner.And("I add the following fields", ((string)(null)), table318, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I use recipes to create neo4j content and import it into orchard core")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("NotDev")]
        [NUnit.Framework.CategoryAttribute("NotSit")]
        [NUnit.Framework.CategoryAttribute("NotPP")]
        public virtual void IUseRecipesToCreateNeo4JContentAndImportItIntoOrchardCore()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "NotDev",
                    "NotSit",
                    "NotPP"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I use recipes to create neo4j content and import it into orchard core", null, new string[] {
                        "Editor",
                        "NotDev",
                        "NotSit",
                        "NotPP"});
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
                TechTalk.SpecFlow.Table table319 = new TechTalk.SpecFlow.Table(new string[] {
                            "uri",
                            "test__Name",
                            "test__Description"});
                table319.AddRow(new string[] {
                            "uri::thing1",
                            "Test Thing 1",
                            "test description"});
                table319.AddRow(new string[] {
                            "uri::thing2",
                            "Test Thing 2",
                            "test description"});
#line 35
 testRunner.And("I confirm the following \"test__CypherItem\" data is preset in the Graph Database", ((string)(null)), table319, "And ");
#line hidden
#line 42
 testRunner.And("I load recipe file \"import_neo4j_data.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
 testRunner.Then("I can navigate to the content item \"Test Thing 1\" in Orchard Core core", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table320 = new TechTalk.SpecFlow.Table(new string[] {
                            "Uri",
                            "Title"});
                table320.AddRow(new string[] {
                            "uri::thing1",
                            "Test Thing 1"});
#line 44
 testRunner.And("the values displayed in the editor match", ((string)(null)), table320, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
