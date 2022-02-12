using DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs.CommonFieldsSteps
{
    [Binding]
    public sealed class UniqueTitlePartSteps
    {
        private readonly UniqueTitle _uniqueTitlePart;

        public UniqueTitlePartSteps(UniqueTitle uniqueTitlePart)
        {
            _uniqueTitlePart = uniqueTitlePart;
        }

        [Then(@"I see (.*) as unique Title")]
        public void ThenISeeAsUniqueTitle(string searchTerm)
        {
            _uniqueTitlePart.GetTitle()
                .Should().Be(searchTerm);
        }
    }
}
