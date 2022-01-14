using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class JobProfiles
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SideNavigator _sideNavigator;
        private readonly JobProfileSpecialism _jobProfileSpecialism;
        private readonly JobProfileCategory _jobProfileCategory;
        private readonly SocCode _socCode;
        private readonly WorkingHoursDetail _workingHoursDetail;
        private readonly WorkingPatternDetail _workingPatternDetail;
        private readonly WorkingPatterns _workingPatterns;
        private readonly UniversityEntryRequirements _universityEntryRequirements;
        private readonly UniversityRequirements _universityRequirements;
        private readonly UniversityLinks _universityLinks;
        private readonly CollegeEntryRequirements _collegeEntryRequirements;
        private readonly CollegeRequirements _collegeRequirements;
        private readonly CollegeLink _collegeLink;
        private readonly ApprenticeshipEntryRequirements _apprenticeshipEntryRequirements;
        private readonly ApprenticeshipRequirements _apprenticeshipRequirements;
        private readonly ApprenticeshipLink _apprenticeshipLink;
        private readonly Registration _registration;
        private readonly Restriction _restriction;
        private readonly DigitalSkills _digitalSkills;
        private readonly Location _location;
        private readonly PageObjects.Environment _environment;
        private readonly Uniform _uniform;
        private readonly MetaDataTab _metaDataTab;
        private readonly HeaderTab _headerTab;


        public JobProfiles(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sideNavigator = new SideNavigator(scenarioContext);
            _jobProfileSpecialism = new JobProfileSpecialism(scenarioContext);
            _jobProfileCategory = new JobProfileCategory(scenarioContext);
            _socCode = new SocCode(scenarioContext);
            _workingHoursDetail = new WorkingHoursDetail(scenarioContext);
            _workingPatternDetail = new WorkingPatternDetail(scenarioContext);
            _workingPatterns = new WorkingPatterns(scenarioContext);
            _universityEntryRequirements = new UniversityEntryRequirements(scenarioContext);
            _universityRequirements = new UniversityRequirements(scenarioContext);
            _universityLinks = new UniversityLinks(scenarioContext);
            _collegeEntryRequirements = new CollegeEntryRequirements(scenarioContext);
            _collegeRequirements = new CollegeRequirements(scenarioContext);
            _collegeLink = new CollegeLink(scenarioContext);
            _apprenticeshipEntryRequirements = new ApprenticeshipEntryRequirements(scenarioContext);
            _apprenticeshipRequirements = new ApprenticeshipRequirements(scenarioContext);
            _apprenticeshipLink = new ApprenticeshipLink(scenarioContext);
            _registration = new Registration(scenarioContext);
            _restriction = new Restriction(scenarioContext);
            _digitalSkills = new DigitalSkills(scenarioContext);
            _location = new Location(scenarioContext);
            _environment = new PageObjects.Environment(scenarioContext);
            _uniform = new Uniform(scenarioContext);
            _metaDataTab = new MetaDataTab(scenarioContext);
            _headerTab = new HeaderTab(scenarioContext);
        }

        [Given(@"I create the following number of Content Types")]
        public void GivenICreateTheFollowingNumberOfContentTypes(Table table)
        {
            var contents = table.CreateSet<ContentTypes>();
            string descriptionText = "This is the test for content item with title ";

            foreach (ContentTypes contentType in contents)
            {
                switch (contentType.contentType)
                {
                    case "Job profile specialism":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickSideNavNew();
                            _sideNavigator.ClickJobProfileSpecialism();
                            _jobProfileSpecialism.EnterTitle("x2 JPS");
                            _jobProfileSpecialism.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Job profile category":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickJobProfileCategory();
                            _jobProfileSpecialism.EnterTitle("x2 JPC");
                            _jobProfileCategory.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "SOC code":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickSocCode();
                            _jobProfileSpecialism.EnterTitle("x2 SC");
                            _socCode.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Working hours detail":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickWorkingHoursDetail();
                            _jobProfileSpecialism.EnterTitle("x2 WHD");
                            _workingHoursDetail.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Working pattern detail":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickWorkingPatternDetail();
                            _jobProfileSpecialism.EnterTitle("x2 WPD");
                            _workingPatternDetail.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Working patterns":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickWorkingPatterns();
                            _jobProfileSpecialism.EnterTitle("x2 WP");
                            _workingPatterns.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "University entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickUniversityEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("x2 UER");
                            _universityEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "University requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            
                            _sideNavigator.ClickUniversityRequirements();
                            _jobProfileSpecialism.EnterTitle("x2 UR");
                            _universityRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "University link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickUniversityLinks();
                            _jobProfileSpecialism.EnterTitle("x2 UL");
                            _universityLinks.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "College entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickCollegeEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("x2 CER");
                            _collegeEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "College requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            
                            _sideNavigator.ClickCollegeRequirements();
                            _jobProfileSpecialism.EnterTitle("x2 CR");
                            _collegeRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break; 
                    case "College link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickCollegeLink();
                            _jobProfileSpecialism.EnterTitle("x2 CL");
                            _collegeLink.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Apprenticeship entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClicklinkApprenticeshipEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("x2 AER");
                            _apprenticeshipEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Apprenticeship requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClicklinkApprenticeshipRequirements();
                            _jobProfileSpecialism.EnterTitle("x2 AR");
                            _apprenticeshipRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Apprenticeship link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickApprenticeshipLink();
                            _jobProfileSpecialism.EnterTitle("x2 AL");
                            _apprenticeshipLink.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Registration":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickRegistration();
                            _jobProfileSpecialism.EnterTitle("x2 Reg");
                            _registration.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Restriction":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickRestriction();
                            _jobProfileSpecialism.EnterTitle("x2 Res");
                            _restriction.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Digital skills":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickDigitalSkills();
                            _digitalSkills.EnterTitle("x2 DS");
                            _digitalSkills.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Location":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickLocation();
                            _jobProfileSpecialism.EnterTitle("x2 Loc");
                            _location.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Environment":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickEnvironment();
                            _jobProfileSpecialism.EnterTitle("x2 Env");
                            _environment.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Uniform":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickUniform();
                            _jobProfileSpecialism.EnterTitle("x2 Uni");
                            _uniform.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                }
            }
        }

        [Given(@"I start a new Job Profile type")]
        public void GivenIStartANewJobProfileType()
        {
            _sideNavigator.ClickJobProfile();
        }

        [Given(@"I enter ""(.*)"" plus an eight digit random alphanumeric into the Title field")]
        public void GivenIEnterPlusAnEightDigitRandomAlphanumericIntoTheTitleField(string title)
        {
            _digitalSkills.EnterTitle("JP");
        }

        [Given(@"I select ""(.*)"" from the Dynamic Title Prefix dropdown field")]
        public void GivenISelectFromTheDynamicTitlePrefixDropdownField(string selectionDynamicTitlePrefix)
        {
            _metaDataTab.SelectDynamicTitlePrefix(selectionDynamicTitlePrefix);
        }

        [Given(@"I select option ""(.*)"" from the Job Profile Specialism dropdown field")]
        public void GivenISelectOptionFromTheJobProfileSpecialismDropdownField(string selectionJobProfileSpecialism)
        {
            _metaDataTab.SelectJobProfileSpecialism(selectionJobProfileSpecialism);
        }

        [Given(@"I select option ""(.*)"" from the Job Profile Category dropdown field")]
        public void GivenISelectOptionFromTheJobProfileCategoryDropdownField(string selectionJobProfileCategory)
        {
            _metaDataTab.SelectJobProfileCategory(selectionJobProfileCategory);
        }

        [Given(@"I enter ""(.*)"" into the Course Keywords field")]
        public void GivenIEnterIntoTheCourseKeywordsField(string courseKeywords)
        {
            _metaDataTab.EnterCourseKeywords(courseKeywords);
        }

        [Given(@"I select option ""(.*)"" from the SOC code dropdown field")]
        public void GivenISelectOptionFromTheSOCCodeDropdownField(string socCode)
        {
            _metaDataTab.EnterSocCode(socCode);
        }

        [Given(@"I select option ""(.*)"" from the Related Careers Profiles dropdown field")]
        public void GivenISelectOptionFromTheRelatedCareersProfilesDropdownField(string relatedCareersProfiles)
        {
            _metaDataTab.SelectRelatedCareersProfiles(relatedCareersProfiles);
        }

        /*HEADER TAB*/
        [Given(@"I enter ""(.*)"" into the Alternative title field")]
        public void GivenIEnterIntoTheAlternativeTitleField(string alternativeTitle)
        {
            _headerTab.EnterAlternativeTitle(alternativeTitle);
        }

        [Given(@"I select option ""(.*)"" from the Hidden Alternative Title dropdown field")]
        public void GivenISelectOptionFromTheHiddenAlternativeTitleDropdownField(string optionHiddenAlternative)
        {
            _headerTab.SelectHiddenAlternativeTitle(optionHiddenAlternative);
        }

        [Given(@"I enter ""(.*)"" into the Widget content title field")]
        public void GivenIEnterIntoTheWidgetContentTitleField(string widgetContentTitle)
        {
            _headerTab.EntertWidgetContentTitle(widgetContentTitle);
        }

        [Given(@"I enter ""(.*)"" into the Overview field")]
        public void GivenIEnterIntoTheOverviewField(string overview)
        {
            _headerTab.EnterOverview(overview);
        }

        [Given(@"I enter ""(.*)"" into the Salary starter per year field")]
        public void GivenIEnterIntoTheSalaryStarterPerYearField(string salaryStarterPerYear)
        {
            _headerTab.EnterSalaryStarter(salaryStarterPerYear);
        }

        [Given(@"I enter ""(.*)"" into the Salary experienced per year field")]
        public void GivenIEnterIntoTheSalaryExperiencedPerYearField(string salaryExperiencedPerYear)
        {
            _headerTab.EnterSalaryExperienced(salaryExperiencedPerYear);
        }

        [Given(@"I enter ""(.*)"" into the Minimum hours field")]
        public void GivenIEnterIntoTheMinimumHoursField(string minimumHours)
        {
            _headerTab.EnterMinimumHours(minimumHours);
        }

        [Given(@"I enter ""(.*)"" into the Maximum hours field")]
        public void GivenIEnterIntoTheMaximumHoursField(string maximumHours)
        {
            _headerTab.EnterMaximumHours(maximumHours);
        }

        [Given(@"I select option ""(.*)"" from the Working hours details dropdown field")]
        public void GivenISelectOptionFromTheWorkingHoursDetailsDropdownField(string optionWorkingHoursDetails)
        {
            _headerTab.SelectWorkingHoursDetails(optionWorkingHoursDetails);
        }

        [Given(@"I select option ""(.*)"" from the Working pattern dropdown field")]
        public void GivenISelectOptionFromTheWorkingPatternDropdownField(string optionWorkingPattern)
        {
            _headerTab.SelectWorkingPattern(optionWorkingPattern);
        }

        [Given(@"I select option ""(.*)"" from the Working pattern details dropdown field")]
        public void GivenISelectOptionFromTheWorkingPatternDetailsDropdownField(string optionWorkingPatternDetails)
        {
            _headerTab.SelecetWorkingPatternDetails(optionWorkingPatternDetails);
        }


    }

    public class ContentTypes
    {
        public string contentType;
        public int number;
    }

    

}
