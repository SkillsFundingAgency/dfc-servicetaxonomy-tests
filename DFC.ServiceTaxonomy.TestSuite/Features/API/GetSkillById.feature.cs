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
    [NUnit.Framework.DescriptionAttribute("GetSkillById")]
    public partial class GetSkillByIdFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "GetSkillById.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetSkillById", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
 testRunner.Given("I have made sure that \"occupations\" with related job profiles are present in the " +
                    "graph datastore", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get skill classified as Knowledge and cross-sectoral")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void GetSkillClassifiedAsKnowledgeAndCross_Sectoral()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get skill classified as Knowledge and cross-sectoral", null, new string[] {
                        "GetSkillById"});
#line 9
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
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
                table35.AddRow(new string[] {
                            "uri",
                            "http://data.europa.eu/esco/skill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7"});
#line 10
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table35, "Given ");
#line hidden
#line 13
 testRunner.Then("the response json matches:", @"{
   ""skillType"": ""competency"",
   ""skill"": ""types of wood materials"",
   ""lastModified"": ""2017-02-15T12:22:24Z"",
   ""alternativeLabels"": [
       ""type of wood material"",
	""varieties of wood materials"",
	""kinds of wood materials"",
	""sorts of wood materials"",
	""categories of wood materials""
   ],
   ""uri"": ""http://data.europa.eu/esco/skill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7"",
   ""skillReusability"": ""cross-sectoral""
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get skill classified as Competency and Sector Specific")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void GetSkillClassifiedAsCompetencyAndSectorSpecific()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get skill classified as Competency and Sector Specific", null, new string[] {
                        "GetSkillById"});
#line 32
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
                TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
                table36.AddRow(new string[] {
                            "uri",
                            "http://data.europa.eu/esco/skill/ffe198e3-3f51-40c1-8d43-6e559bb98c8d"});
#line 33
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table36, "Given ");
#line hidden
#line 36
 testRunner.Then("the response json matches:", @"{
   ""skillType"": ""competency"",
   ""skill"": ""operate forestry equipment"",
   ""lastModified"": ""2016-12-20T17:26:38Z"",
   ""alternativeLabels"": [
       ""forestry equipment operating"",
       ""use forestry equipment"",
       ""using forestry equipment"",
       ""forestry equipment using"",
       ""operating forestry equipment""
   ],
   ""uri"": ""http://data.europa.eu/esco/skill/ffe198e3-3f51-40c1-8d43-6e559bb98c8d"",
   ""skillReusability"": ""sector-specific""
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get skill classified as occupation-specific")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void GetSkillClassifiedAsOccupation_Specific()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get skill classified as occupation-specific", null, new string[] {
                        "GetSkillById"});
#line 55
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
                TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
                table37.AddRow(new string[] {
                            "uri",
                            "http://data.europa.eu/esco/skill/cb108a0a-88e6-4579-885d-b1e794ada512"});
#line 56
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table37, "Given ");
#line hidden
#line 59
 testRunner.Then("the response json matches:", @"{
   ""skillType"": ""competency"",
   ""skill"": ""manage office appliance requirements"",
   ""lastModified"": ""2016-12-20T18:06:31Z"",
   ""alternativeLabels"": [
       ""monitor office appliance requirements"",
       ""managing office appliance requirements"",
       ""oversee office appliance requirements"",
       ""manage office appliance's requirements"",
       ""check needs for office stationary items"",
       ""manage requirements of office appliance""
   ],
   ""uri"": ""http://data.europa.eu/esco/skill/cb108a0a-88e6-4579-885d-b1e794ada512"",
   ""skillReusability"": ""occupation-specific""
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get skill classified as Transveral with no alternate labels")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void GetSkillClassifiedAsTransveralWithNoAlternateLabels()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get skill classified as Transveral with no alternate labels", null, new string[] {
                        "GetSkillById"});
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
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
                table38.AddRow(new string[] {
                            "uri",
                            "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 80
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table38, "Given ");
#line hidden
#line 83
 testRunner.Then("the response json matches:", @"{
   ""skillType"": ""competency"",
   ""skill"": ""manage data, information and digital content"",
   ""lastModified"": ""2017-02-10T16:32:20Z"",
   ""alternativeLabels"": [],
   ""uri"": ""http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"",
   ""skillReusability"": ""transversal""
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unknown skill is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void UnknownSkillIsSupplied()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unknown skill is supplied", null, new string[] {
                        "GetSkillById"});
#line 96
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
                TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
                table39.AddRow(new string[] {
                            "uri",
                            "http://data.europa.eu/esco/InvalidSkill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7"});
#line 97
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table39, "Given ");
#line hidden
#line 100
    testRunner.Then("the response code is 204", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("No body is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void NoBodyIsSupplied()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No body is supplied", null, new string[] {
                        "GetSkillById"});
#line 105
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
                TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
#line 106
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table40, "Given ");
#line hidden
#line 108
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 109
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid body is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void InvalidBodyIsSupplied()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid body is supplied", null, new string[] {
                        "GetSkillById"});
#line 113
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
                TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
                table41.AddRow(new string[] {
                            "skill",
                            "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 114
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table41, "Given ");
#line hidden
#line 117
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 118
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid security header is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void InvalidSecurityHeaderIsSupplied()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid security header is supplied", null, new string[] {
                        "GetSkillById"});
#line 123
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
#line 124
    testRunner.Given("I want to supply an invalid security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
                table42.AddRow(new string[] {
                            "skill",
                            "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 125
 testRunner.And("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table42, "And ");
#line hidden
#line 128
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 129
    testRunner.And("the response json matches:", "   {\r\n   \"statusCode\": 401,\r\n   \"message\": \"Access denied due to invalid subscrip" +
                        "tion key. Make sure to provide a valid key for an active subscription.\"\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Missing security header")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        public virtual void MissingSecurityHeader()
        {
            string[] tagsOfScenario = new string[] {
                    "GetSkillById"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Missing security header", null, new string[] {
                        "GetSkillById"});
#line 139
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
#line 140
    testRunner.Given("I want to fail to send a security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table43 = new TechTalk.SpecFlow.Table(new string[] {
                            "dataItem",
                            "value"});
                table43.AddRow(new string[] {
                            "skill",
                            "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 141
 testRunner.And("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table43, "And ");
#line hidden
#line 144
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 145
    testRunner.And("the response json matches:", "   {\r\n   \"statusCode\": 401,\r\n   \"message\": \"Access denied due to missing subscrip" +
                        "tion key. Make sure to include subscription key when making requests to an API.\"" +
                        "\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
