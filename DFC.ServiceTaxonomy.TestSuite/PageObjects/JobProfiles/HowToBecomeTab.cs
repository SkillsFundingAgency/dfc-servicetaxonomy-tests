using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class HowToBecomeTab
    {
        private ScenarioContext _scenarioContext;
        public HowToBecomeTab(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        IWebElement tabHowToBecome => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".nav-tabs li:nth-of-type(3) > a"));
        IWebElement txtfldEntryRoutes => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Entryroutes_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldUniversityReleventSubjects => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Universityrelevantsubjects_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldUniversityFurtherRouteInfo => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Universityfurtherrouteinfo_Html'] + div > .trumbowyg-editor"));
        IWebElement dropdownUniversityEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Universityentryrequirements_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedUniversityRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relateduniversityrequirements_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedUniversityLinks => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relateduniversitylinks_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtfldCollegeRelevantSubjects => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Collegerelevantsubjects_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldCollegeFurtherRouteInfo => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Collegefurtherrouteinfo_Html'] + div > .trumbowyg-editor"));
        IWebElement dropdownCollegeEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Collegeentryrequirements_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedCollegeRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedcollegerequirements_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedCollegeLinks => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedcollegelinks_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtfldApprenticeshipReleventSubjects => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Apprenticeshiprelevantsubjects_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldApprenticeshipFurtherRouteInfo => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Apprenticeshipfurtherroutesinfo_Html'] + div > .trumbowyg-editor"));
        IWebElement dropdownApprenticeshipEntryRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Apprenticeshipentryrequirements_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedApprenticeshipRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedapprenticeshiprequirements_ContentItemIds + div > .multiselect__tags"));
        IWebElement dropdownRelatedApprenticeshipLinks => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedapprenticeshiplinks_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtfldWork => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Work_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldVolunteering => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Volunteering_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldDirectApplication => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Directapplication_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldOtherRoutes => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Otherroutes_Html'] + div > .trumbowyg-editor"));
        IWebElement dropdownRelatedRegistrations => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedregistrations_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtfldCareerTips => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Careertips_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldProfessionslAndIndustryBodies => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Professionalandindustrybodies_Html'] + div > .trumbowyg-editor"));
        IWebElement txtfldFurterInformation => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Furtherinformation_Html'] + div > .trumbowyg-editor"));

        public void DisplayHowToBecomeTab()
        {
            Utilities.Hover(_scenarioContext.GetWebDriver(), tabHowToBecome);
            tabHowToBecome.Click();
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "University entry requirements":
                    dropdownUniversityEntryRequirements.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Universityentryrequirements_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related university requirements":
                    dropdownRelatedUniversityRequirements.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relateduniversityrequirements_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related university links":
                    dropdownRelatedUniversityLinks.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relateduniversitylinks_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "College entry requirements":
                    dropdownCollegeEntryRequirements.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Collegeentryrequirements_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related college requirements":
                    dropdownRelatedCollegeRequirements.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedcollegerequirements_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related college links":
                    dropdownRelatedCollegeLinks.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedcollegelinks_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Apprenticeship entry requirements":
                    dropdownApprenticeshipEntryRequirements.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Apprenticeshipentryrequirements_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related apprenticeship requirements":
                    dropdownRelatedApprenticeshipRequirements.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedapprenticeshiprequirements_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related apprenticeship links":
                    dropdownRelatedApprenticeshipLinks.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedapprenticeshiplinks_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Related registrations":
                    dropdownRelatedRegistrations.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedregistrations_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
            }
        }

        public void TextEntry(string textToEnter, string field)
        {
            switch (field)
            {
                case "Entry routes":
                    Utilities.Wait(_scenarioContext.GetWebDriver(), txtfldEntryRoutes);
                    txtfldEntryRoutes.SendKeys(textToEnter);
                    break;
                case "University relevant subjects":
                    txtfldUniversityReleventSubjects.SendKeys(textToEnter);
                    break;
                case "University further route info":
                    txtfldUniversityFurtherRouteInfo.SendKeys(textToEnter);
                    break;
                case "College relevant subjects":
                    txtfldCollegeRelevantSubjects.SendKeys(textToEnter);
                    break;
                case "College further route info":
                    txtfldCollegeFurtherRouteInfo.SendKeys(textToEnter);
                    break;
                case "Apprenticeship relevent subjects":
                    txtfldApprenticeshipReleventSubjects.SendKeys(textToEnter);
                    break;
                case "Apprenticeship further route info":
                    txtfldApprenticeshipFurtherRouteInfo.SendKeys(textToEnter);
                    break;
                case "Work":
                    txtfldWork.SendKeys(textToEnter);
                    break;
                case "Volunteering":
                    txtfldVolunteering.SendKeys(textToEnter);
                    break;
                case "Direct application":
                    txtfldDirectApplication.SendKeys(textToEnter);
                    break;
                case "Other routes":
                    txtfldOtherRoutes.SendKeys(textToEnter);
                    break;
                case "Career tips":
                    txtfldCareerTips.SendKeys(textToEnter);
                    break;
                case "Professional and industry bodies":
                    txtfldProfessionslAndIndustryBodies.SendKeys(textToEnter);
                    break;
                case "Further information":
                    txtfldFurterInformation.SendKeys(textToEnter);
                    break;
            }
        }
    }

}
