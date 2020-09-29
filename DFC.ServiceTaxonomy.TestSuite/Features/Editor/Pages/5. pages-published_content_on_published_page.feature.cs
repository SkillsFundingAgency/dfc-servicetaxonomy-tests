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
    [NUnit.Framework.DescriptionAttribute("5. pages-published_content_on_published_page")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class _5_Pages_Published_Content_On_Published_PageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "5. pages-published_content_on_published_page.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "5. pages-published_content_on_published_page", null, ProgrammingLanguage.CSharp, new string[] {
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
            TechTalk.SpecFlow.Table table180 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table180.AddRow(new string[] {
                        "Draft Content",
                        "<p>Some draft content</p>"});
#line 8
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table180, "And ");
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
            TechTalk.SpecFlow.Table table181 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table181.AddRow(new string[] {
                        "My Test Page"});
#line 18
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table181, "And ");
#line hidden
#line 21
 testRunner.And("I select the default page location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
 testRunner.And("I add the \"__PREFIX__Draft Content\" shared content item to the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table182 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table182.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 25
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table182, "And ");
#line hidden
            TechTalk.SpecFlow.Table table183 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table183.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 28
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table183, "And ");
#line hidden
#line 31
 testRunner.Given("I store the uri from the \"preview\" graph and tag it \"SharedHTMLUri\" using the \"ge" +
                    "t_sharedhtml_uri_for_page\" query", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unpublish the page")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void UnpublishThePage()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unpublish the page", null, new string[] {
                        "Editor"});
#line 34
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
#line 35
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 36
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.Then("the unpublish action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table184 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table184.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 39
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table184, "And ");
#line hidden
                TechTalk.SpecFlow.Table table185 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table185.AddRow(new string[] {
                            "0"});
#line 42
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table185, "And ");
#line hidden
                TechTalk.SpecFlow.Table table186 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table186.AddRow(new string[] {
                            "0"});
#line 45
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table186, "And ");
#line hidden
                TechTalk.SpecFlow.Table table187 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table187.AddRow(new string[] {
                            "1"});
#line 48
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table187, "And ");
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
#line 53
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
#line 54
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 55
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
 testRunner.Then("the unpublish action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table188 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table188.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 58
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table188, "And ");
#line hidden
                TechTalk.SpecFlow.Table table189 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel"});
                table189.AddRow(new string[] {
                            "My Test Page"});
#line 61
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_wiget_only\" q" +
                        "uery and the \"PageUri\" Uri", ((string)(null)), table189, "And ");
#line hidden
                TechTalk.SpecFlow.Table table190 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table190.AddRow(new string[] {
                            "0"});
#line 64
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table190, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create draft version of SharedContent")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void CreateDraftVersionOfSharedContent()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create draft version of SharedContent", null, new string[] {
                        "Editor"});
#line 69
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
#line 70
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 71
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table191 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table191.AddRow(new string[] {
                            "Updated Content",
                            "<p>Some updated content</p>"});
#line 73
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table191, "And ");
#line hidden
#line 76
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 77
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table192 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table192.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Updated Content"});
#line 78
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table192, "And ");
#line hidden
                TechTalk.SpecFlow.Table table193 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table193.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 81
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table193, "And ");
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
#line 86
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
#line 87
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 88
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 89
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.Then("the delete action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table194 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table194.AddRow(new string[] {
                            "0"});
#line 91
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table194, "And ");
#line hidden
                TechTalk.SpecFlow.Table table195 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table195.AddRow(new string[] {
                            "0"});
#line 94
 testRunner.And("the \"preview\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table195, "And ");
#line hidden
                TechTalk.SpecFlow.Table table196 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table196.AddRow(new string[] {
                            "0"});
#line 97
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table196, "And ");
#line hidden
                TechTalk.SpecFlow.Table table197 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table197.AddRow(new string[] {
                            "0"});
#line 100
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table197, "And ");
#line hidden
                TechTalk.SpecFlow.Table table198 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table198.AddRow(new string[] {
                            "1"});
#line 103
 testRunner.And("the \"preview\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table198, "And ");
#line hidden
                TechTalk.SpecFlow.Table table199 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table199.AddRow(new string[] {
                            "1"});
#line 106
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table199, "And ");
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
#line 112
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
#line 113
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 114
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 115
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table200 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table200.AddRow(new string[] {
                            "Updated Content",
                            "<p>Some updated content</p>"});
#line 116
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table200, "And ");
#line hidden
#line 119
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 120
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table201 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table201.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Updated Content"});
#line 121
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table201, "And ");
#line hidden
                TechTalk.SpecFlow.Table table202 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table202.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 124
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table202, "And ");
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
#line 130
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
#line 131
testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 132
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 133
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 134
 testRunner.Then("the delete action could not be completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table203 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table203.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 135
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table203, "And ");
#line hidden
                TechTalk.SpecFlow.Table table204 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table204.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 138
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table204, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
