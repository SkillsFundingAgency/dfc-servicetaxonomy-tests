using DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs.CommonFieldsSteps
{
    [Binding]
    public class InfoHtmlSteps
    {
        private readonly InfoHtml _info;

        public InfoHtmlSteps(InfoHtml info)
        {
            _info = info;
        }

        [Then(@"I see (.*) in (.*) info field")]
        public void ThenISeeInInfoField(string description, string type)
        {
            _info.GetValue(type)
                .Should().Be(description);
        }

    }
}
