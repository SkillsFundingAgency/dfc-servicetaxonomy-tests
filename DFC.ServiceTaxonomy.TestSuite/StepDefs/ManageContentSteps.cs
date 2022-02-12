using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public class ManageContentSteps
    {
        private readonly ManageContent _manageContent;

        public ManageContentSteps(ScenarioContext context)
        {
            _manageContent = new ManageContent(context);
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

        [When(@"I click on the link with text (.*)")]
        public void WhenIClickOnTheLinkWithText(string text)
        {
            _manageContent.SelectFirstMatchedLink(text);
        }
    }
}
