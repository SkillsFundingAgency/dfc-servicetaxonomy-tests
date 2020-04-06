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
namespace DFC.ServiceTaxonomy.TestSuite.Features.Editor.Import
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ImportRecipes")]
    [NUnit.Framework.CategoryAttribute("longrunning")]
    [NUnit.Framework.CategoryAttribute("webtest")]
    public partial class ImportRecipesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ImportRecipes.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ImportRecipes", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, new string[] {
                        "longrunning",
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
        [NUnit.Framework.DescriptionAttribute("Load the files")]
        public virtual void LoadTheFiles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load the files", null, ((string[])(null)));
#line 9
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 10
 testRunner.Given("I logon to the editor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.Given("I Navigate to \"/Admin/DeploymentPlan/Import/Index\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\14. QCFLevels0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\15. ApprenticeshipStandardRoutes0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\16. ApprenticeshipStandards0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\17. RequirementsPrefixes0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\18. ApprenticeshipLinks0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\19. ApprenticeshipRequirements0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\20. CollegeLinks0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\21. CollegeRequirements0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\22. UniversityLinks0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\23. UniversityRequirements0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\24. DayToDayTasks0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\25. DayToDayTasks1.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\26. DayToDayTasks2.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\27. DayToDayTasks3.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\28. DayToDayTasks4.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\29. DayToDayTasks5.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\30. DayToDayTasks6.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\31. OtherRequirements0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\32. Registrations0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\33. Restrictions0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\34. SocCodes0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\35. WorkingEnvironments0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\36. WorkingLocations0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\37. WorkingUniforms0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\38. JobProfiles0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\39. JobProfiles1.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\40. JobProfiles2.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\41. JobProfiles3.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\42. JobProfiles4.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\43. JobCategories0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Load the 18 files")]
        public virtual void LoadThe18Files()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load the 18 files", null, ((string[])(null)));
#line 45
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 46
 testRunner.Given("I logon to the editor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
 testRunner.Given("I Navigate to \"/Admin/DeploymentPlan/Import/Index\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\15. QCFLevels0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\16. ApprenticeshipStandardRoutes0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\17. ApprenticeshipStandards0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\18. RequirementsPrefixes0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\19. ApprenticeshipLinks0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\20. ApprenticeshipRequirements0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\21. CollegeLinks0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\22. CollegeRequirements0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\23. UniversityLinks0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\24. UniversityRequirements0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\25. DayToDayTasks0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\26. SocCodes0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\27. WorkingEnvironments0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\28. WorkingLocations0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\29. WorkingUniforms0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\30. JobProfiles0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("Load the file \"F:\\recipeFiles\\20200330_18\\31. JobCategories0.zip\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Load from import file")]
        public virtual void LoadFromImportFile()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Load from import file", null, ((string[])(null)));
#line 66
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 67
 testRunner.Given("I logon to the editor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 68
 testRunner.And("I import recipes from the file \"content items count.txt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
