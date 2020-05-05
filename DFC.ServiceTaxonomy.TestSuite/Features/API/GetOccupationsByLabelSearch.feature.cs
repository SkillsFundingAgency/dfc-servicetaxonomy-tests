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
    [NUnit.Framework.DescriptionAttribute("GetOccupationsByLabelSearch")]
    public partial class GetOccupationsByLabelSearchFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetOccupationsByLabelSearch.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetOccupationsByLabelSearch", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Search for a full word")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void SearchForAFullWord()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search for a full word", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 6
testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\" with r" +
                    "equest body", "{\r\n  \"label\": \"dietitian\",\r\n  \"matchAltLabels\": \"true\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 14
testRunner.Then("the response json matches:", @"{
""occupations"": [
    {
        ""occupation"": ""dietitian"",
        ""lastModified"": ""2016-09-22T13:31:57Z"",
        ""alternativeLabels"": [
            ""dietician"",
            ""public health nutritionist"",
            ""specialist dietician""
        ],
        ""uri"": ""http://data.europa.eu/esco/occupation/8a53f8d3-d995-4c7b-a70d-d79f76bdcb3f"",
        ""matches"": {
            ""occupation"": [
                ""dietitian""
            ],
            ""alternativeLabels"": []
        }
    }
]
}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search for a partial word")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void SearchForAPartialWord()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search for a partial word", null, new string[] {
                        "GetOccupationsByLabel",
                        "todo"});
#line 39
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 41
testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\" with r" +
                    "equest body", "{\r\n\"label\": \"eauti\",\r\n\"matchAltLabels\": \"true\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
    testRunner.And("the response json matches:", @"{
""occupations"": [
    {
        ""occupation"": ""aesthetician"",
        ""lastModified"": ""2016-07-05T16:54:48Z"",
        ""alternativeLabels"": [
            ""skin care technician"",
            ""beauty specialist"",
            ""cosmetician"",
            ""facial treatment operator"",
            ""esthetician"",
            ""facialist"",
            ""skin care specialist"",
            ""beautician""
        ],
        ""uri"": ""http://data.europa.eu/esco/occupation/a1e1a788-2352-4172-8fcf-1f985a6968b0"",
        ""matches"": {
            ""occupation"": [],
            ""alternativeLabels"": [
                ""beautician""
            ]
        }
    }
]
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search for a full word with alternate labels included")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void SearchForAFullWordWithAlternateLabelsIncluded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search for a full word with alternate labels included", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 80
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 82
testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\" with r" +
                    "equest body", "{\r\n\"label\": \"dietician\",\r\n\"matchAltLabels\": \"true\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 91
    testRunner.And("the response json matches:", @"{
    ""occupations"": [
        {
            ""occupation"": ""dietitian"",
            ""lastModified"": ""2016-09-22T13:31:57Z"",
            ""alternativeLabels"": [
                ""dietician"",
                ""public health nutritionist"",
                ""specialist dietician""
            ],
            ""uri"": ""http://data.europa.eu/esco/occupation/8a53f8d3-d995-4c7b-a70d-d79f76bdcb3f"",
            ""matches"": {
                ""occupation"": [],
                ""alternativeLabels"": [
                    ""dietician"",
                    ""specialist dietician""
                ]
            }
        }
    ]
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search where there are no matches")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void SearchWhereThereAreNoMatches()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search where there are no matches", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 117
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 119
testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\" with r" +
                    "equest body", "{\r\n\"label\": \"guardian of the galaxy\",\r\n\"matchAltLabels\": \"true\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 127
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 128
    testRunner.And("the response json matches:", "{\r\n\"occupations\": []\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Alt label search defaults to false")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void AltLabelSearchDefaultsToFalse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Alt label search defaults to false", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 136
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 138
testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\" with r" +
                    "equest body", "{\r\n\"label\": \"dietician\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 145
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 146
    testRunner.And("the response json matches:", "{\r\n\"occupations\": []\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search for that is only in alt labels without allowing alt label search")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void SearchForThatIsOnlyInAltLabelsWithoutAllowingAltLabelSearch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search for that is only in alt labels without allowing alt label search", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 155
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 157
testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\" with r" +
                    "equest body", "{\r\n\"label\": \"dietician\",\r\n\"matchAltLabels\": \"false\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 165
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 166
    testRunner.And("the response json matches:", "{\r\n\"occupations\": []\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Alt label value is supplied as parameter")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void AltLabelValueIsSuppliedAsParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Alt label value is supplied as parameter", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 177
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 179
testRunner.Given("I want to supply \"?matchAltLabels=true\" as a parameter in the following request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 180
testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\" with r" +
                    "equest body", "{\r\n\"label\": \"dietician\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 186
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 187
    testRunner.And("the response json matches:", @"{
    ""occupations"": [
        {
            ""occupation"": ""dietitian"",
            ""lastModified"": ""2016-09-22T13:31:57Z"",
            ""alternativeLabels"": [
                ""dietician"",
                ""public health nutritionist"",
                ""specialist dietician""
            ],
            ""uri"": ""http://data.europa.eu/esco/occupation/8a53f8d3-d995-4c7b-a70d-d79f76bdcb3f"",
            ""matches"": {
                ""occupation"": [],
                ""alternativeLabels"": [
                    ""dietician"",
                    ""specialist dietician""
                ]
            }
        }
    ]
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("No body is supplied")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void NoBodyIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No body is supplied", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 215
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
#line 216
 testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\"", ((string)(null)), table1, "Given ");
#line 218
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 219
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid body is supplied")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void InvalidBodyIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid body is supplied", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 223
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table2.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 224
 testRunner.Given("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\"", ((string)(null)), table2, "Given ");
#line 227
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 228
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid security header is supplied")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void InvalidSecurityHeaderIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid security header is supplied", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 233
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 234
    testRunner.Given("I want to supply an invalid security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table3.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 235
 testRunner.And("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\"", ((string)(null)), table3, "And ");
#line 238
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 239
    testRunner.And("the response json matches:", "   {\r\n   \"statusCode\": 401,\r\n   \"message\": \"Access denied due to invalid subscrip" +
                    "tion key. Make sure to provide a valid key for an active subscription.\"\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Missing security header")]
        [NUnit.Framework.CategoryAttribute("GetOccupationsByLabel")]
        [NUnit.Framework.CategoryAttribute("#@ignore")]
        [NUnit.Framework.CategoryAttribute("todo")]
        public virtual void MissingSecurityHeader()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Missing security header", null, new string[] {
                        "GetOccupationsByLabel",
                        "#@ignore",
                        "todo"});
#line 249
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 250
    testRunner.Given("I want to fail to send a security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table4.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 251
 testRunner.And("I make a request to the service taxonomy API \"getoccupationsbylabelsearch\"", ((string)(null)), table4, "And ");
#line 254
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 255
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