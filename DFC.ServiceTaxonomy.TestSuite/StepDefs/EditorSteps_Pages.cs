﻿using System;
using System.Threading;

using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.PageObjects;

using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class EditorSteps_Pages
    {
        private readonly AddEditPage _addEditPage;
        private readonly ScenarioContext _scenarioContext;

        public EditorSteps_Pages(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _addEditPage = new AddEditPage(_scenarioContext);
        }

        [Given(@"I select the default page location")]
        public void GivenISelectTheDefaultPageLocation()
        {
            _addEditPage.SetBasePageLocation();
        }

        [Given(@"I add an html item to the page with content")]
        public void GivenIAddAnHtmlItemToThePageWithContent(string htmlValue)
        {
            _addEditPage.AddHtmlItem(htmlValue);
        }

        [Given(@"I add the ""(.*)"" shared content item to the page")]
        public void GivenIAddTheSharedContentItemToThePage(string contentItem)
        {
            _addEditPage.AddSharedContentItem(contentItem);
        }

        [Given(@"I add the ""(.*)"" shared content item to the existing widget")]
        public void GivenIAddTheSharedContentItemToTheExistingWidget(string contentItem)
        {
            _addEditPage.AddSharedContentItemToExistingWidget(contentItem);
        }

        [Given(@"I enter a publish later date (.*) minutes in the future")]
        public void GivenIEnterAPublishLaterDateMinutesInTheFuture(int p0)
        {
            DateTime publishTime = DateTime.Now + TimeSpan.FromMinutes(p0);
            _scenarioContext["futureEvent"] = publishTime;
            _scenarioContext["futureEventLatest"] = publishTime + TimeSpan.FromMinutes(2);
            _addEditPage.SetPublishLaterDate(publishTime);
        }

        [Given(@"I click the Publish Later button")]
        public void GivenIClickThePublishLaterButton()
        {
            _addEditPage.PublishLater();
        }

        [Given(@"I click the Unpublish Later button")]
        public void GivenIClickTheUnPublishLaterButton()
        {
            _addEditPage.ArchiveLater();
        }

        [Given(@"I wait unti (.*) minutes has passed")]
        public void GivenIWaitUntiMinutesHasPassed(int p0)
        {
            Thread.Sleep(p0 * 60000);
        }

        [Given(@"I select the page location ""(.*)""")]
        public void GivenISelectThePageLocation(string location)
        {
            _addEditPage.SetPageLocation(location.Slugify());
        }
    }
}
