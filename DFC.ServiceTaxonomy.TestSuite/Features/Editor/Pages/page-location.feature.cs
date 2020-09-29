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
namespace DFC.ServiceTaxonomy.TestSuite.Features.Editor.Pages
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("1. pages-location")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class _1_Pages_LocationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "page-location.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "1. pages-location", null, ProgrammingLanguage.CSharp, new string[] {
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
#line 4
#line hidden
#line 5
 testRunner.Given("I set up a data prefix for \"skos__prefLabel\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.And("I logon to the editor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 7
 testRunner.And("I Navigate to \"/Admin/Contents/ContentTypes/SharedContent/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
 testRunner.And("I capture the generated URI and tag it \"SharedContentUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table271 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table271.AddRow(new string[] {
                        "Draft Content",
                        "<p>Some draft content</p>"});
#line 9
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table271, "And ");
#line hidden
#line 12
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
 testRunner.And("the data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.And("the data is not present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 18
 testRunner.And("I capture the generated URI and tag it \"PageUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table272 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table272.AddRow(new string[] {
                        "My Test Page"});
#line 19
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table272, "And ");
#line hidden
#line 22
 testRunner.And("I select the default page location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.And("I add the \"__PREFIX__Draft Content\" shared content item to the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
 testRunner.Then("the save action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table273 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table273.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 26
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table273, "And ");
#line hidden
#line 29
 testRunner.Given("I store the uri from the \"preview\" graph and tag it \"SharedHTMLUri\" using the \"ge" +
                    "t_sharedhtml_uri_for_page\" query", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add a second content item to a new draft page")]
        public virtual void AddASecondContentItemToANewDraftPage()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a second content item to a new draft page", null, ((string[])(null)));
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
#line 4
this.FeatureBackground();
#line hidden
#line 34
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/SharedContent/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 35
 testRunner.And("I capture the generated URI and tag it \"2ndSharedContentUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table274 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table274.AddRow(new string[] {
                            "2nd Draft Content",
                            "<p>Some other draft content</p>"});
#line 36
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table274, "And ");
#line hidden
#line 39
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 43
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 44
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table275 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title"});
                table275.AddRow(new string[] {
                            "My Test Page Updated"});
#line 45
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table275, "And ");
#line hidden
#line 48
 testRunner.And("I add the \"__PREFIX__2nd Draft Content\" shared content item to the existing widge" +
                        "t", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 50
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table276 = new TechTalk.SpecFlow.Table(new string[] {
                            "count_of_sharedContent"});
                table276.AddRow(new string[] {
                            "2"});
#line 51
 testRunner.And("the \"preview\" graph matches the expect results using the \"number_of_shared_conten" +
                        "t_on_widget_on_page\" query and the \"PageUri\" Uri", ((string)(null)), table276, "And ");
#line hidden
                TechTalk.SpecFlow.Table table277 = new TechTalk.SpecFlow.Table(new string[] {
                            "SharedContent1",
                            "SharedContent2"});
                table277.AddRow(new string[] {
                            "__PREFIX__Draft Content",
                            "__PREFIX__2nd Draft Content"});
#line 54
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_widget_with_two_sh" +
                        "ared_content\" query and \"SharedHTMLUri\" and \"SharedContentUri\" and \"2ndSharedCon" +
                        "tentUri\" Uris", ((string)(null)), table277, "And ");
#line hidden
                TechTalk.SpecFlow.Table table278 = new TechTalk.SpecFlow.Table(new string[] {
                            "count_of_sharedContent"});
                table278.AddRow(new string[] {
                            "2"});
#line 57
 testRunner.And("the \"preview\" graph matches the expect results using the \"number_of_shared_conten" +
                        "t_on_widget_on_page\" query and the \"PageUri\" Uri", ((string)(null)), table278, "And ");
#line hidden
#line 62
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 63
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 64
 testRunner.And("I select the \"Publish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table279 = new TechTalk.SpecFlow.Table(new string[] {
                            "count_of_sharedContent"});
                table279.AddRow(new string[] {
                            "1"});
#line 66
 testRunner.And("the \"publish\" graph matches the expect results using the \"number_of_shared_conten" +
                        "t_on_widget_on_page\" query and the \"PageUri\" Uri", ((string)(null)), table279, "And ");
#line hidden
#line 71
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 72
 testRunner.And("I search for the text \"__PREFIX__2nd Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 73
 testRunner.And("I select the \"Publish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table280 = new TechTalk.SpecFlow.Table(new string[] {
                            "count_of_sharedContent"});
                table280.AddRow(new string[] {
                            "2"});
#line 75
 testRunner.And("the \"publish\" graph matches the expect results using the \"number_of_shared_conten" +
                        "t_on_widget_on_page\" query and the \"PageUri\" Uri", ((string)(null)), table280, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add an html item to a page")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void AddAnHtmlItemToAPage()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add an html item to a page", null, new string[] {
                        "Editor"});
#line 81
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
#line 4
this.FeatureBackground();
#line hidden
#line 82
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 83
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table281 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title"});
                table281.AddRow(new string[] {
                            "My Test Page Update"});
#line 85
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table281, "And ");
#line hidden
#line 88
 testRunner.And("I add an html item to the page with content", "Test HTML", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 92
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table282 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "htmlbody_Html"});
                table282.AddRow(new string[] {
                            "My Test Page Update",
                            "<p>Test HTML</p>"});
#line 93
 testRunner.Then("the \"preview\" graph matches the expect results using the \"page_with_html\" query a" +
                        "nd the \"PageUri\" Uri", ((string)(null)), table282, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table283 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "htmlbody_Html"});
                table283.AddRow(new string[] {
                            "My Test Page Update",
                            "<p>Test HTML</p>"});
#line 96
 testRunner.Then("the \"publish\" graph matches the expect results using the \"page_with_html\" query a" +
                        "nd the \"PageUri\" Uri", ((string)(null)), table283, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
