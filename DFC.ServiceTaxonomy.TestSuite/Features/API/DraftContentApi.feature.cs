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
namespace DFC.ServiceTaxonomy.TestSuite.Features.API
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("DraftContentApi")]
    public partial class DraftContentApiFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "DraftContentApi.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DraftContentApi", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Request an NCS item by invalid Type")]
        [NUnit.Framework.CategoryAttribute("ContentApi")]
        public virtual void RequestAnNCSItemByInvalidType()
        {
            string[] tagsOfScenario = new string[] {
                    "ContentApi"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request an NCS item by invalid Type", null, new string[] {
                        "ContentApi"});
#line 7
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
#line 8
 testRunner.Given("I define a test type and call it \"__TYPE__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.Given("I make a request to the Draft content API to retrive all \"__TYPE__\" items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
 testRunner.Then("the response code is 404", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Request an NCS item by invalid Id")]
        [NUnit.Framework.CategoryAttribute("ContentApi")]
        public virtual void RequestAnNCSItemByInvalidId()
        {
            string[] tagsOfScenario = new string[] {
                    "ContentApi"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request an NCS item by invalid Id", null, new string[] {
                        "ContentApi"});
#line 13
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
#line 14
 testRunner.Given("I define a test type and call it \"__TYPE__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table16.AddRow(new string[] {
                            "First Item",
                            "<p>Something</p>"});
#line 15
 testRunner.And("I create a \"__TYPE__\" item with the following data", ((string)(null)), table16, "And ");
#line hidden
#line 18
 testRunner.And("I delete Graph data for content type \"__TYPE__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.Given("I make a request to the Draft content API to retrive item 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 20
 testRunner.Then("the response code is 404", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Request all NCS items of a type")]
        [NUnit.Framework.CategoryAttribute("ContentApi")]
        public virtual void RequestAllNCSItemsOfAType()
        {
            string[] tagsOfScenario = new string[] {
                    "ContentApi"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request all NCS items of a type", null, new string[] {
                        "ContentApi"});
#line 23
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
#line 24
 testRunner.Given("I define a test type and call it \"__TYPE__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table17.AddRow(new string[] {
                            "First Item",
                            "<p>Something</p>"});
#line 25
 testRunner.And("I create a Draft \"__TYPE__\" item with the following data", ((string)(null)), table17, "And ");
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table18.AddRow(new string[] {
                            "2nd Item",
                            "<p>Something else</p>"});
#line 28
 testRunner.And("I create a Draft \"__TYPE__\" item with the following data", ((string)(null)), table18, "And ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content"});
                table19.AddRow(new string[] {
                            "3rd Item",
                            "<p>Something more</p>"});
#line 31
 testRunner.And("I create a Draft \"__TYPE__\" item with the following data", ((string)(null)), table19, "And ");
#line hidden
#line 37
 testRunner.Given("I make a request to the content API to retrive all \"__TYPE__\" items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 38
 testRunner.When("I build the expected response for item 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 39
 testRunner.Then("the response matches the expectation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Request an item with a related item")]
        [NUnit.Framework.CategoryAttribute("ContentApi")]
        public virtual void RequestAnItemWithARelatedItem()
        {
            string[] tagsOfScenario = new string[] {
                    "ContentApi"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request an item with a related item", null, new string[] {
                        "ContentApi"});
#line 45
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
#line 46
 testRunner.Given("I define a test type and call it \"__TYPE__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table20.AddRow(new string[] {
                            "First Item",
                            "<p>Something</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 47
 testRunner.And("I create a \"__TYPE__\" item with the following data", ((string)(null)), table20, "And ");
#line hidden
                TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table21.AddRow(new string[] {
                            "2nd Item",
                            "<p>Something else</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 50
 testRunner.And("I create an item of \"__TYPE__\" related by \"hasRelationship\" to item 1 with the fo" +
                        "llowing data", ((string)(null)), table21, "And ");
#line hidden
#line 53
 testRunner.Given("I make a request to the content API to retrive item 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 54
 testRunner.When("I build the expected response for item 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 55
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 56
 testRunner.Then("the response matches the expectation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Request an item with a number of related items")]
        [NUnit.Framework.CategoryAttribute("ContentApi")]
        public virtual void RequestAnItemWithANumberOfRelatedItems()
        {
            string[] tagsOfScenario = new string[] {
                    "ContentApi"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request an item with a number of related items", null, new string[] {
                        "ContentApi"});
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
#line 61
 testRunner.Given("I define a test type and call it \"typea\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table22.AddRow(new string[] {
                            "First Item",
                            "<p>Something</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 62
 testRunner.And("I create a \"__TYPEA__\" item with the following data", ((string)(null)), table22, "And ");
#line hidden
                TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table23.AddRow(new string[] {
                            "2nd Item",
                            "<p>Something else</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 65
 testRunner.And("I create an item of \"__TYPEA__\" related by \"hasRelationship\" to item 1 with the f" +
                        "ollowing data", ((string)(null)), table23, "And ");
#line hidden
                TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table24.AddRow(new string[] {
                            "3rd Item",
                            "<p>Something more</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 68
 testRunner.And("I create an item of \"__TYPEA__\" related by \"hasOtherRelationship\" to item 1 with " +
                        "the following data", ((string)(null)), table24, "And ");
#line hidden
#line 71
 testRunner.Given("I make a request to the content API to retrive item 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 72
 testRunner.When("I build the expected response for item 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 73
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 74
 testRunner.Then("the response matches the expectation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Request an item with a number of related items of different types")]
        [NUnit.Framework.CategoryAttribute("ContentApi")]
        public virtual void RequestAnItemWithANumberOfRelatedItemsOfDifferentTypes()
        {
            string[] tagsOfScenario = new string[] {
                    "ContentApi"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request an item with a number of related items of different types", null, new string[] {
                        "ContentApi"});
#line 78
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
#line 79
 testRunner.Given("I define a test type and call it \"__TYPEA__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 80
 testRunner.And("I define a test type and call it \"__TYPEB__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table25.AddRow(new string[] {
                            "First Item",
                            "<p>Something</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 81
 testRunner.And("I create a \"__TYPEA__\" item with the following data", ((string)(null)), table25, "And ");
#line hidden
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table26.AddRow(new string[] {
                            "2nd Item",
                            "<p>Something else</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 84
 testRunner.And("I create an item of \"__TYPEA__\" related by \"hasRelationship\" to item 1 with the f" +
                        "ollowing data", ((string)(null)), table26, "And ");
#line hidden
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table27.AddRow(new string[] {
                            "3rd Item",
                            "<p>Something more</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 87
 testRunner.And("I create an item of \"__TYPEA__\" related by \"hasRelationship\" to item 1 with the f" +
                        "ollowing data", ((string)(null)), table27, "And ");
#line hidden
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table28.AddRow(new string[] {
                            "4th Item",
                            "<p>Something different</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 90
 testRunner.And("I create an item of \"__TYPEB__\" related by \"hasOtherRelationship\" to item 1 with " +
                        "the following data", ((string)(null)), table28, "And ");
#line hidden
#line 93
 testRunner.Given("I make a request to the content API to retrive item 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 94
 testRunner.When("I build the expected response for item 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 95
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 96
 testRunner.Then("the response matches the expectation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Request an item with an incoming relationship")]
        [NUnit.Framework.CategoryAttribute("ContentApi")]
        public virtual void RequestAnItemWithAnIncomingRelationship()
        {
            string[] tagsOfScenario = new string[] {
                    "ContentApi"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request an item with an incoming relationship", null, new string[] {
                        "ContentApi"});
#line 100
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
#line 101
 testRunner.Given("I define a test type and call it \"__TYPE__\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table29.AddRow(new string[] {
                            "First Item",
                            "<p>Something</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 102
 testRunner.And("I create a \"__TYPE__\" item with the following data", ((string)(null)), table29, "And ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Title",
                            "Content",
                            "CreatedDate",
                            "ModifiedDate"});
                table30.AddRow(new string[] {
                            "2nd Item",
                            "<p>Something else</p>",
                            "2020-06-17T16:04:41.68Z",
                            "2020-06-17T16:04:41.68Z"});
#line 105
 testRunner.And("I create an item of \"__TYPE__\" related by \"hasRelationship\" to item 1 with the fo" +
                        "llowing data", ((string)(null)), table30, "And ");
#line hidden
#line 108
 testRunner.Given("I make a request to the content API to retrive item 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 109
 testRunner.When("I build the expected response for item 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 110
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 111
 testRunner.Then("the response matches the expectation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion