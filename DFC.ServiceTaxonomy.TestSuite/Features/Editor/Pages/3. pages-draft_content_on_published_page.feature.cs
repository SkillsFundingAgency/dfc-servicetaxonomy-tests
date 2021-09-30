﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("3. Pages-draft_content_on_published_page")]
    public partial class _3_Pages_Draft_Content_On_Published_PageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "3. pages-draft_content_on_published_page.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Editor/Pages", "3. Pages-draft_content_on_published_page", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
            TechTalk.SpecFlow.Table table123 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table123.AddRow(new string[] {
                        "Draft Content",
                        "<p>Some draft content</p>"});
#line 8
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table123, "And ");
#line hidden
#line 11
 testRunner.And("I add a comment before submitting for review \"comment \"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
            TechTalk.SpecFlow.Table table124 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table124.AddRow(new string[] {
                        "My Test Page"});
#line 19
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table124, "And ");
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
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 26
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table125 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table125.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 27
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query and the \"PageUri\" Uri", ((string)(null)), table125, "And ");
#line hidden
            TechTalk.SpecFlow.Table table126 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel"});
            table126.AddRow(new string[] {
                        "My Test Page"});
#line 30
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_wiget_only\" q" +
                    "uery and the \"PageUri\" Uri", ((string)(null)), table126, "And ");
#line hidden
#line 33
 testRunner.Given("I store the uri from the \"preview\" graph and tag it \"SharedHTMLUri\" using the \"ge" +
                    "t_sharedhtml_uri_for_page\" query", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Publish the shared content")]
        public virtual void PublishTheSharedContent()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Publish the shared content", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
 testRunner.And("I search for the text \"__PREFIX__Draft Content\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 41
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table127 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table127.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 42
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table127, "And ");
#line hidden
                TechTalk.SpecFlow.Table table128 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table128.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 45
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table128, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unpublish the page")]
        public virtual void UnpublishThePage()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unpublish the page", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table129 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table129.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 55
 testRunner.Then("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table129, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table130 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table130.AddRow(new string[] {
                            "0"});
#line 58
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table130, "And ");
#line hidden
                TechTalk.SpecFlow.Table table131 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table131.AddRow(new string[] {
                            "0"});
#line 61
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table131, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add new draft version of the page")]
        public virtual void AddNewDraftVersionOfThePage()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new draft version of the page", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 66
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
#line 67
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 68
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table132 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title"});
                table132.AddRow(new string[] {
                            "My Updated Test Page"});
#line 70
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table132, "And ");
#line hidden
#line 73
 testRunner.And("I add a comment before submitting for review \"comment \"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 75
 testRunner.Then("the item is saved succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table133 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table133.AddRow(new string[] {
                            "My Updated Test Page",
                            "__PREFIX__Draft Content"});
#line 76
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table133, "And ");
#line hidden
                TechTalk.SpecFlow.Table table134 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel"});
                table134.AddRow(new string[] {
                            "My Test Page"});
#line 79
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_wiget_only\" q" +
                        "uery and the \"PageUri\" Uri", ((string)(null)), table134, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete the page")]
        public virtual void DeleteThePage()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the page", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 84
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
#line 85
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 86
 testRunner.And("I search for the text \"__PREFIX__My Test Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 87
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 88
 testRunner.And("I delete the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 89
 testRunner.And("I confirm I wish to proceed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.Then("the delete action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table135 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table135.AddRow(new string[] {
                            "0"});
#line 91
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table135, "And ");
#line hidden
                TechTalk.SpecFlow.Table table136 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table136.AddRow(new string[] {
                            "0"});
#line 94
 testRunner.And("the \"preview\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table136, "And ");
#line hidden
                TechTalk.SpecFlow.Table table137 = new TechTalk.SpecFlow.Table(new string[] {
                            "pages_found"});
                table137.AddRow(new string[] {
                            "0"});
#line 97
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_by_uri\" query and " +
                        "the \"PageUri\" Uri", ((string)(null)), table137, "And ");
#line hidden
                TechTalk.SpecFlow.Table table138 = new TechTalk.SpecFlow.Table(new string[] {
                            "widgets_found"});
                table138.AddRow(new string[] {
                            "0"});
#line 100
 testRunner.And("the \"publish\" graph matches the expect results using the \"widget_by_uri\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table138, "And ");
#line hidden
                TechTalk.SpecFlow.Table table139 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table139.AddRow(new string[] {
                            "1"});
#line 103
 testRunner.And("the \"preview\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table139, "And ");
#line hidden
                TechTalk.SpecFlow.Table table140 = new TechTalk.SpecFlow.Table(new string[] {
                            "shared_content_found"});
                table140.AddRow(new string[] {
                            "1"});
#line 106
 testRunner.And("the \"preview\" graph matches the expect results using the \"shared_content_by_uri\" " +
                        "query and the \"SharedContentUri\" Uri", ((string)(null)), table140, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete the shared content")]
        public virtual void DeleteTheSharedContent()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the shared content", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
#line 116
 testRunner.And("I delete the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 117
 testRunner.And("I confirm I wish to proceed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 118
 testRunner.Then("the delete action could not be completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table141 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table141.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 119
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table141, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
