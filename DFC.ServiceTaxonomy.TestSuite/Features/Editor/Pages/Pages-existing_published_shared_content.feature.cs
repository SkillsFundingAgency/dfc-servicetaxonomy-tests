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
    [NUnit.Framework.DescriptionAttribute("Pages-existing_published_shared_content")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class Pages_Existing_Published_Shared_ContentFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "Pages-existing_published_shared_content.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Pages-existing_published_shared_content", null, ProgrammingLanguage.CSharp, new string[] {
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
            TechTalk.SpecFlow.Table table263 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table263.AddRow(new string[] {
                        "Draft Content",
                        "<p>Some draft content</p>"});
#line 8
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table263, "And ");
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
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add an published shared item to a new page and publish it. Unpublish the shared c" +
            "ontent item then the page")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("ignore")]
        public virtual void AddAnPublishedSharedItemToANewPageAndPublishIt_UnpublishTheSharedContentItemThenThePage()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "ignore"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add an published shared item to a new page and publish it. Unpublish the shared c" +
                    "ontent item then the page", null, new string[] {
                        "Editor",
                        "ignore"});
#line 17
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
#line 18
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 19
 testRunner.And("I capture the generated URI and tag it \"PageUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table264 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title"});
                table264.AddRow(new string[] {
                            "My Test Page"});
#line 20
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table264, "And ");
#line hidden
#line 23
 testRunner.And("I select the default page location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.And("I add the \"__PREFIX__Draft Content\" shared content item to the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 26
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table265 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table265.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 27
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query", ((string)(null)), table265, "And ");
#line hidden
                TechTalk.SpecFlow.Table table266 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table266.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 30
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query", ((string)(null)), table266, "And ");
#line hidden
#line 35
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 36
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.Then("the unpublish action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table267 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table267.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 39
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query", ((string)(null)), table267, "And ");
#line hidden
                TechTalk.SpecFlow.Table table268 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel"});
                table268.AddRow(new string[] {
                            "My Test Page"});
#line 42
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_wiget_only\" q" +
                        "uery", ((string)(null)), table268, "And ");
#line hidden
                TechTalk.SpecFlow.Table table269 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table269.AddRow(new string[] {
                            "0"});
#line 45
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query", ((string)(null)), table269, "And ");
#line hidden
#line 50
 testRunner.Given("I store the uri from the \"preview\" graph and tag it \"WidgetUri\" using the \"get_sh" +
                        "aredhtml_uri_for_page\" query", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 51
 testRunner.And("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 53
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.Then("the unpublish action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table270 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table270.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 55
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table270, "And ");
#line hidden
                TechTalk.SpecFlow.Table table271 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table271.AddRow(new string[] {
                            "0"});
#line 58
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table271, "And ");
#line hidden
                TechTalk.SpecFlow.Table table272 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table272.AddRow(new string[] {
                            "0"});
#line 61
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query", ((string)(null)), table272, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add an published shared item to a new page and publish it. Unpublish the page ite" +
            "m then the shared content")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("ignore")]
        public virtual void AddAnPublishedSharedItemToANewPageAndPublishIt_UnpublishThePageItemThenTheSharedContent()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "ignore"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add an published shared item to a new page and publish it. Unpublish the page ite" +
                    "m then the shared content", null, new string[] {
                        "Editor",
                        "ignore"});
#line 68
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
#line 69
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 70
 testRunner.And("I capture the generated URI and tag it \"PageUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table273 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title"});
                table273.AddRow(new string[] {
                            "My Test Page"});
#line 71
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table273, "And ");
#line hidden
#line 74
 testRunner.And("I select the default page location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 75
 testRunner.And("I add the \"__PREFIX__Draft Content\" shared content item to the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 76
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 77
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table274 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table274.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 78
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query", ((string)(null)), table274, "And ");
#line hidden
                TechTalk.SpecFlow.Table table275 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table275.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 81
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query", ((string)(null)), table275, "And ");
#line hidden
#line 86
 testRunner.Given("I store the uri from the \"preview\" graph and tag it \"SharedHTMLUri\" using the \"ge" +
                        "t_sharedhtml_uri_for_page\" query", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 87
 testRunner.And("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 88
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 89
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.Then("the unpublish action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table276 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table276.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 91
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table276, "And ");
#line hidden
                TechTalk.SpecFlow.Table table277 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table277.AddRow(new string[] {
                            "0"});
#line 94
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the previous URI", ((string)(null)), table277, "And ");
#line hidden
                TechTalk.SpecFlow.Table table278 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table278.AddRow(new string[] {
                            "0"});
#line 97
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query", ((string)(null)), table278, "And ");
#line hidden
                TechTalk.SpecFlow.Table table279 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table279.AddRow(new string[] {
                            "1"});
#line 100
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table279, "And ");
#line hidden
#line 105
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 106
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 107
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 108
 testRunner.Then("the unpublish action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table280 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table280.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 109
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"SharedHTMLUri\" Uri", ((string)(null)), table280, "And ");
#line hidden
                TechTalk.SpecFlow.Table table281 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel"});
                table281.AddRow(new string[] {
                            "My Test Page"});
#line 112
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_wiget_only\" q" +
                        "uery and the \"SharedHTMLUri\" Uri", ((string)(null)), table281, "And ");
#line hidden
                TechTalk.SpecFlow.Table table282 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table282.AddRow(new string[] {
                            "0"});
#line 115
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedHTMLUri\" Uri", ((string)(null)), table282, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to delete a shared content item which is in use on a page")]
        [NUnit.Framework.CategoryAttribute("ignore")]
        public virtual void AttemptToDeleteASharedContentItemWhichIsInUseOnAPage()
        {
            string[] tagsOfScenario = new string[] {
                    "ignore"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to delete a shared content item which is in use on a page", null, new string[] {
                        "ignore"});
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
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 122
 testRunner.And("I capture the generated URI and tag it \"PageUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table283 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title"});
                table283.AddRow(new string[] {
                            "My Test Page"});
#line 123
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table283, "And ");
#line hidden
#line 126
 testRunner.And("I select the default page location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 127
 testRunner.And("I add the \"__PREFIX__Draft Content\" shared content item to the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 128
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 129
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table284 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table284.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 130
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query", ((string)(null)), table284, "And ");
#line hidden
                TechTalk.SpecFlow.Table table285 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table285.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 133
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query", ((string)(null)), table285, "And ");
#line hidden
#line 138
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 139
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 140
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 141
 testRunner.Then("the unpublish action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table286 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table286.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 142
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query", ((string)(null)), table286, "And ");
#line hidden
                TechTalk.SpecFlow.Table table287 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel"});
                table287.AddRow(new string[] {
                            "My Test Page"});
#line 145
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_wiget_only\" q" +
                        "uery", ((string)(null)), table287, "And ");
#line hidden
                TechTalk.SpecFlow.Table table288 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table288.AddRow(new string[] {
                            "0"});
#line 148
 testRunner.And("the \"publish\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query", ((string)(null)), table288, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
