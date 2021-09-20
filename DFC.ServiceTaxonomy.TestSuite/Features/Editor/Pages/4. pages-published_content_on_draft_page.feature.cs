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
    [NUnit.Framework.DescriptionAttribute("4. pages-published_content_on_draft_page")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class _4_Pages_Published_Content_On_Draft_PageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "4. pages-published_content_on_draft_page.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "4. pages-published_content_on_draft_page", null, ProgrammingLanguage.CSharp, new string[] {
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
            TechTalk.SpecFlow.Table table142 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table142.AddRow(new string[] {
                        "Draft Content",
                        "<p>Some draft content</p>"});
#line 8
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table142, "And ");
#line hidden
#line 11
 testRunner.And("I add a comment before submitting for review \"comment \"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
 testRunner.And("the data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.And("the data is present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 18
 testRunner.And("I capture the generated URI and tag it \"PageUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table143 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table143.AddRow(new string[] {
                        "My Test Page"});
#line 19
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table143, "And ");
#line hidden
#line 22
 testRunner.And("I select the default page location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.And("I add the \"__PREFIX__Draft Content\" shared content item to the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.And("I add a comment before submitting for review \"comment \"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 26
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table144 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table144.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 27
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table144, "And ");
#line hidden
            TechTalk.SpecFlow.Table table145 = new TechTalk.SpecFlow.Table(new string[] {
                        "pages_found"});
            table145.AddRow(new string[] {
                        "0"});
#line 30
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                    "the \"PageUri\" Uri", ((string)(null)), table145, "And ");
#line hidden
#line 33
 testRunner.Given("I store the uri from the \"preview\" graph and tag it \"SharedHTMLUri\" using the \"ge" +
                    "t_sharedhtml_uri_for_page\" query", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Publish the page")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void PublishThePage()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Publish the page", null, new string[] {
                        "Editor"});
#line 36
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
#line 37
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 38
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.And("I select the \"Publish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table146 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table146.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 41
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table146, "And ");
#line hidden
                TechTalk.SpecFlow.Table table147 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table147.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 44
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table147, "And ");
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
#line 50
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
#line 51
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 52
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 53
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.Then("the delete action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table148 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table148.AddRow(new string[] {
                            "0"});
#line 55
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table148, "And ");
#line hidden
                TechTalk.SpecFlow.Table table149 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table149.AddRow(new string[] {
                            "0"});
#line 58
 testRunner.And("the \"preview\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table149, "And ");
#line hidden
                TechTalk.SpecFlow.Table table150 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table150.AddRow(new string[] {
                            "0"});
#line 61
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table150, "And ");
#line hidden
                TechTalk.SpecFlow.Table table151 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table151.AddRow(new string[] {
                            "0"});
#line 64
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table151, "And ");
#line hidden
                TechTalk.SpecFlow.Table table152 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table152.AddRow(new string[] {
                            "1"});
#line 67
 testRunner.And("the \"preview\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table152, "And ");
#line hidden
                TechTalk.SpecFlow.Table table153 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table153.AddRow(new string[] {
                            "1"});
#line 70
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table153, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create new draft version of the Shared Content")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void CreateNewDraftVersionOfTheSharedContent()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create new draft version of the Shared Content", null, new string[] {
                        "Editor"});
#line 76
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
#line 77
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 78
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table154 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table154.AddRow(new string[] {
                            "Updated Content",
                            "<p>Some updated content</p>"});
#line 80
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table154, "And ");
#line hidden
#line 83
 testRunner.And("I add a comment before submitting for review \"comment \"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 85
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table155 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table155.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Updated Content"});
#line 86
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table155, "And ");
#line hidden
                TechTalk.SpecFlow.Table table156 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table156.AddRow(new string[] {
                            "0"});
#line 89
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table156, "And ");
#line hidden
                TechTalk.SpecFlow.Table table157 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table157.AddRow(new string[] {
                            "0"});
#line 92
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table157, "And ");
#line hidden
                TechTalk.SpecFlow.Table table158 = new TechTalk.SpecFlow.Table(new string[] {
                            "sharedContent"});
                table158.AddRow(new string[] {
                            "__PREFIX__Draft Content"});
#line 95
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_title_by" +
                        "_uri\" query and the \"SharedContentUri\" Uri", ((string)(null)), table158, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unpublish the shared content")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void UnpublishTheSharedContent()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unpublish the shared content", null, new string[] {
                        "Editor"});
#line 101
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
#line 102
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 103
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 104
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table159 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table159.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 105
 testRunner.Then("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table159, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table160 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table160.AddRow(new string[] {
                            "0"});
#line 108
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table160, "And ");
#line hidden
                TechTalk.SpecFlow.Table table161 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table161.AddRow(new string[] {
                            "0"});
#line 111
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table161, "And ");
#line hidden
                TechTalk.SpecFlow.Table table162 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table162.AddRow(new string[] {
                            "0"});
#line 114
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table162, "And ");
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
#line 120
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
#line 121
testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 122
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 123
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 124
 testRunner.Then("the delete action could not be completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table163 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table163.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 125
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table163, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
