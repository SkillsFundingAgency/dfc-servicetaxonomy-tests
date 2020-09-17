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
namespace DFC.ServiceTaxonomy.TestSuite.Features.Editor.SyncChecker
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ValidateAndRepair")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class ValidateAndRepairFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "ValidateAndRepair.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ValidateAndRepair", null, ProgrammingLanguage.CSharp, new string[] {
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
 testRunner.Given("I set up a data prefix for \"skos__prefLabel\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.And("I logon to the editor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
 testRunner.And("I Navigate to \"/Admin/Contents/ContentTypes/SharedContent/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 9
 testRunner.And("I capture the generated URI and tag it \"SharedContentUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table336 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table336.AddRow(new string[] {
                        "Draft Content",
                        "<p>Some draft content</p>"});
#line 10
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table336, "And ");
#line hidden
#line 13
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 14
 testRunner.Then("the item is published succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
 testRunner.And("the data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.And("the data is present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentTypes/Page/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 19
 testRunner.And("I capture the generated URI and tag it \"PageUri\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table337 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table337.AddRow(new string[] {
                        "My Test Page"});
#line 20
 testRunner.And("I Enter the following form data for \"Page\"", ((string)(null)), table337, "And ");
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
            TechTalk.SpecFlow.Table table338 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table338.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 27
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query", ((string)(null)), table338, "And ");
#line hidden
            TechTalk.SpecFlow.Table table339 = new TechTalk.SpecFlow.Table(new string[] {
                        "skos__prefLabel",
                        "sharedContent"});
            table339.AddRow(new string[] {
                        "My Test Page",
                        "__PREFIX__Draft Content"});
#line 30
 testRunner.And("the \"publish\" graph matches the expect results using the \"page_with_shared_conten" +
                    "t\" query", ((string)(null)), table339, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Identify and repair a Missing Node")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void IdentifyAndRepairAMissingNode()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Identify and repair a Missing Node", null, new string[] {
                        "Editor"});
#line 35
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
                TechTalk.SpecFlow.Table table340 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel"});
                table340.AddRow(new string[] {
                            "My Test Page"});
#line 37
 testRunner.Then("the \"preview\" graph matches the expect results using the \"remove_widget\" query an" +
                        "d the \"PageUri\" Uri", ((string)(null)), table340, "Then ");
#line hidden
#line 40
 testRunner.Given("I run the sync check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 41
 testRunner.And("the sync completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"publish\" and \"Validated\" se" +
                        "ction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Failed Valida" +
                        "tion\" section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 44
 testRunner.And("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Repaired\" sec" +
                        "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table341 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table341.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 45
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table341, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Identify and repair a Missing Relationship")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void IdentifyAndRepairAMissingRelationship()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Identify and repair a Missing Relationship", null, new string[] {
                        "Editor"});
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
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table342 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel"});
                table342.AddRow(new string[] {
                            "My Test Page"});
#line 52
 testRunner.Then("the \"preview\" graph matches the expect results using the \"remove_relationship_to_" +
                        "widget\" query and the \"PageUri\" Uri", ((string)(null)), table342, "Then ");
#line hidden
#line 55
 testRunner.Given("I run the sync check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 56
 testRunner.And("the sync completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"publish\" and \"Validated\" se" +
                        "ction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 58
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Failed Valida" +
                        "tion\" section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
 testRunner.And("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Repaired\" sec" +
                        "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table343 = new TechTalk.SpecFlow.Table(new string[] {
                            "skos__prefLabel",
                            "sharedContent"});
                table343.AddRow(new string[] {
                            "My Test Page",
                            "__PREFIX__Draft Content"});
#line 60
 testRunner.And("the \"preview\" graph matches the expect results using the \"page_with_shared_conten" +
                        "t\" query and the \"PageUri\" Uri", ((string)(null)), table343, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Identify and repair a Missing Relationship Property")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void IdentifyAndRepairAMissingRelationshipProperty()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Identify and repair a Missing Relationship Property", null, new string[] {
                        "Editor"});
#line 65
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
                TechTalk.SpecFlow.Table table344 = new TechTalk.SpecFlow.Table(new string[] {
                            "alignment",
                            "ordinal",
                            "size"});
                table344.AddRow(new string[] {
                            "",
                            "",
                            ""});
#line 67
 testRunner.Then("the \"preview\" graph matches the expect results using the \"remove_properties_from_" +
                        "page_to_widget_relationship\" query and the \"PageUri\" Uri", ((string)(null)), table344, "Then ");
#line hidden
#line 70
 testRunner.Given("I run the sync check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 71
 testRunner.And("the sync completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"publish\" and \"Validated\" se" +
                        "ction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 73
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Failed Valida" +
                        "tion\" section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 74
 testRunner.And("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Repaired\" sec" +
                        "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table345 = new TechTalk.SpecFlow.Table(new string[] {
                            "alignment",
                            "ordinal",
                            "size"});
                table345.AddRow(new string[] {
                            "Justify",
                            "0",
                            "100"});
#line 75
 testRunner.And("the \"preview\" graph matches the expect results using the \"check_properties_for_pa" +
                        "ge_to_widget_relationship\" query and the \"PageUri\" Uri", ((string)(null)), table345, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Identify and repair a mismatching Relationship Property")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void IdentifyAndRepairAMismatchingRelationshipProperty()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Identify and repair a mismatching Relationship Property", null, new string[] {
                        "Editor"});
#line 80
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
                TechTalk.SpecFlow.Table table346 = new TechTalk.SpecFlow.Table(new string[] {
                            "alignment",
                            "ordinal",
                            "size"});
                table346.AddRow(new string[] {
                            "xxx",
                            "yyy",
                            "zzz"});
#line 82
 testRunner.Then("the \"preview\" graph matches the expect results using the \"update_properties_for_p" +
                        "age_to_widget_relationship\" query and the \"PageUri\" Uri", ((string)(null)), table346, "Then ");
#line hidden
#line 85
 testRunner.Given("I run the sync check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 86
 testRunner.And("the sync completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 87
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"publish\" and \"Validated\" se" +
                        "ction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 88
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Failed Valida" +
                        "tion\" section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 89
 testRunner.And("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Repaired\" sec" +
                        "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table347 = new TechTalk.SpecFlow.Table(new string[] {
                            "alignment",
                            "ordinal",
                            "size"});
                table347.AddRow(new string[] {
                            "Justify",
                            "0",
                            "100"});
#line 90
 testRunner.And("the \"preview\" graph matches the expect results using the \"check_properties_for_pa" +
                        "ge_to_widget_relationship\" query and the \"PageUri\" Uri", ((string)(null)), table347, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Identify and repair an unexpected Relationship Property")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        public virtual void IdentifyAndRepairAnUnexpectedRelationshipProperty()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Identify and repair an unexpected Relationship Property", null, new string[] {
                        "Editor"});
#line 95
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
                TechTalk.SpecFlow.Table table348 = new TechTalk.SpecFlow.Table(new string[] {
                            "alignment",
                            "ordinal",
                            "size",
                            "additional"});
                table348.AddRow(new string[] {
                            "Justify",
                            "0",
                            "100",
                            "xxx"});
#line 97
 testRunner.Then("the \"preview\" graph matches the expect results using the \"add_property_to_page_to" +
                        "_widget_relationship\" query and the \"PageUri\" Uri", ((string)(null)), table348, "Then ");
#line hidden
#line 100
 testRunner.Given("I run the sync check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 101
 testRunner.And("the sync completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"publish\" and \"Validated\" se" +
                        "ction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 103
 testRunner.Then("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Failed Valida" +
                        "tion\" section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 104
 testRunner.And("the document \"__PREFIX__My Test Page\" appears in the \"preview\" and \"Repaired\" sec" +
                        "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table349 = new TechTalk.SpecFlow.Table(new string[] {
                            "alignment",
                            "ordinal",
                            "size",
                            "additional"});
                table349.AddRow(new string[] {
                            "Justify",
                            "0",
                            "100",
                            ""});
#line 105
 testRunner.And("the \"preview\" graph matches the expect results using the \"check_for_additional_pr" +
                        "operties_on_page_to_widget_relationship\" query and the \"PageUri\" Uri", ((string)(null)), table349, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
