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
namespace DFC.ServiceTaxonomy.TestSuite.Features.Editor.Events
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ContentChangeEvents_ExistingPublished")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class ContentChangeEvents_ExistingPublishedFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "webtest"};
        
#line 1 "ContentChangeEvents_ExistingPublished.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ContentChangeEvents_ExistingPublished", null, ProgrammingLanguage.CSharp, new string[] {
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
 testRunner.Given("I logon to the editor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.Given("I set the content type to be \"SharedContent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.Given("I set up a data prefix for \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
 testRunner.And("I Navigate to \"/Admin/Contents/ContentTypes/SharedContent/Create\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And("I capture the generated URI", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table71 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Content"});
            table71.AddRow(new string[] {
                        "New Shared Content",
                        "<p>Here it is</p>"});
#line 13
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table71, "And ");
#line hidden
#line 16
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
 testRunner.Given("I check the number of events sent for this contentItem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("18. A new draft version of an existing, published content item is created")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("NotPP")]
        public virtual void _18_ANewDraftVersionOfAnExistingPublishedContentItemIsCreated()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "NotPP"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("18. A new draft version of an existing, published content item is created", null, new string[] {
                        "Editor",
                        "NotPP"});
#line 22
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
#line 23
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 24
 testRunner.And("I search for the \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table72 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table72.AddRow(new string[] {
                            "updated Shared Content",
                            "<p>Here it is now</p>"});
#line 26
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table72, "And ");
#line hidden
#line 29
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.Then("the save action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 31
 testRunner.And("an event of type \"Draft\" has been issued to notify consumers of the change", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.And("the data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
 testRunner.And("the intial data is present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.And("the number of events sent for this content Item is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("19. A new draft version of an existing, published content item has validation iss" +
            "ues")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("NotPP")]
        [NUnit.Framework.CategoryAttribute("NegativeTest")]
        public virtual void _19_ANewDraftVersionOfAnExistingPublishedContentItemHasValidationIssues()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "NotPP",
                    "NegativeTest"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("19. A new draft version of an existing, published content item has validation iss" +
                    "ues", null, new string[] {
                        "Editor",
                        "NotPP",
                        "NegativeTest"});
#line 37
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
#line 38
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 39
 testRunner.And("I search for the \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table73 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table73.AddRow(new string[] {
                            "",
                            "<p>Here it is now</p>"});
#line 41
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table73, "And ");
#line hidden
#line 44
 testRunner.When("I save the draft item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 45
 testRunner.Then("an \"EmptyField\" validation error is shown for \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 46
 testRunner.And("the intial data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 47
 testRunner.And("the intial data is present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
 testRunner.And("the number of events sent for this content Item is 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("20. Updates to an existing published content item are published succesfully")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("NotPP")]
        public virtual void _20_UpdatesToAnExistingPublishedContentItemArePublishedSuccesfully()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "NotPP"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("20. Updates to an existing published content item are published succesfully", null, new string[] {
                        "Editor",
                        "NotPP"});
#line 51
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
#line 52
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 53
 testRunner.And("I search for the \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table74 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table74.AddRow(new string[] {
                            "updated Shared Content",
                            "<p>Here it is now</p>"});
#line 55
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table74, "And ");
#line hidden
#line 58
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 59
 testRunner.Then("the edit action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 60
 testRunner.And("an event of type \"Published\" has been issued to notify consumers of the change", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 61
 testRunner.And("the data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 62
 testRunner.And("the data is present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
 testRunner.And("the number of events sent for this content Item is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("21. Updates to an existing published content item fails to publish with validatio" +
            "n issues")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("NotPP")]
        [NUnit.Framework.CategoryAttribute("NegativeTest")]
        public virtual void _21_UpdatesToAnExistingPublishedContentItemFailsToPublishWithValidationIssues()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "NotPP",
                    "NegativeTest"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("21. Updates to an existing published content item fails to publish with validatio" +
                    "n issues", null, new string[] {
                        "Editor",
                        "NotPP",
                        "NegativeTest"});
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
#line 4
this.FeatureBackground();
#line hidden
#line 67
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 68
 testRunner.And("I search for the \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
 testRunner.And("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table75 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table75.AddRow(new string[] {
                            "",
                            "<p>Here it is now</p>"});
#line 70
 testRunner.And("I Enter the following form data for \"SharedContent\"", ((string)(null)), table75, "And ");
#line hidden
#line 73
 testRunner.When("I publish the item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 74
 testRunner.Then("an \"EmptyField\" validation error is shown for \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 75
 testRunner.And("the intial data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 76
 testRunner.And("the intial data is present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 77
 testRunner.And("the number of events sent for this content Item is 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("28. A published item is unpublished from the content item list view")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("NotPP")]
        public virtual void _28_APublishedItemIsUnpublishedFromTheContentItemListView()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "NotPP"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("28. A published item is unpublished from the content item list view", null, new string[] {
                        "Editor",
                        "NotPP"});
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
#line 4
this.FeatureBackground();
#line hidden
#line 81
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 82
 testRunner.And("I search for the \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.And("I select the \"Unpublish\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
 testRunner.Then("the unpublish action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 85
 testRunner.And("an event of type \"Unpublished\" has been issued to notify consumers of the change", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 86
 testRunner.And("an event of type \"Draft\" has been issued to notify consumers of the change", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 88
 testRunner.And("the data is present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 89
 testRunner.And("the data is not present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.And("the number of events sent for this content Item is 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("32. An existing published content item is deleted from the content item list view" +
            "")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("NotPP")]
        public virtual void _32_AnExistingPublishedContentItemIsDeletedFromTheContentItemListView()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "NotPP"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32. An existing published content item is deleted from the content item list view" +
                    "", null, new string[] {
                        "Editor",
                        "NotPP"});
#line 93
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
#line 94
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 95
 testRunner.And("I search for the \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 96
 testRunner.And("I select the \"Delete\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.Then("the delete action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 98
 testRunner.And("1 events of type \"Deleted\" has been issued to notify consumers of the change", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 99
 testRunner.And("the data is not present in the DRAFT Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 100
 testRunner.And("the data is not present in the PUBLISH Graph database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 101
 testRunner.And("the number of events sent for this content Item is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("35. An existing draft content item is cloned from the content item list view")]
        [NUnit.Framework.CategoryAttribute("Editor")]
        [NUnit.Framework.CategoryAttribute("NotPP")]
        [NUnit.Framework.CategoryAttribute("ignore")]
        public virtual void _35_AnExistingDraftContentItemIsClonedFromTheContentItemListView()
        {
            string[] tagsOfScenario = new string[] {
                    "Editor",
                    "NotPP",
                    "ignore"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("35. An existing draft content item is cloned from the content item list view", null, new string[] {
                        "Editor",
                        "NotPP",
                        "ignore"});
#line 104
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
#line 105
 testRunner.Given("I Navigate to \"/Admin/Contents/ContentItems\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 106
 testRunner.And("I search for the \"Title\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 107
 testRunner.And("I select the \"Clone\" option for the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 108
 testRunner.Then("the clone action completes succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 109
 testRunner.Given("I select the first item that is found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 110
 testRunner.Then("no event is issued", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
