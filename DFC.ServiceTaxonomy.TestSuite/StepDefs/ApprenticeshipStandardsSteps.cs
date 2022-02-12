using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    [Scope(Feature = "ApprenticeshipStandards")]
    public sealed class ApprenticeshipStandardsSteps
    {
        private readonly ApprenticeshipStandardsPage _page;

        public ApprenticeshipStandardsSteps(ScenarioContext scenarioContext)
        {
            _page = new ApprenticeshipStandardsPage(scenarioContext);
        }

        [Then(@"I see (.*) in description field")]
        public void ThenISeeInDescriptionField(string description)
        {
            _page.GetDescription()
                .Should().Be(description);
        }

        [Then(@"I see (.*) in LARS code field")]
        public void ThenISeeInLARSCodeField(string larsCode)
        {
            _page.GetLarsCode()
                .Should().Be(larsCode);
        }
    }
}
