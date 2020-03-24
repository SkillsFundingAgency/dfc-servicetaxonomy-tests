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
    [NUnit.Framework.DescriptionAttribute("GetSkillsByLabelSearch")]
    public partial class GetSkillsByLabelSearchFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetSkillsByLabelSearch.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetSkillsByLabelSearch", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void SearchForAFullWord()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search for a full word", null, new string[] {
                        "GetSkillsByLabel"});
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 6
testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\" with reques" +
                    "t body", "{\r\n  \"label\": \"torch\",\r\n  \"matchAltLabels\": \"true\"\r\n}\r\n", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 16
    testRunner.And("the response json matches:", "{\r\n\"skills\": [\r\n{\r\n   \"skillType\": \"competency\",\r\n   \"skill\": \"operate brazing eq" +
                    "uipment\",\r\n   \"lastModified\": \"2016-12-20T19:49:34Z\",\r\n   \"alternativeLabels\": [" +
                    "\r\n       \"utilise brazing equipment\",\r\n       \"run brazing equipment\",\r\n       \"" +
                    "utilise welding torches\",\r\n       \"use welding torches\",\r\n       \"run welding to" +
                    "rches\",\r\n       \"use brazing equipment\",\r\n       \"handle brazing equipment\",\r\n  " +
                    "     \"handle welding torches\"\r\n   ],\r\n   \"uri\": \"http://data.europa.eu/esco/skil" +
                    "l/10f24e0d-bd23-4432-b96b-e9f23136c503\",\r\n   \"matches\": {\r\n       \"hiddenLabels\"" +
                    ": [],\r\n       \"skill\": [],\r\n       \"alternativeLabels\": [\r\n           \"utilise w" +
                    "elding torches\",\r\n           \"use welding torches\",\r\n           \"run welding tor" +
                    "ches\",\r\n           \"handle welding torches\"\r\n       ]\r\n   },\r\n   \"skillReusabili" +
                    "ty\": \"cross-sectoral\"\r\n},\r\n{\r\n   \"skillType\": \"knowledge\",\r\n   \"skill\": \"torch t" +
                    "emperature for metal processes\",\r\n   \"lastModified\": \"2017-01-05T13:52:33Z\",\r\n  " +
                    " \"alternativeLabels\": [\r\n       \"torch temperature for metal procedures\",\r\n     " +
                    "  \"torch temperature for metal working\",\r\n       \"correct heat for machine and t" +
                    "ool procedures\",\r\n       \"torch temperature for metal activities\",\r\n       \"corr" +
                    "ect heat for machine and tool working\",\r\n       \"torch temperature for metal ope" +
                    "rations\",\r\n       \"correct heat for machine and tool operations\",\r\n       \"corre" +
                    "ct heat for machine and tool activities\"\r\n   ],\r\n   \"uri\": \"http://data.europa.e" +
                    "u/esco/skill/46f2796e-e1b8-4210-95e2-d9a89af956e7\",\r\n   \"matches\": {\r\n       \"hi" +
                    "ddenLabels\": [],\r\n       \"skill\": [\r\n           \"torch temperature for metal pro" +
                    "cesses\"\r\n       ],\r\n       \"alternativeLabels\": [\r\n           \"torch temperature" +
                    " for metal procedures\",\r\n           \"torch temperature for metal working\",\r\n    " +
                    "       \"torch temperature for metal activities\",\r\n           \"torch temperature " +
                    "for metal operations\"\r\n       ]\r\n   },\r\n   \"skillReusability\": \"cross-sectoral\"\r" +
                    "\n},\r\n{\r\n   \"skillType\": \"competency\",\r\n   \"skill\": \"operate oxy-fuel cutting tor" +
                    "ch\",\r\n   \"lastModified\": \"2016-12-20T19:48:21Z\",\r\n   \"alternativeLabels\": [\r\n   " +
                    "    \"use oxy-fuel cutting torch\",\r\n       \"utilise oxyacetylene cutter\",\r\n      " +
                    " \"run oxyacetylene cutter\",\r\n       \"handle oxy-fuel cutting torch\",\r\n       \"us" +
                    "e oxyacetylene cutter\",\r\n       \"handle oxyacetylene cutter\",\r\n       \"utilise o" +
                    "xy-fuel cutting torch\",\r\n       \"run oxy-fuel cutting torch\"\r\n   ],\r\n   \"uri\": \"" +
                    "http://data.europa.eu/esco/skill/8b09c290-c941-4119-870f-bdafbd78c669\",\r\n   \"mat" +
                    "ches\": {\r\n       \"hiddenLabels\": [],\r\n       \"skill\": [\r\n           \"operate oxy" +
                    "-fuel cutting torch\"\r\n       ],\r\n       \"alternativeLabels\": [\r\n           \"use " +
                    "oxy-fuel cutting torch\",\r\n           \"handle oxy-fuel cutting torch\",\r\n         " +
                    "  \"utilise oxy-fuel cutting torch\",\r\n           \"run oxy-fuel cutting torch\"\r\n  " +
                    "     ]\r\n   },\r\n   \"skillReusability\": \"cross-sectoral\"\r\n},\r\n{\r\n   \"skillType\": \"" +
                    "competency\",\r\n   \"skill\": \"operate oxy-fuel welding torch\",\r\n   \"lastModified\": " +
                    "\"2016-12-20T19:50:07Z\",\r\n   \"alternativeLabels\": [\r\n       \"handle oxy-fuel weld" +
                    "ing torch equipment\",\r\n       \"operate oxyacetylene gas equipment\",\r\n       \"uti" +
                    "lise oxy-fuel welding torch equipment\",\r\n       \"handle oxyacetylene gas equipme" +
                    "nt\",\r\n       \"run oxy-fuel welding torch equipment\",\r\n       \"utilise oxyacetyle" +
                    "ne gas equipment\",\r\n       \"use oxy-fuel welding torch equipment\",\r\n       \"use " +
                    "oxyacetylene gas equipment\"\r\n   ],\r\n   \"uri\": \"http://data.europa.eu/esco/skill/" +
                    "14b4a40e-da80-452a-86d6-88a959052219\",\r\n   \"matches\": {\r\n       \"hiddenLabels\": " +
                    "[],\r\n       \"skill\": [\r\n           \"operate oxy-fuel welding torch\"\r\n       ],\r\n" +
                    "       \"alternativeLabels\": [\r\n           \"handle oxy-fuel welding torch equipme" +
                    "nt\",\r\n           \"utilise oxy-fuel welding torch equipment\",\r\n           \"run ox" +
                    "y-fuel welding torch equipment\",\r\n           \"use oxy-fuel welding torch equipme" +
                    "nt\"\r\n       ]\r\n   },\r\n   \"skillReusability\": \"cross-sectoral\"\r\n},\r\n{\r\n   \"skillT" +
                    "ype\": \"competency\",\r\n   \"skill\": \"operate oxygen cutting torch\",\r\n   \"lastModifi" +
                    "ed\": \"2016-12-20T18:23:07Z\",\r\n   \"alternativeLabels\": [\r\n       \"oxygen cutting " +
                    "torch operation\",\r\n       \"cutting metal with oxygen torch\",\r\n       \"metal cutt" +
                    "ing with oxygen torch\",\r\n       \"oxygen torch metal-cutting\",\r\n       \"operation" +
                    " of oxygen cutting torch\",\r\n       \"operating oxygen cutting torch\",\r\n       \"cu" +
                    "t metal with oxygen torch\"\r\n   ],\r\n   \"uri\": \"http://data.europa.eu/esco/skill/d" +
                    "7cab350-7eba-41cf-9c35-827b74541ce8\",\r\n   \"matches\": {\r\n       \"hiddenLabels\": [" +
                    "],\r\n       \"skill\": [\r\n           \"operate oxygen cutting torch\"\r\n       ],\r\n   " +
                    "    \"alternativeLabels\": [\r\n           \"oxygen cutting torch operation\",\r\n      " +
                    "     \"cutting metal with oxygen torch\",\r\n           \"metal cutting with oxygen t" +
                    "orch\",\r\n           \"oxygen torch metal-cutting\",\r\n           \"operation of oxyge" +
                    "n cutting torch\",\r\n           \"operating oxygen cutting torch\",\r\n           \"cut" +
                    " metal with oxygen torch\"\r\n       ]\r\n   },\r\n   \"skillReusability\": \"sector-speci" +
                    "fic\"\r\n},\r\n{\r\n   \"skillType\": \"competency\",\r\n   \"skill\": \"operate plasma cutting " +
                    "torch\",\r\n   \"lastModified\": \"2016-12-20T18:23:01Z\",\r\n   \"alternativeLabels\": [\r\n" +
                    "       \"use plasma cutter\",\r\n       \"cut with plasma torch\",\r\n       \"operating " +
                    "plasma cutting torch\",\r\n       \"plasma torch cutting\",\r\n       \"operation of pla" +
                    "sma cutting torch\",\r\n       \"plasma cutting torch operation\",\r\n       \"using pla" +
                    "sma cutter\"\r\n   ],\r\n   \"uri\": \"http://data.europa.eu/esco/skill/f1e122e5-24a8-44" +
                    "c0-bf3f-90044e72370c\",\r\n   \"matches\": {\r\n       \"hiddenLabels\": [],\r\n       \"ski" +
                    "ll\": [\r\n           \"operate plasma cutting torch\"\r\n       ],\r\n       \"alternativ" +
                    "eLabels\": [\r\n           \"cut with plasma torch\",\r\n           \"operating plasma c" +
                    "utting torch\",\r\n           \"plasma torch cutting\",\r\n           \"operation of pla" +
                    "sma cutting torch\",\r\n           \"plasma cutting torch operation\"\r\n       ]\r\n   }" +
                    ",\r\n   \"skillReusability\": \"sector-specific\"\r\n},\r\n{\r\n   \"skillType\": \"knowledge\"," +
                    "\r\n   \"skill\": \"plasma torches\",\r\n   \"lastModified\": \"2017-01-05T17:04:51Z\",\r\n   " +
                    "\"alternativeLabels\": [\r\n       \"plasma arc lamps\",\r\n       \"plasma beacons\",\r\n  " +
                    "     \"plasma arc beacons\",\r\n       \"plasma arc incendiaries\",\r\n       \"plasma la" +
                    "mps\",\r\n       \"plasma incendiaries\",\r\n       \"plasm lanterns\"\r\n   ],\r\n   \"uri\": " +
                    "\"http://data.europa.eu/esco/skill/3cb0d886-1b34-4941-a134-b84d8a17b8d5\",\r\n   \"ma" +
                    "tches\": {\r\n       \"hiddenLabels\": [],\r\n       \"skill\": [\r\n           \"plasma tor" +
                    "ches\"\r\n       ],\r\n       \"alternativeLabels\": []\r\n   },\r\n   \"skillReusability\": " +
                    "\"occupation-specific\"\r\n}\r\n]\r\n}         ", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search for a partial word")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void SearchForAPartialWord()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search for a partial word", null, new string[] {
                        "GetSkillsByLabel"});
#line 222
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 224
testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\" with reques" +
                    "t body", "{\r\n\"label\": \"ncendiari\",\r\n\"matchAltLabels\": \"true\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 232
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 233
    testRunner.And("the response json matches:", @"{
""skills"": [
    {
        ""skillType"": ""knowledge"",
        ""skill"": ""plasma torches"",
        ""lastModified"": ""2017-01-05T17:04:51Z"",
        ""alternativeLabels"": [
            ""plasma arc lamps"",
            ""plasma beacons"",
            ""plasma arc beacons"",
            ""plasma arc incendiaries"",
            ""plasma lamps"",
            ""plasma incendiaries"",
            ""plasm lanterns""
        ],
        ""uri"": ""http://data.europa.eu/esco/skill/3cb0d886-1b34-4941-a134-b84d8a17b8d5"",
        ""matches"": {
            ""hiddenLabels"": [],
            ""skill"": [],
            ""alternativeLabels"": [
                ""plasma arc incendiaries"",
                ""plasma incendiaries""
            ]
        },
        ""skillReusability"": ""occupation-specific""
    }
]
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search for a full word with alternate labels included")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void SearchForAFullWordWithAlternateLabelsIncluded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search for a full word with alternate labels included", null, new string[] {
                        "GetSkillsByLabel"});
#line 266
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 268
testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\" with reques" +
                    "t body", "{\r\n\"label\": \"cocktail\",\r\n\"matchAltLabels\": \"true\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 276
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 277
    testRunner.And("the response json matches:", "{\r\n    \"skills\": [\r\n        {\r\n            \"skillType\": \"competency\",\r\n          " +
                    "  \"skill\": \"prepare mixed beverages\",\r\n            \"lastModified\": \"2016-09-15T1" +
                    "0:50:50Z\",\r\n            \"alternativeLabels\": [\r\n                \"serve cocktails" +
                    "\",\r\n                \"mix and serve alcoholic and non-alcoholic beverages\",\r\n    " +
                    "            \"prepare a mix of beverages\"\r\n            ],\r\n            \"uri\": \"ht" +
                    "tp://data.europa.eu/esco/skill/81d5b408-e805-4788-8dbd-42f22e8fd199\",\r\n         " +
                    "   \"matches\": {\r\n                \"hiddenLabels\": [],\r\n                \"skill\": [" +
                    "],\r\n                \"alternativeLabels\": [\r\n                    \"serve cocktails" +
                    "\"\r\n                ]\r\n            },\r\n            \"skillReusability\": \"sector-sp" +
                    "ecific\"\r\n        },\r\n        {\r\n            \"skillType\": \"competency\",\r\n        " +
                    "    \"skill\": \"assemble cocktail garnishes\",\r\n            \"lastModified\": \"2016-0" +
                    "9-15T10:55:54Z\",\r\n            \"alternativeLabels\": [\r\n                \"choose va" +
                    "rious items to present cocktails\",\r\n                \"use different items to deco" +
                    "rate cocktails\",\r\n                \"assemble garnish for cocktails\",\r\n           " +
                    "     \"assemble garnishing for cocktails\"\r\n            ],\r\n            \"uri\": \"ht" +
                    "tp://data.europa.eu/esco/skill/f42df0af-c63b-41a7-815f-ab5eb85098e3\",\r\n         " +
                    "   \"matches\": {\r\n                \"hiddenLabels\": [],\r\n                \"skill\": [" +
                    "\r\n                    \"assemble cocktail garnishes\"\r\n                ],\r\n       " +
                    "         \"alternativeLabels\": [\r\n                    \"choose various items to pr" +
                    "esent cocktails\",\r\n                    \"use different items to decorate cocktail" +
                    "s\",\r\n                    \"assemble garnish for cocktails\",\r\n                    " +
                    "\"assemble garnishing for cocktails\"\r\n                ]\r\n            },\r\n        " +
                    "    \"skillReusability\": \"sector-specific\"\r\n        }\r\n    ]\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search where there are no matches")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void SearchWhereThereAreNoMatches()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search where there are no matches", null, new string[] {
                        "GetSkillsByLabel"});
#line 330
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 332
testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\" with reques" +
                    "t body", "{\r\n\"label\": \"bincendiari\",\r\n\"matchAltLabels\": \"true\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 340
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 341
    testRunner.And("the response json matches:", "{\r\n\"skills\": []\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Alt label search defaults to false")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void AltLabelSearchDefaultsToFalse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Alt label search defaults to false", null, new string[] {
                        "GetSkillsByLabel"});
#line 349
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 351
testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\" with reques" +
                    "t body", "{\r\n\"label\": \"ncendiari\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 358
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 359
    testRunner.And("the response json matches:", "{\r\n\"skills\": []\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search for that is only in alt labels without allowing alt label search")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void SearchForThatIsOnlyInAltLabelsWithoutAllowingAltLabelSearch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search for that is only in alt labels without allowing alt label search", null, new string[] {
                        "GetSkillsByLabel"});
#line 369
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 371
testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\" with reques" +
                    "t body", "{\r\n\"label\": \"ncendiari\",\r\n\"matchAltLabels\": \"false\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 379
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 380
    testRunner.And("the response json matches:", "{\r\n\"skills\": []\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search that returns skill with no alt labels")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void SearchThatReturnsSkillWithNoAltLabels()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search that returns skill with no alt labels", null, new string[] {
                        "GetSkillsByLabel"});
#line 389
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
#line 391
testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\" with reques" +
                    "t body", "{\r\n\"label\": \"manage budgets\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 398
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 399
    testRunner.And("the response json matches:", @"{
""skills"": [
    {
        ""skillType"": ""competency"",
        ""skill"": ""manage budgets"",
        ""lastModified"": ""2016-10-20T15:06:39Z"",
        ""alternativeLabels"": [],
        ""uri"": ""http://data.europa.eu/esco/skill/21c5790c-0930-4d74-b3b0-84caf5af12ea"",
        ""matches"": {
            ""hiddenLabels"": [],
            ""skill"": [
                ""manage budgets""
            ],
            ""alternativeLabels"": []
        },
        ""skillReusability"": ""cross-sectoral""
    },
    {
        ""skillType"": ""competency"",
        ""skill"": ""manage budgets for social services programs"",
        ""lastModified"": ""2016-12-20T19:29:40Z"",
        ""alternativeLabels"": [
            ""administer budgets in social services"",
            ""plan budgets for social services programmes"",
            ""manage budget for social services programs"",
            ""manage budgets for social services programmes"",
            ""manage budget for social services programme""
        ],
        ""uri"": ""http://data.europa.eu/esco/skill/d4eaa90c-598f-4453-a0b8-28345ba63bf2"",
        ""matches"": {
            ""hiddenLabels"": [],
            ""skill"": [
                ""manage budgets for social services programs""
            ],
            ""alternativeLabels"": [
                ""manage budgets for social services programmes""
            ]
        },
        ""skillReusability"": ""sector-specific""
    }
]
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Alt label value is supplied as parameter")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void AltLabelValueIsSuppliedAsParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Alt label value is supplied as parameter", null, new string[] {
                        "GetSkillsByLabel"});
#line 448
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 450
testRunner.Given("I want to supply \"?matchAltLabels=true\" as a parameter in the following request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 451
testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\" with reques" +
                    "t body", "{\r\n\"label\": \"cocktail\"\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 458
 testRunner.Then("the response code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 459
    testRunner.And("the response json matches:", "{\r\n    \"skills\": [\r\n        {\r\n            \"skillType\": \"competency\",\r\n          " +
                    "  \"skill\": \"prepare mixed beverages\",\r\n            \"lastModified\": \"2016-09-15T1" +
                    "0:50:50Z\",\r\n            \"alternativeLabels\": [\r\n                \"serve cocktails" +
                    "\",\r\n                \"mix and serve alcoholic and non-alcoholic beverages\",\r\n    " +
                    "            \"prepare a mix of beverages\"\r\n            ],\r\n            \"uri\": \"ht" +
                    "tp://data.europa.eu/esco/skill/81d5b408-e805-4788-8dbd-42f22e8fd199\",\r\n         " +
                    "   \"matches\": {\r\n                \"hiddenLabels\": [],\r\n                \"skill\": [" +
                    "],\r\n                \"alternativeLabels\": [\r\n                    \"serve cocktails" +
                    "\"\r\n                ]\r\n            },\r\n            \"skillReusability\": \"sector-sp" +
                    "ecific\"\r\n        },\r\n        {\r\n            \"skillType\": \"competency\",\r\n        " +
                    "    \"skill\": \"assemble cocktail garnishes\",\r\n            \"lastModified\": \"2016-0" +
                    "9-15T10:55:54Z\",\r\n            \"alternativeLabels\": [\r\n                \"choose va" +
                    "rious items to present cocktails\",\r\n                \"use different items to deco" +
                    "rate cocktails\",\r\n                \"assemble garnish for cocktails\",\r\n           " +
                    "     \"assemble garnishing for cocktails\"\r\n            ],\r\n            \"uri\": \"ht" +
                    "tp://data.europa.eu/esco/skill/f42df0af-c63b-41a7-815f-ab5eb85098e3\",\r\n         " +
                    "   \"matches\": {\r\n                \"hiddenLabels\": [],\r\n                \"skill\": [" +
                    "\r\n                    \"assemble cocktail garnishes\"\r\n                ],\r\n       " +
                    "         \"alternativeLabels\": [\r\n                    \"choose various items to pr" +
                    "esent cocktails\",\r\n                    \"use different items to decorate cocktail" +
                    "s\",\r\n                    \"assemble garnish for cocktails\",\r\n                    " +
                    "\"assemble garnishing for cocktails\"\r\n                ]\r\n            },\r\n        " +
                    "    \"skillReusability\": \"sector-specific\"\r\n        }\r\n    ]\r\n}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("No body is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void NoBodyIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No body is supplied", null, new string[] {
                        "GetSkillsByLabel"});
#line 515
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
#line 516
 testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\"", ((string)(null)), table16, "Given ");
#line 518
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 519
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid body is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void InvalidBodyIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid body is supplied", null, new string[] {
                        "GetSkillsByLabel"});
#line 523
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table17.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 524
 testRunner.Given("I make a request to the service taxonomy API \"getskillsbylabelsearch\"", ((string)(null)), table17, "Given ");
#line 527
    testRunner.Then("the response code is 400", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 528
    testRunner.And("the the response message is \"Unable to process supplied parameters\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Invalid security header is supplied")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void InvalidSecurityHeaderIsSupplied()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invalid security header is supplied", null, new string[] {
                        "GetSkillsByLabel"});
#line 533
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 534
    testRunner.Given("I want to supply an invalid security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table18.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 535
 testRunner.And("I make a request to the service taxonomy API \"getskillsbylabelsearch\"", ((string)(null)), table18, "And ");
#line 538
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 539
    testRunner.And("the response json matches:", "   {\r\n   \"statusCode\": 401,\r\n   \"message\": \"Access denied due to invalid subscrip" +
                    "tion key. Make sure to provide a valid key for an active subscription.\"\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Missing security header")]
        [NUnit.Framework.CategoryAttribute("GetSkillsByLabel")]
        public virtual void MissingSecurityHeader()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Missing security header", null, new string[] {
                        "GetSkillsByLabel"});
#line 549
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 550
    testRunner.Given("I want to fail to send a security header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "dataItem",
                        "value"});
            table19.AddRow(new string[] {
                        "skill",
                        "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222"});
#line 551
 testRunner.And("I make a request to the service taxonomy API \"getskillsbylabelsearch\"", ((string)(null)), table19, "And ");
#line 554
    testRunner.Then("the response code is 401", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 555
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
