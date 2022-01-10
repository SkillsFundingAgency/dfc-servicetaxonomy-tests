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


        public JobProfiles(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sideNavigator = new SideNavigator(scenarioContext);
            _jobProfileSpecialism = new JobProfileSpecialism(scenarioContext);
            _jobProfileCategory = new JobProfileCategory(scenarioContext);
        }

        [Given(@"I create the following number of Content Types")]
        public void GivenICreateTheFollowingNumberOfContentTypes(Table table)
        {
            var contents = table.CreateSet<ContentTypes>();

            foreach (ContentTypes contentType in contents)
            {
                switch (contentType.contentType)
                {
                    case "Job profile specialism":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            _sideNavigator.ClickSideNavNew();
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Job profile specialism')]"));
                            _sideNavigator.ClickJobProfileSpecialism();
                            _jobProfileSpecialism.EnterTitle("JPS");
                            _jobProfileSpecialism.EnterDescription("This is the test for content item with title ");
                            _jobProfileSpecialism.ClickSaveDraftAndContinue();
                        }
                        break;
                    case "Job profile category":
                        for (int i = 0; i < contentType.number; i++)
                        {
                            WebDriverExtension.WaitElementToBeClickable(_scenarioContext.GetWebDriver(), By.XPath("//span[contains(text(),'Job profile category')]"));
                            _sideNavigator.ClickJobProfileCategory();
                            _jobProfileSpecialism.EnterTitle("JPC");
                            _jobProfileCategory.EnterDescription("This is the test for content item with title ");
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
