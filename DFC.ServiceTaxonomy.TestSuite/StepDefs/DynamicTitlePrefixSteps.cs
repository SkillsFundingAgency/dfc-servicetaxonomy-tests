using DFC.ServiceTaxonomy.TestSuite.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public class DynamicTitlePrefixSteps
    {
        private readonly DynamicTitlePrefixPage _page;

        public DynamicTitlePrefixSteps(ScenarioContext context)
        {
            _page = new DynamicTitlePrefixPage(context);
        }

        [Then(@"I see (.*) as Title")]
        public void ThenISeeAsTitle(string searchTerm)
        {
            _page.GetTitle().Should().Be(searchTerm);
        }
    }
}
