using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class JobProfilesRemoveTests
    {
        string _titleMidFix;
        private readonly ManageContent _manageContent;
        private readonly SideNavigator _sideNavigator;
        private readonly ScenarioContext _scenarioContext;

        public JobProfilesRemoveTests(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _manageContent = new ManageContent(scenarioContext);
            _sideNavigator = new SideNavigator(scenarioContext);
        }

        [Given(@"I had created tests infix ""(.*)"" in the Title")]
        public void GivenIHadCreatedTestsInfixInTheTitle(string titleMidFix)
        {
            _titleMidFix = titleMidFix;
        }

        [When(@"I run this scenario")]
        public void WhenIRunThisScenario()
        {
            _sideNavigator.ClickContent();
            _sideNavigator.ClickContentItem();
            //_manageContent.CleanUpManageContent(_titleMidFix);
        }

        [Then(@"all tests with such infix are removed")]
        public void ThenAllTestsWithSuchInfixAreRemoved()
        {
            Assert.True(_manageContent.ManageContentCount().Count == 0, "There are still test(s) with '_Auto_' infix remaining.");
        }


    }
}
