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
    [NUnit.Framework.DescriptionAttribute("8. pages-new_draft_content_on_new_draft_of_page")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class _8_Pages_New_Draft_Content_On_New_Draft_Of_PageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "8. pages-new_draft_content_on_new_draft_of_page.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "8. pages-new_draft_content_on_new_draft_of_page", null, ProgrammingLanguage.CSharp, new string[] {
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
            TechTalk.SpecFlow.Table table231 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table231.AddRow(new string[] {
                        "Draft Content",
                        "<p>Some draft content</p>"});
#line 9
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table231, "And ");
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
            TechTalk.SpecFlow.Table table232 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table232.AddRow(new string[] {
                        "My Test Page"});
#line 19
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table232, "And ");
#line hidden
#line 22
 testRunner.And("I select the default page location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.And("I add the \"__PREFIX__Draft Content\" shared content item to the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table233 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table233.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 26
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table233, "And ");
#line hidden
            TechTalk.SpecFlow.Table table234 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table234.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 29
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table234, "And ");
#line hidden
#line 32
 testRunner.Given("I store the uri from the \"preview\" graph and tag it \"SharedHTMLUri\" using the \"ge" +
                    "t_sharedhtml_uri_for_page\" query", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 34
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 35
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table235 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table235.AddRow(new string[] {
                        "Updated Content",
                        "<p>Some updated content</p>"});
#line 37
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table235, "And ");
#line hidden
#line 40
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 41
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table236 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table236.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Updated Content"});
#line 42
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table236, "And ");
#line hidden
#line 46
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 47
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table237 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table237.AddRow(new string[] {
                        "My Test Page Updated"});
#line 49
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table237, "And ");
#line hidden
#line 52
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 53
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table238 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table238.AddRow(new string[] {
                        "My Test Page Updated",
                        "__PREFIX__Updated Content"});
#line 54
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table238, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Publish the draft shared content")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void PublishTheDraftSharedContent()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Publish the draft shared content", null, new string[] {
                        "Editor"});
#line 62
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
#line 63
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 64
 testRunner.And("I search for the text \"__PREFIX__Updated Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.And("I select the \"Publish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table239 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table239.AddRow(new string[] {
                            "My Test Page Updated",
                            "__PREFIX__Updated Content"});
#line 67
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table239, "And ");
#line hidden
                TechTalk.SpecFlow.Table table240 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table240.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Updated Content"});
#line 70
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table240, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Publish the draft page")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void PublishTheDraftPage()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Publish the draft page", null, new string[] {
                        "Editor"});
#line 75
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
#line 76
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 77
 testRunner.And("I search for the text \"__PREFIX__My Test Page Updated\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 78
 testRunner.And("I select the \"Publish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table241 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table241.AddRow(new string[] {
                            "My Test Page Updated",
                            "__PREFIX__Updated Content"});
#line 80
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table241, "And ");
#line hidden
                TechTalk.SpecFlow.Table table242 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table242.AddRow(new string[] {
                            "My Test Page Updated",
                            "__PREFIX__Draft Content"});
#line 83
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table242, "And ");
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
#line 89
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
#line 90
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 91
 testRunner.And("I search for the text \"__PREFIX__Updated Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 92
 testRunner.And("I select the \"Discard Draft\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 93
 testRunner.Then("the discard action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table243 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table243.AddRow(new string[] {
                            "My Test Page Updated",
                            "__PREFIX__Draft Content"});
#line 94
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table243, "And ");
#line hidden
                TechTalk.SpecFlow.Table table244 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table244.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 97
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table244, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("discard the draft page")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void DiscardTheDraftPage()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("discard the draft page", null, new string[] {
                        "Editor"});
#line 102
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
#line 103
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 104
 testRunner.And("I search for the text \"__PREFIX__My Test Page Updated\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 105
 testRunner.And("I select the \"Discard Draft\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 106
 testRunner.Then("the discard action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table245 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table245.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Updated Content"});
#line 107
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table245, "And ");
#line hidden
                TechTalk.SpecFlow.Table table246 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table246.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 110
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table246, "And ");
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
#line 115
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
#line 116
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 117
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 118
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 119
 testRunner.Then("the delete action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table247 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table247.AddRow(new string[] {
                            "0"});
#line 120
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table247, "And ");
#line hidden
                TechTalk.SpecFlow.Table table248 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table248.AddRow(new string[] {
                            "0"});
#line 123
 testRunner.And("the \"preview\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table248, "And ");
#line hidden
                TechTalk.SpecFlow.Table table249 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table249.AddRow(new string[] {
                            "0"});
#line 126
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table249, "And ");
#line hidden
                TechTalk.SpecFlow.Table table250 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table250.AddRow(new string[] {
                            "0"});
#line 129
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table250, "And ");
#line hidden
                TechTalk.SpecFlow.Table table251 = new TechTalk.SpecFlow.Table(new string[] {
                            "sharedContent"});
                table251.AddRow(new string[] {
                            "__PREFIX__Updated Content"});
#line 132
 testRunner.And("the \"preview\" graph matches the expect results using the \"shared_content_title_by" +
                        "_uri\" query and the \"SharedContentUri\" Uri", ((string)(null)), table251, "And ");
#line hidden
                TechTalk.SpecFlow.Table table252 = new TechTalk.SpecFlow.Table(new string[] {
                            "sharedContent"});
                table252.AddRow(new string[] {
                            "__PREFIX__Draft Content"});
#line 135
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_title_by" +
                        "_uri\" query and the \"SharedContentUri\" Uri", ((string)(null)), table252, "And ");
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
#line 141
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
#line 142
testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 143
 testRunner.And("I search for the text \"__PREFIX__Updated Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 144
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 145
 testRunner.Then("the delete action could not be completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table253 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table253.AddRow(new string[] {
                            "My Test Page Updated",
                            "__PREFIX__Updated Content"});
#line 146
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table253, "And ");
#line hidden
                TechTalk.SpecFlow.Table table254 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table254.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 149
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table254, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
