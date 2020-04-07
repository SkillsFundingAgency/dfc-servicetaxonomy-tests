// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GetSkillById")]
    public partial class GetSkillByIdFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
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
        public virtual void ScenarioTearDown()
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
#line 6
 testRunner.Given("I have made sure that \"occupations\" with related job profiles are present in the " +
                    "graph datastore", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get skill classified as Knowledge and cross-sectoral")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void GetSkillClassifiedAsKnowledgeAndCross_Sectoral()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get skill classified as Knowledge and cross-sectoral", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 9
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table7.AddRow(new string[] {
                        "uri",
                        "http://data.europa.eu/esco/skill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7"});
#line 10
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table7, "Given ");
#line hidden
#line 13
 testRunner.Then("the response json matches:", @"{
   ""skillType"": ""knowledge"",
   ""skill"": ""types of wood materials"",
   ""lastModified"": ""2017-02-15T12:22:24Z"",
   ""alternativeLabels"": [
       ""sorts of wood materials"",
       ""varieties of wood materials"",
       ""categories of wood materials"",
       ""kinds of wood materials"",
       ""type of wood material""
   ],
   ""uri"": ""http://data.europa.eu/esco/skill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7"",
   ""skillReusability"": ""cross-sectoral""
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get skill classified as Competency and Sector Specific")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void GetSkillClassifiedAsCompetencyAndSectorSpecific()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get skill classified as Competency and Sector Specific", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 32
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table8.AddRow(new string[] {
                        "uri",
                        "http://data.europa.eu/esco/skill/ffe198e3-3f51-40c1-8d43-6e559bb98c8d"});
#line 33
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table8, "Given ");
#line hidden
#line 36
 testRunner.Then("the response json matches:", @"{
   ""skillType"": ""competency"",
   ""skill"": ""operate forestry equipment"",
   ""lastModified"": ""2016-12-20T17:26:38Z"",
   ""alternativeLabels"": [
       ""use forestry equipment"",
       ""forestry equipment operating"",
       ""using forestry equipment"",
       ""operating forestry equipment"",
       ""forestry equipment using""
   ],
   ""uri"": ""http://data.europa.eu/esco/skill/ffe198e3-3f51-40c1-8d43-6e559bb98c8d"",
   ""skillReusability"": ""sector-specific""
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get skill classified as occupation-specific")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void GetSkillClassifiedAsOccupation_Specific()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get skill classified as occupation-specific", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 55
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table9.AddRow(new string[] {
                        "uri",
                        "http://data.europa.eu/esco/skill/cb108a0a-88e6-4579-885d-b1e794ada512"});
#line 56
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table9, "Given ");
#line hidden
#line 59
 testRunner.Then("the response json matches:", @"{
   ""skillType"": ""competency"",
   ""skill"": ""manage office appliance requirements"",
   ""lastModified"": ""2016-12-20T18:06:31Z"",
   ""alternativeLabels"": [
       ""oversee office appliance requirements"",
       ""check needs for office stationary items"",
       ""manage requirements of office appliance"",
       ""monitor office appliance requirements"",
       ""managing office appliance requirements"",
       ""manage office appliance's requirements""
   ],
   ""uri"": ""http://data.europa.eu/esco/skill/cb108a0a-88e6-4579-885d-b1e794ada512"",
   ""skillReusability"": ""occupation-specific""
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get skill classified as Transveral with no alternate labels")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void GetSkillClassifiedAsTransveralWithNoAlternateLabels()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get skill classified as Transveral with no alternate labels", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 79
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table10.AddRow(new string[] {
                        "uri",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 80
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table10, "Given ");
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
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unknown skill is supplied")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void UnknownSkillIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unknown skill is supplied", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 96
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table11.AddRow(new string[] {
                        "uri",
                        "http://data.europa.eu/esco/InvalidSkill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7"});
#line 97
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table11, "Given ");
#line 100
    testRunner.Then("the response code is 204", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("No body is supplied")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void NoBodyIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No body is supplied", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 105
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
#line 106
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table12, "Given ");
#line 108
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid body is supplied")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void InvalidBodyIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid body is supplied", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 113
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table13.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 114
 testRunner.Given("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table13, "Given ");
#line 117
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid security header is supplied")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void InvalidSecurityHeaderIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid security header is supplied", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 123
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 124
    testRunner.Given("I want to supply an invalid security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table14.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 125
 testRunner.And("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table14, "And ");
#line 128
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 129
    testRunner.And("the response json matches:", "   {\r\n   \"statusCode\": 401,\r\n   \"message\": \"Access denied due to invalid subscrip" +
                    "tion key. Make sure to provide a valid key for an active subscription.\"\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Missing security header")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillById")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void MissingSecurityHeader()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Missing security header", null, new string[] {
                        "GetSkillById",
                        "ignore",
                        "todo"});
#line 139
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 140
    testRunner.Given("I want to fail to send a security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table15.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 141
 testRunner.And("I make a request to the service taxonomy API \"getskillbyid\"", ((string)(null)), table15, "And ");
#line 144
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 145
    testRunner.And("the response json matches:", "   {\r\n   \"statusCode\": 401,\r\n   \"message\": \"Access denied due to missing subscrip" +
                    "tion key. Make sure to include subscription key when making requests to an API.\"" +
                    "\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
