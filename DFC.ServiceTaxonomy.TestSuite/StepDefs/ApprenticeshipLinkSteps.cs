using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class ApprenticeshipLinkSteps
    {
        private readonly ApprenticeshipLink _page;

        public ApprenticeshipLinkSteps(ScenarioContext scenarioContext)
        {
            _page = new ApprenticeshipLink(scenarioContext);
        }

        [Then(@"I see (.*) in url field")]
        public void ThenISeeInUrlField(string text)
        {
            _page.GetUrl()
                .Should().Be(text);
        }

        [Then(@"I see (.*) in text field")]
        public void ThenISeeInTextField(string text)
        {
            _page.GetText()
                .Should().Be(text);
        }
    }
}
