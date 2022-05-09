using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public class ManageContentSteps
    {
        private readonly ManageContent _manageContent;
        private readonly WhatItTakesTab _whatItTakesTab;
        private readonly GetData _getData;
        private readonly ContentTab _content;
        private readonly JobProfilesPage _jobProfilesPage;
        private string _dataFile;
        private string _contentType;
        private string _jobProfile;
        private bool _skillsInSequence;
        IList<RelatedSkills> _relatedSkills;
        private string filePath = Directory.GetParent(@"../../../../").FullName + Path.DirectorySeparatorChar + "Features" + "\\" + "Editor" + "\\" + "Import" + "\\";

        public ManageContentSteps(ScenarioContext context)
        {
            _manageContent = new ManageContent(context);
            _getData = new GetData(context);
            _whatItTakesTab = new WhatItTakesTab(context);
            _content = new ContentTab(context);
            _jobProfilesPage = new JobProfilesPage(context);
        }

        [Given(@"I search under (.*) for the text (.*)")]
        public void GivenISearchForTheText(string contentType, string text)
        {
            _manageContent.FindItem($"\"{text}\" type:{contentType}");
        }

        [Given(@"I search for the text (.*)")]
        public void GivenISearchForTheText(string text)
        {
            _manageContent.FindItem($"{text} type:DynamicTitlePrefix");
        }

        [Given(@"I click on the link with text (.*)")]
        [When(@"I click on the link with text (.*)")]
        public void WhenIClickOnTheLinkWithText(string text)
        {
            _manageContent.SelectFirstMatchedLink(text);
        }

        [Given(@"I search under (.*) using Title text (.*)")]
        public void GivenISearchUnderUsingTitleText(string contentType, string jobProfile)
        {
            _contentType = contentType;
            _jobProfile = jobProfile;
            _manageContent.FindItem($"\"{jobProfile}\" type:{contentType}");
        }

        [Given(@"I obtain the expected Related skills order from file ""(.*)""")]
        public void GivenIObtainTheExpectedRelatedSkillsOrderFromFile(string dataFile)
        {
            _relatedSkills = (IList<RelatedSkills>)_getData.GetJsonData(filePath + dataFile + ".json");
        }

        [When(@"I compare that with the Related skills ordering in the UI")]
        public void WhenICompareThatWithTheRelatedSkillsOrderingInTheUI()
        {
            _whatItTakesTab.RelatedSkillInSequence(_contentType, _jobProfile, _relatedSkills);
        }

        [Then(@"the order is the same")]
        public void ThenTheOrderIsTheSame()
        {
            //Assert.IsTrue(_whatItTakesTab.RelatedSkillsInSequence, "Related skill not in sequence for " + _jobProfile);
            _skillsInSequence = _whatItTakesTab.RelatedSkillsInSequence;
        }

        [Then(@"if it is not then I rearrange them to be the same")]
        public void ThenIfItIsNotThenIRearrangeThemToBeTheSame()
        {
            _skillsInSequence = _whatItTakesTab.RelatedSkillsInSequence;

            if (_skillsInSequence == false)
            {
                _whatItTakesTab.RearrangeRelatedSkill();
                _whatItTakesTab.RelatedSkillInSequence(_contentType, _jobProfile, _relatedSkills);
                Assert.IsTrue(_whatItTakesTab.RelatedSkillsInSequence, "Related skill not in sequence for " + _jobProfile);
            }
        }

        [Then(@"I Save and Publish after entering a comment for this (.*) Related skills order task")]
        public void ThenISaveAndPublishAfterEnteringACommentForThisDPrintingTechnicianRelatedSkillsOrderTask(string jobProfile)
        {
            if (_skillsInSequence == false)
            {
                _jobProfilesPage.ClickSaveDraftAndContinue();
                _content.DisplayContent();
                _content.TextEntry("Related skill arrangement check for '" + jobProfile + "' job profile.");
                _jobProfilesPage.PublishAndContinue();
            }
        }
    }
}