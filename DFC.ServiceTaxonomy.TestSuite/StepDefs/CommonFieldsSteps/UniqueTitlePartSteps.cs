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

    [Binding]
    public sealed class PageLocationPartSteps
    {
        private readonly PageLocation _pageLocation;

        public PageLocationPartSteps(PageLocation pageLocation)
        {
            _pageLocation = pageLocation;
        }

        [Then(@"I see (.*) as full url")]
        public void ThenISeeAsFullUrl(string text)
        {
            _pageLocation.GetFullUrl()
                .Should().Be(text);
        }

        [Then(@"I see (.*) as url name")]
        public void ThenISeeAsUrlName(string text)
        {
            _pageLocation.GetUrlName()
                .Should().Be(text);
        }
    }
}
