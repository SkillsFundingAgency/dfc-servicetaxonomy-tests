using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
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
            _apprenticeshipLink = new ApprenticeshipLink(scenarioContext);
            _registration = new Registration(scenarioContext);
            _restriction = new Restriction(scenarioContext);
            _digitalSkills = new DigitalSkills(scenarioContext);
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
                            //WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Job profile specialism')]"));
                            _sideNavigator.ClickJobProfileSpecialism();
                            _jobProfileSpecialism.EnterTitle("JPS");
                            _jobProfileSpecialism.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Job profile category":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Job profile category')]"));
                            _sideNavigator.ClickJobProfileCategory();
                            _jobProfileSpecialism.EnterTitle("JPC");
                            _jobProfileCategory.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "SOC code":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'SOC code')]"));
                            _sideNavigator.ClickSocCode();
                            _jobProfileSpecialism.EnterTitle("SC");
                            _socCode.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Working hours detail":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Working hours detail')]"));
                            _sideNavigator.ClickWorkingHoursDetail();
                            _jobProfileSpecialism.EnterTitle("WHD");
                            _workingHoursDetail.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Working pattern detail":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Working pattern detail')]"));
                            _sideNavigator.ClickWorkingPatternDetail();
                            _jobProfileSpecialism.EnterTitle("WPD");
                            _workingPatternDetail.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Working patterns":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Working patterns')]"));
                            _sideNavigator.ClickWorkingPatterns();
                            _jobProfileSpecialism.EnterTitle("WP");
                            _workingPatterns.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "University entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'University entry requirements')]"));
                            _sideNavigator.ClickUniversityEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("UER");
                            _universityEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "University requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'University requirements')]"));
                            _sideNavigator.ClickUniversityRequirements();
                            _jobProfileSpecialism.EnterTitle("UR");
                            _universityRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "University link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'University link')]"));
                            _sideNavigator.ClickUniversityLinks();
                            _jobProfileSpecialism.EnterTitle("UL");
                            _universityLinks.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "College entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'College entry requirements')]"));
                            _sideNavigator.ClickCollegeEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("CER");
                            _collegeEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "College requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'College requirements')]"));
                            _sideNavigator.ClickCollegeRequirements();
                            _jobProfileSpecialism.EnterTitle("CR");
                            _collegeRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break; 
                    case "College link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickCollegeLink();
                            _jobProfileSpecialism.EnterTitle("CL");
                            _collegeLink.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Apprenticeship entry requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClicklinkApprenticeshipEntryRequirements();
                            _jobProfileSpecialism.EnterTitle("AER");
                            _apprenticeshipEntryRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Apprenticeship requirements":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClicklinkApprenticeshipRequirements();
                            _jobProfileSpecialism.EnterTitle("AR");
                            _apprenticeshipRequirements.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Apprenticeship link":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickApprenticeshipLink();
                            _jobProfileSpecialism.EnterTitle("AL");
                            _apprenticeshipLink.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Registration":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickRegistration();
                            _jobProfileSpecialism.EnterTitle("Reg");
                            _registration.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Restriction":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickRestriction();
                            _jobProfileSpecialism.EnterTitle("Res");
                            _restriction.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Digital skills":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickDigitalSkills();
                            _digitalSkills.EnterTitle("DS");
                            _digitalSkills.EnterDescription(descriptionText);
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                }
            }
        }

    }

    public class ContentTypes
    {
        public string contentType;
        public int number;
    }
}
