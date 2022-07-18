using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles;
using NUnit.Framework;
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
        private readonly HowToBecomeTab _howToBecomeTab; 
        private readonly WhatItTakesTab _whatItTakesTab;
        private readonly WhatYoullDoTab _whatYoullDoTab;
        private readonly CareersAndProgressionTab _careersAndProgressionTab;
        private readonly ContentTab _content;
        private readonly JobProfilesPage _jobProfilesPage; 
        private readonly ManageContent _manageContent;

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
            _howToBecomeTab = new HowToBecomeTab(scenarioContext);
            _whatItTakesTab = new WhatItTakesTab(scenarioContext);
            _whatYoullDoTab = new WhatYoullDoTab(scenarioContext);
            _careersAndProgressionTab = new CareersAndProgressionTab(scenarioContext);
            _content = new ContentTab(scenarioContext);
            _jobProfilesPage = new JobProfilesPage(scenarioContext);
            _manageContent = new ManageContent(scenarioContext);
        }

        [Given(@"I create the following number of Content Types")]
        public void GivenICreateTheFollowingNumberOfContentTypes(Table table)
        {
            var contents = table.CreateSet<ContentTypes>();
            string descriptionText = "This is the test for content item with title ";

            _sideNavigator.ClickSideNavNew();

            foreach (ContentTypes contentType in contents)
            {
                switch (contentType.contentType)
                {
                    case "Job profile specialism":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickJobProfileSpecialism();
                            _jobProfileSpecialism.EnterTitle("x3 JPS");
                            _jobProfileSpecialism.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Job profile category":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickJobProfileCategory();
                            _jobProfileSpecialism.EnterTitle("x3 JPC");
                            _jobProfileCategory.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "SOC code":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickSocCode();
                            _jobProfileSpecialism.EnterTitle("x3 SC");
                            _socCode.EnterDescription(descriptionText);
                            _socCode.EnterOnetOccupationCode("29-1126.00");
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Working hours detail":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickWorkingHoursDetail();
                            _jobProfileSpecialism.EnterTitle("x3 WHD");
                            _workingHoursDetail.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Working pattern detail":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickWorkingPatternDetail();
                            _jobProfileSpecialism.EnterTitle("x3 WPD");
                            _workingPatternDetail.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Working patterns":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickWorkingPatterns();
                            _jobProfileSpecialism.EnterTitle("x3 WP");
                            _workingPatterns.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "University entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickUniversityEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("x3 UER");
                            _universityEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "University requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickUniversityRequirements();
                            _jobProfileSpecialism.EnterTitle("x3 UR");
                            _universityRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "University link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickUniversityLinks();
                            _jobProfileSpecialism.EnterTitle("x3 UL");
                            _universityLinks.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "College entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickCollegeEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("x3 CER");
                            _collegeEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "College requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {

                            _sideNavigator.ClickCollegeRequirements();
                            _jobProfileSpecialism.EnterTitle("x3 CR");
                            _collegeRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "College link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickCollegeLink();
                            _jobProfileSpecialism.EnterTitle("x3 CL");
                            _collegeLink.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Apprenticeship entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClicklinkApprenticeshipEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("x3 AER");
                            _apprenticeshipEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Apprenticeship requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClicklinkApprenticeshipRequirements();
                            _jobProfileSpecialism.EnterTitle("x3 AR");
                            _apprenticeshipRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Apprenticeship link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickApprenticeshipLink();
                            _jobProfileSpecialism.EnterTitle("x3 AL");
                            _apprenticeshipLink.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Registration":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickRegistration();
                            _jobProfileSpecialism.EnterTitle("x3 Reg");
                            _registration.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Restriction":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickRestriction();
                            _jobProfileSpecialism.EnterTitle("x3 Res");
                            _restriction.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Digital skills":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickDigitalSkills();
                            _digitalSkills.EnterTitle("x3 DS");
                            _digitalSkills.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Location":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickLocation();
                            _jobProfileSpecialism.EnterTitle("x3 Loc");
                            _location.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Environment":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickEnvironment();
                            _jobProfileSpecialism.EnterTitle("x3 Env");
                            _environment.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
                        }
                        break;
                    case "Uniform":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickUniform();
                            _jobProfileSpecialism.EnterTitle("x3 Uni");
                            _uniform.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                            _jobProfileSpecialism.ClickPublishAndContinue();
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

        [Given(@"I select option ""(.*)"" from the ""(.*)"" dropdown field")]
        public void GivenISelectOptionFromTheDropdownField(string option, string field)
        {
            _metaDataTab.OptionSelection(option, field);
        }

        [Given(@"I enter ""(.*)"" into the ""(.*)"" field")]
        public void GivenIEnterIntoTheField(string textToEnter, string field)
        {
            _metaDataTab.TextEntry(textToEnter, field);
        }

        [Given(@"I switch to the Header tab")]
        public void GivenISwitchToTheHeaderTab()
        {
            _headerTab.DisplayHeaderTab();
        }

        [Given(@"I enter ""(.*)"" into the ""(.*)"" field of the Header tab")]
        public void GivenIEnterIntoTheFieldOfTheHeaderTab(string textToEnter, string field)
        {
            _headerTab.TextEntry(textToEnter, field);
        }

        [Given(@"I select option ""(.*)"" from the ""(.*)"" dropdown field of the Header tab")]
        public void GivenISelectOptionFromTheDropdownFieldOfTheHeaderTab(string option, string field)
        {
            _headerTab.OptionSelection(option, field);
        }

        [Given(@"I switch to the How to become tab")]
        public void GivenISwitchToTheHowToBecomeTab()
        {
            _howToBecomeTab.DisplayHowToBecomeTab();
        }

        [Given(@"I enter ""(.*)"" into the ""(.*)"" field of the How to become tab")]
        public void GivenIEnterIntoTheFieldOfTheHowToBecomeTab(string textToEnter, string field)
        {
            _howToBecomeTab.TextEntry(textToEnter, field);
        }

        [Given(@"I select option ""(.*)"" from the ""(.*)"" dropdown field of the How to become tab")]
        public void GivenISelectOptionFromTheDropdownFieldOfTheHowToBecomeTab(string option, string field)
        {
            _howToBecomeTab.OptionSelection(option, field);
        }

        [Given(@"I switch to the What it takes tab")]
        public void GivenISwitchToTheWhatItTakesTab()
        {
            _whatItTakesTab.DisplayWhatItTakesTab();
        }

        [Given(@"I select option ""(.*)"" from the ""(.*)"" dropdown field of the What it takes tab")]
        public void GivenISelectOptionFromTheDropdownFieldOfTheWhatItTakesTab(string option, string field)
        {
            _whatItTakesTab.OptionSelection(option, field);
        }

        [Given(@"I enter ""(.*)"" into the ""(.*)"" field of the What it takes tab")]
        public void GivenIEnterIntoTheFieldOfTheWhatItTakesTab(string textToEnter, string field)
        {
            _whatItTakesTab.TextEntry(textToEnter, field);
        }

        [Given(@"I switch to the What youll do tab")]
        public void GivenISwitchToTheWhatYoullDoTab()
        {
            _whatYoullDoTab.DisplayWhatYoullDo();
        }

        [Given(@"I enter ""(.*)"" into the ""(.*)"" field of the What youll do tab")]
        public void GivenIEnterIntoTheFieldOfTheWhatYoullDoTab(string textToEnter, string field)
        {
            _whatYoullDoTab.TextEntry(textToEnter, field);
        }

        [Given(@"I select option ""(.*)"" from the ""(.*)"" dropdown field of the What youll do tab")]
        public void GivenISelectOptionFromTheDropdownFieldOfTheWhatYoullDoTab(string option, string field)
        {
            _whatYoullDoTab.OptionSelection(option, field);
        }

        [Given(@"I switch to the Career path and progression tab")]
        public void GivenISwitchToTheCareerPathAndProgressionTab()
        {
            _careersAndProgressionTab.DisplayCareerPathAndProgression();
        }

        [Given(@"I enter ""(.*)"" into the ""(.*)"" field of the Career path and progression tab")]
        public void GivenIEnterIntoTheFieldOfTheCareerPathAndProgressionTab(string textToEnter, string field)
        {
            _careersAndProgressionTab.TextEntry(textToEnter, field);
        }

        [Given(@"I switch to the Content tab")]
        public void GivenISwitchToTheContentTab()
        {
            _content.DisplayContent();
        }

        [Given(@"I tick the ""(.*)"" tick box of the Content tab")]
        public void GivenITickTheTickBoxOfTheContentTab(string tickBox)
        {
            _content.TickUntick(tickBox);
        }

        [Given(@"I select ""(.*)"" from the ""(.*)"" dropdown field of the Content tab")]
        public void GivenISelectFromTheDropdownFieldOfTheContentTab(string option, string field)
        {
            _content.OptionSelection(option, field);
        }

        [Given(@"I select option ""(.*)"" from the ""(.*)"" dropdown field of the Content tab")]
        public void GivenISelectOptionFromTheDropdownFieldOfTheContentTab(string option, string field)
        {
            _content.OptionSelection(option, field);
        }

        [Given(@"I click the Save Draft and Continue button")]
        public void GivenIClickTheSaveDraftAndContinueButton()
        {
            _jobProfilesPage.ClickSaveDraftAndContinue();
        }

        [When(@"I click the Publish and Exit button after entering a comment")]
        public void WhenIClickThePublishAndExitButtonAfterEnteringAComment()
        {
            _content.DisplayContent();
            _content.TextEntry("auto test");
            _jobProfilesPage.PublishAndExit();
        }

        [Then(@"the Job profile is created")]
        public void ThenTheJobProfileIsCreated()
        {
            Assert.True(_manageContent.ItemsCompare(), "This particular item title has not been found");
        }

        [Then(@"the job profile is in ""(.*)"" status")]
        public void ThenTheJobProfileIsInStatus(string contentItemTypeStatus)
        {
            Assert.IsTrue(_manageContent.VerifyContentItemTypeStatus(contentItemTypeStatus), "The content item,type is not in " + contentItemTypeStatus + "status.");

            //_manageContent.CleanUpManageContent();
        }
    }

    public class ContentTypes
    {
        public string contentType;
        public int number;
    }

    

}
