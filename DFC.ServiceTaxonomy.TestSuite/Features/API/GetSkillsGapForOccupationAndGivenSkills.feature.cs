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
    [NUnit.Framework.DescriptionAttribute("GetSkillsGapForOccupationAndGivenSkills")]
    public partial class GetSkillsGapForOccupationAndGivenSkillsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetSkillsGapForOccupationAndGivenSkills.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetSkillsGapForOccupationAndGivenSkills", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Occupation is supplied with a skill list which has some commonality")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillsGapOforOccupationAndGivenSkills")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void OccupationIsSuppliedWithASkillListWhichHasSomeCommonality()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Occupation is supplied with a skill list which has some commonality", null, new string[] {
                        "GetSkillsGapOforOccupationAndGivenSkills",
                        "ignore",
                        "todo"});
#line 7
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 8
 testRunner.Given("I make a request to the service taxonomy API \"getskillsgapforoccupationandgivensk" +
                    "ills\" with request body", "{\r\n  \"label\": \"torch\",\r\n  \"matchAltLabels\": \"true\"\r\n}\r\n", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.And("the response json with elements \"missingSkills\" and \"matchingSkills\" removed matc" +
                    "hes:", @"{
""occupation"": ""microbiologist"",
""lastModified"": ""2017-01-17T14:18:17Z"",
""jobProfileTitle"": ""Microbiologist"",
""alternativeLabels"": [
    ""microbiology studies research scientist"",
    ""microbiology research analyst"",
    ""microbiology studies analyst"",
    ""virologist"",
    ""histologist"",
    ""microbiology scholar"",
    ""microbiology research scientist"",
    ""microbiology researcher"",
    ""bacteriologist"",
    ""microbiology studies scientist"",
    ""microbiology analyst"",
    ""helminthologist"",
    ""microbiology biotechnologist"",
    ""microbiology studies scholar"",
    ""microbiology scientist"",
    ""microbiology studies researcher"",
    ""parasitologist"",
    ""microbiology science researcher"",
    ""microbiology studies research analyst""
],
""jobProfileUri"": ""http://nationalcareers.service.gov.uk/jobprofile/2abdd237-350f-433f-b96f-4f4e231e16f1"",
""uri"": ""http://data.europa.eu/esco/occupation/a7a74a05-3dd0-46c6-99af-92df8042520c""
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
    testRunner.And("the response json has collection \"missingSkills\" with an item matching", @"{
        ""relationshipType"": ""essential"",
        ""skill"": ""gather experimental data"",
        ""lastModified"": ""2016-12-20T20:24:44Z"",
        ""alternativeLabels"": [
            ""accumulate experimental data"",
            ""gathering of experimental data"",
            ""experimental data gathering"",
            ""collect experimental data"",
            ""compile experimental data""
        ],
        ""type"": ""competency"",
        ""uri"": ""http://data.europa.eu/esco/skill/89db623e-e1fc-4ec2-9a0f-7b72b4c35303"",
        ""skillReusability"": ""cross-sectoral""
    }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
    testRunner.And("the response json has collection \"missingSkills\" with an item matching", @"    {
        ""relationshipType"": ""essential"",
        ""skill"": ""microbiology-bacteriology"",
        ""lastModified"": ""2016-12-20T19:31:41Z"",
        ""alternativeLabels"": [
            ""microbiology-bacteriologies"",
            ""science of bacteria"",
            ""bacteriology and microbiology"",
            ""micro-biology"",
            ""characteristics of micobioloy"",
            ""study of bacteria"",
            ""bacteriology"",
            ""microbiology"",
            ""specialties of bacteria"",
            ""principles of microbiology"",
            ""study of microbiology"",
            ""study of microscopic organisms"",
            ""classification and characteristics of bacteria""
        ],
        ""type"": ""knowledge"",
        ""uri"": ""http://data.europa.eu/esco/skill/0bc42cda-a6f0-4cac-9b34-7911faba0bd4"",
        ""skillReusability"": ""sector-specific""
    }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 92
    testRunner.And("the response json has collection \"missingSkills\" with an item matching", @"     {
         ""relationshipType"": ""optional"",
         ""skill"": ""helminthology"",
         ""lastModified"": ""2016-12-20T20:22:40Z"",
         ""alternativeLabels"": [
             ""parasitic worms studies"",
             ""the study of parasitic worms""
         ],
         ""type"": ""knowledge"",
         ""uri"": ""http://data.europa.eu/esco/skill/b3f74d7d-82d6-48e0-8460-219b4aa5dcaa"",
         ""skillReusability"": ""occupation-specific""
     }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 107
    testRunner.And("the response json has collection \"missingSkills\" with an item matching", @"     {
         ""relationshipType"": ""optional"",
         ""skill"": ""write research proposals"",
         ""lastModified"": ""2016-10-20T10:15:31Z"",
         ""alternativeLabels"": [],
         ""type"": ""competency"",
         ""uri"": ""http://data.europa.eu/esco/skill/0ee7b0d6-db98-4785-9948-f2ef415d155a"",
         ""skillReusability"": ""cross-sectoral""
     }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
   testRunner.And("the count of collection \"missingSkills\" is 45", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
   testRunner.And("the element \"uri\" in the collection \"missingSkills\" has distinct values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 121
   testRunner.And("the response json has collection \"matchingSkills\" with an item matching", @"{
         ""relationshipType"": ""essential"",
         ""skill"": ""conduct research on flora"",
         ""lastModified"": ""2016-12-20T20:26:33Z"",
         ""alternativeLabels"": [
             ""carry out research on flora"",
             ""flora research"",
             ""perform research on flora"",
             ""run research on flora"",
             ""research on flora""
         ],
         ""type"": ""competency"",
         ""uri"": ""http://data.europa.eu/esco/skill/0058526a-11e9-40a1-ab33-7c5ffdf5da05"",
         ""skillReusability"": ""sector-specific""
     }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 139
   testRunner.And("the response json has collection \"matchingSkills\" with an item matching", @"{
         ""relationshipType"": ""essential"",
         ""skill"": ""collect biological data"",
         ""lastModified"": ""2016-12-20T17:31:28Z"",
         ""alternativeLabels"": [
             ""biological data analysing"",
             ""analysing biological records"",
             ""collect biological records"",
             ""collecting biological records"",
             ""analyse biological records"",
             ""analysing biological data"",
             ""analyse biological data"",
             ""biological data collecting"",
             ""collecting biological data""
         ],
         ""type"": ""competency"",
         ""uri"": ""http://data.europa.eu/esco/skill/e3fcd642-5f9c-48ee-be58-258dd895d281"",
         ""skillReusability"": ""cross-sectoral""
     }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 161
   testRunner.And("the response json has collection \"matchingSkills\" with an item matching", @"     {
         ""relationshipType"": ""essential"",
         ""skill"": ""apply scientific methods"",
         ""lastModified"": ""2017-01-05T10:54:11Z"",
         ""alternativeLabels"": [
             ""employ scientific methods"",
             ""utilise scientific methods"",
             ""implement scientific methods"",
             ""apply a scientific method"",
             ""administer scientific methods"",
             ""apply scientific methodology""
         ],
         ""type"": ""competency"",
         ""uri"": ""http://data.europa.eu/esco/skill/7a34b3d9-bd3b-4f4e-a0f6-f97439901cb7"",
         ""skillReusability"": ""cross-sectoral""
     }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 180
   testRunner.And("the response json has collection \"matchingSkills\" with an item matching", @"    {
         ""relationshipType"": ""optional"",
         ""skill"": ""develop bioremediation techniques"",
         ""lastModified"": ""2016-12-20T20:25:58Z"",
         ""alternativeLabels"": [
             ""prepare bioremediation techniques"",
             ""developing bioremediation techniques"",
             ""developing bioremediation technique"",
             ""compile bioremediation techniques define bioremediation techniques"",
             ""create bioremediation techniques""
         ],
         ""type"": ""competency"",
         ""uri"": ""http://data.europa.eu/esco/skill/23cb29ec-5738-4966-8453-09952ed8c1fc"",
         ""skillReusability"": ""occupation-specific""
     }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
   testRunner.And("the count of collection \"matchingSkills\" is 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
   testRunner.And("the element \"uri\" in the collection \"matchingSkills\" has distinct values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Occupation is supplied with a skill list including a matching skill with no alter" +
            "nate labels")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("GetSkillsGapOforOccupationAndGivenSkills")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void OccupationIsSuppliedWithASkillListIncludingAMatchingSkillWithNoAlternateLabels()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Occupation is supplied with a skill list including a matching skill with no alter" +
                    "nate labels", null, new string[] {
                        "GetSkillsGapOforOccupationAndGivenSkills",
                        "ignore",
                        "todo"});
#line 205
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 207
 testRunner.Given("I make a request to the service taxonomy API \"getskillsgapforoccupationandgivensk" +
                    "ills\" with request body", @"{
  ""occupation"": ""http://data.europa.eu/esco/occupation/a7a74a05-3dd0-46c6-99af-92df8042520c"",
  ""skillList"": [
    ""http://data.europa.eu/esco/skill/0ee7b0d6-db98-4785-9948-f2ef415d155a"",
    ""http://data.europa.eu/esco/skill/0bc42cda-a6f0-4cac-9b34-7911faba0bd4""
  ]
}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 217
    testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 218
    testRunner.And("the response json has collection \"matchingSkills\" with an item matching", @"     {
         ""relationshipType"": ""optional"",
         ""skill"": ""write research proposals"",
         ""lastModified"": ""2016-10-20T10:15:31Z"",
         ""alternativeLabels"": [],
         ""type"": ""competency"",
         ""uri"": ""http://data.europa.eu/esco/skill/0ee7b0d6-db98-4785-9948-f2ef415d155a"",
         ""skillReusability"": ""cross-sectoral""
     }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 230
    testRunner.And("the response json has collection \"matchingSkills\" with an item matching", @"    {
        ""relationshipType"": ""essential"",
        ""skill"": ""microbiology-bacteriology"",
        ""lastModified"": ""2016-12-20T19:31:41Z"",
        ""alternativeLabels"": [
            ""microbiology-bacteriologies"",
            ""science of bacteria"",
            ""bacteriology and microbiology"",
            ""micro-biology"",
            ""characteristics of micobioloy"",
            ""study of bacteria"",
            ""bacteriology"",
            ""microbiology"",
            ""specialties of bacteria"",
            ""principles of microbiology"",
            ""study of microbiology"",
            ""study of microscopic organisms"",
            ""classification and characteristics of bacteria""
        ],
        ""type"": ""knowledge"",
        ""uri"": ""http://data.europa.eu/esco/skill/0bc42cda-a6f0-4cac-9b34-7911faba0bd4"",
        ""skillReusability"": ""sector-specific""
    }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 256
   testRunner.And("the count of collection \"matchingSkills\" is 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 257
   testRunner.And("the count of collection \"missingSkills\" is 47", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Occupation is supplied with a skill list including no matching skills")]
        [NUnit.Framework.CategoryAttribute("GetSkillsGapOforOccupationAndGivenSkills")]
        public virtual void OccupationIsSuppliedWithASkillListIncludingNoMatchingSkills()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Occupation is supplied with a skill list including no matching skills", null, new string[] {
                        "GetSkillsGapOforOccupationAndGivenSkills"});
#line 263
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 265
 testRunner.Given("I make a request to the service taxonomy API \"getskillsgapforoccupationandgivensk" +
                    "ills\" with request body", "{\r\n  \"occupation\": \"http://data.europa.eu/esco/occupation/a7a74a05-3dd0-46c6-99af" +
                    "-92df8042520c\",\r\n  \"skillList\": [\r\n    \"http://data.europa.eu/esco/nonmatchingsk" +
                    "ill/0ee7b0d6-db98-4785-9948-f2ef415d155a\"\r\n  ]\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 274
    testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 275
    testRunner.And("the count of collection \"matchingSkills\" is 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 276
    testRunner.And("the count of collection \"missingSkills\" is 49", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unknown occupation is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillsGapOforOccupationAndGivenSkills")]
        public virtual void UnknownOccupationIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unknown occupation is supplied", null, new string[] {
                        "GetSkillsGapOforOccupationAndGivenSkills"});
#line 280
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 281
 testRunner.Given("I make a request to the service taxonomy API \"getskillsgapforoccupationandgivensk" +
                    "ills\" with request body", @"{
  ""occupation"": ""http://data.europa.eu/esco/Invalidoccupation/a7a74a05-3dd0-46c6-99af-92df8042520c"",
  ""skillList"": [
    ""http://data.europa.eu/esco/skill/0058526a-11e9-40a1-ab33-7c5ffdf5da05"",
	""http://data.europa.eu/esco/skill/e3fcd642-5f9c-48ee-be58-258dd895d281"",
	""http://data.europa.eu/esco/skill/7a34b3d9-bd3b-4f4e-a0f6-f97439901cb7"",
	""http://data.europa.eu/esco/skill/23cb29ec-5738-4966-8453-09952ed8c1fc"",
	""http://data.europa.eu/esco/skill/e3fcd642-5f9c-48ee-be58-258dd895d281""
  ]
}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 294
    testRunner.Then("the response code is 204", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("No body is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillsGapOforOccupationAndGivenSkills")]
        public virtual void NoBodyIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No body is supplied", null, new string[] {
                        "GetSkillsGapOforOccupationAndGivenSkills"});
#line 299
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
#line 300
 testRunner.Given("I make a request to the service taxonomy API \"getskillsgapforoccupationandgivensk" +
                    "ills\"", ((string)(null)), table25, "Given ");
#line 302
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 303
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid body is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillsGapOforOccupationAndGivenSkills")]
        public virtual void InvalidBodyIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid body is supplied", null, new string[] {
                        "GetSkillsGapOforOccupationAndGivenSkills"});
#line 307
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table26.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 308
 testRunner.Given("I make a request to the service taxonomy API \"getskillsgapforoccupationandgivensk" +
                    "ills\"", ((string)(null)), table26, "Given ");
#line 311
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 312
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid security header is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillsGapOforOccupationAndGivenSkills")]
        public virtual void InvalidSecurityHeaderIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid security header is supplied", null, new string[] {
                        "GetSkillsGapOforOccupationAndGivenSkills"});
#line 317
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 318
    testRunner.Given("I want to supply an invalid security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table27.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 319
 testRunner.And("I make a request to the service taxonomy API \"getskillsgapforoccupationandgivensk" +
                    "ills\"", ((string)(null)), table27, "And ");
#line 322
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 323
    testRunner.And("the response json matches:", "   {\r\n   \"statusCode\": 401,\r\n   \"message\": \"Access denied due to invalid subscrip" +
                    "tion key. Make sure to provide a valid key for an active subscription.\"\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Missing security header")]
        [NUnit.Framework.CategoryAttribute("GetSkillsGapOforOccupationAndGivenSkills")]
        public virtual void MissingSecurityHeader()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Missing security header", null, new string[] {
                        "GetSkillsGapOforOccupationAndGivenSkills"});
#line 333
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 334
    testRunner.Given("I want to fail to send a security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table28.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 335
 testRunner.And("I make a request to the service taxonomy API \"getskillsgapforoccupationandgivensk" +
                    "ills\"", ((string)(null)), table28, "And ");
#line 338
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 339
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