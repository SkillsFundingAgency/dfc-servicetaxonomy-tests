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
    [NUnit.Framework.DescriptionAttribute("GetOccupationsWithMatchingSkills")]
    public partial class GetOccupationsWithMatchingSkillsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "GetOccupationsWithMatchingSkills.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetOccupationsWithMatchingSkills", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Skill list is supplied that matches one occupation")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsWithMatchingSkills")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void SkillListIsSuppliedThatMatchesOneOccupation()
        {
            string[] tagsOfScenario = new string[] {
                    "GetOccupationsWithMatchingSkills",
                    "todo"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Skill list is supplied that matches one occupation", null, new string[] {
                        "GetOccupationsWithMatchingSkills",
                        "todo"});
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
 testRunner.Given("I make a request to the service taxonomy API \"GetOccupationsWithMatchingSkills\" w" +
                        "ith request body", "{\r\n   \"minimumMatchingSkills\":1,\r\n   \"skillList\":[\"http://data.europa.eu/esco/ski" +
                        "ll/74be20a7-fcfe-4715-bb62-8937a547a982\"]\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
    testRunner.And("I look up the job profile Uri for \"actor/actress\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.And("the response json matches:", @"{
""matchingOccupations"": [
    {
        ""matchingOptionalSkills"": 1,
        ""occupation"": ""actor/actress"",
        ""jobProfileDescription"": ""<p>Actors use speech, movement and expression to bring characters to life in theatre, film, television and radio.</p>"",
        ""totalOccupationOptionalSkills"": 40,
        ""jobProfileTitle"": ""Actor"",
        ""totalOccupationEssentialSkills"": 23,
        ""matchingEssentialSkills"": 0,
        ""lastModified"": ""2017-01-17T13:01:57Z"",
        ""jobProfileUri"": ""@JobProfileUri@"",
        ""uri"": ""http://data.europa.eu/esco/occupation/26171f39-e85a-448f-bd28-a73a5a99927f"",
        ""socCode"": ""3413""
    }
]
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Skill list is supplied that does not match any occupations with the given number " +
            "of matches")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsWithMatchingSkills")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void SkillListIsSuppliedThatDoesNotMatchAnyOccupationsWithTheGivenNumberOfMatches()
        {
            string[] tagsOfScenario = new string[] {
                    "GetOccupationsWithMatchingSkills",
                    "todo"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Skill list is supplied that does not match any occupations with the given number " +
                    "of matches", null, new string[] {
                        "GetOccupationsWithMatchingSkills",
                        "todo"});
#line 42
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
#line 43
 testRunner.Given("I make a request to the service taxonomy API \"GetOccupationsWithMatchingSkills\" w" +
                        "ith request body", "{\r\n   \"minimumMatchingSkills\":2,\r\n   \"skillList\":[\"http://data.europa.eu/esco/ski" +
                        "ll/b3f74d7d-82d6-48e0-8460-219b4aa5dcaa\"]\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 50
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.And("the response json matches:", "{\r\n\"matchingOccupations\": []\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
