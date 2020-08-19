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
    [NUnit.Framework.DescriptionAttribute("6. pages-new_draft_content_on_draft_page")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class _6_Pages_New_Draft_Content_On_Draft_PageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "6. pages-new_draft_content_on_draft_page.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "6. pages-new_draft_content_on_draft_page", null, ProgrammingLanguage.CSharp, new string[] {
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
#line 3
#line hidden
#line 4
 testRunner.Given("I set up a data prefix for \"skos__prefLabel\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
 testRunner.And("I logon to the editor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 6
 testRunner.And("I Navigate to \"/Admin/Contents/ContentTypes/SharedContent/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 7
 testRunner.And("I capture the generated URI and tag it \"SharedContentUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table202 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table202.AddRow(new string[] {
                        "Draft Content",
                        "<p>Some draft content</p>"});
#line 8
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table202, "And ");
#line hidden
#line 11
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 13
 testRunner.And("the data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.And("the data is present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 17
 testRunner.And("I capture the generated URI and tag it \"PageUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table203 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table203.AddRow(new string[] {
                        "My Test Page"});
#line 18
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table203, "And ");
#line hidden
#line 21
 testRunner.And("I select the default page location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
 testRunner.And("I add the \"__PREFIX__Draft Content\" shared content item to the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table204 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table204.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 25
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table204, "And ");
#line hidden
            TechTalk.SpecFlow.Table table205 = new TechTalk.SpecFlow.Table(new string[] {
                        "pages_found"});
            table205.AddRow(new string[] {
                        "0"});
#line 28
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                    "the \"PageUri\" Uri", ((string)(null)), table205, "And ");
#line hidden
#line 31
 testRunner.Given("I store the uri from the \"preview\" graph and tag it \"SharedHTMLUri\" using the \"ge" +
                    "t_sharedhtml_uri_for_page\" query", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 33
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 34
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table206 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table206.AddRow(new string[] {
                        "Updated Content",
                        "<p>Some updated content</p>"});
#line 36
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table206, "And ");
#line hidden
#line 39
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table207 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table207.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Updated Content"});
#line 41
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table207, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("publish the page")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void PublishThePage()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("publish the page", null, new string[] {
                        "Editor"});
#line 46
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
#line 3
this.FeatureBackground();
#line hidden
#line 47
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 48
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
 testRunner.And("I select the \"Publish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 50
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table208 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table208.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Updated Content"});
#line 51
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table208, "And ");
#line hidden
                TechTalk.SpecFlow.Table table209 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table209.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 54
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table209, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Publish the shared content")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void PublishTheSharedContent()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Publish the shared content", null, new string[] {
                        "Editor"});
#line 60
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
#line 3
this.FeatureBackground();
#line hidden
#line 61
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 62
 testRunner.And("I search for the text \"__PREFIX__Updated Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
 testRunner.And("I select the \"Publish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 64
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table210 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table210.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Updated Content"});
#line 65
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table210, "And ");
#line hidden
                TechTalk.SpecFlow.Table table211 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table211.AddRow(new string[] {
                            "0"});
#line 68
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table211, "And ");
#line hidden
                TechTalk.SpecFlow.Table table212 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table212.AddRow(new string[] {
                            "0"});
#line 71
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table212, "And ");
#line hidden
                TechTalk.SpecFlow.Table table213 = new TechTalk.SpecFlow.Table(new string[] {
                            "sharedContent"});
                table213.AddRow(new string[] {
                            "__PREFIX__Updated Content"});
#line 74
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_title_by" +
                        "_uri\" query and the \"SharedContentUri\" Uri", ((string)(null)), table213, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("discard the draft shared content")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void DiscardTheDraftSharedContent()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("discard the draft shared content", null, new string[] {
                        "Editor"});
#line 79
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
#line 3
this.FeatureBackground();
#line hidden
#line 80
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 81
 testRunner.And("I search for the text \"__PREFIX__Updated Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
 testRunner.And("I select the \"Discard Draft\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.Then("the discard action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table214 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table214.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 84
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table214, "And ");
#line hidden
                TechTalk.SpecFlow.Table table215 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table215.AddRow(new string[] {
                            "0"});
#line 87
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table215, "And ");
#line hidden
                TechTalk.SpecFlow.Table table216 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table216.AddRow(new string[] {
                            "0"});
#line 90
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table216, "And ");
#line hidden
                TechTalk.SpecFlow.Table table217 = new TechTalk.SpecFlow.Table(new string[] {
                            "sharedContent"});
                table217.AddRow(new string[] {
                            "__PREFIX__Draft Content"});
#line 93
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_title_by" +
                        "_uri\" query and the \"SharedContentUri\" Uri", ((string)(null)), table217, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete the page")]
        [NUnit.Framework.CategoryAttribute("editor")]
        public virtual void DeleteThePage()
        {
            string[] tagsOfScenario = new string[] {
                    "editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the page", null, new string[] {
                        "editor"});
#line 98
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
#line 3
this.FeatureBackground();
#line hidden
#line 99
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 100
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 101
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
 testRunner.Then("the delete action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table218 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table218.AddRow(new string[] {
                            "0"});
#line 103
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table218, "And ");
#line hidden
                TechTalk.SpecFlow.Table table219 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table219.AddRow(new string[] {
                            "0"});
#line 106
 testRunner.And("the \"preview\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table219, "And ");
#line hidden
                TechTalk.SpecFlow.Table table220 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table220.AddRow(new string[] {
                            "0"});
#line 109
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table220, "And ");
#line hidden
                TechTalk.SpecFlow.Table table221 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table221.AddRow(new string[] {
                            "0"});
#line 112
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table221, "And ");
#line hidden
                TechTalk.SpecFlow.Table table222 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table222.AddRow(new string[] {
                            "1"});
#line 115
 testRunner.And("the \"preview\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table222, "And ");
#line hidden
                TechTalk.SpecFlow.Table table223 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table223.AddRow(new string[] {
                            "1"});
#line 118
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table223, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete the shared content")]
        [NUnit.Framework.CategoryAttribute("editor")]
        public virtual void DeleteTheSharedContent()
        {
            string[] tagsOfScenario = new string[] {
                    "editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the shared content", null, new string[] {
                        "editor"});
#line 124
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
#line 3
this.FeatureBackground();
#line hidden
#line 125
testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 126
 testRunner.And("I search for the text \"__PREFIX__Updated Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 127
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 128
 testRunner.Then("the delete action could not be completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table224 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table224.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Updated Content"});
#line 129
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table224, "And ");
#line hidden
                TechTalk.SpecFlow.Table table225 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table225.AddRow(new string[] {
                            "1"});
#line 132
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table225, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
