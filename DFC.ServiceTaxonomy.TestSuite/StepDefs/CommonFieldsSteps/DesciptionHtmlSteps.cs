using DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs.CommonFieldsSteps
{
    [Binding]
    public class DesciptionHtmlSteps
    {
        private readonly DescriptionHtml _description;

        public DesciptionHtmlSteps(DescriptionHtml description)
        {
            _description = description;
        }

        [Then(@"I see (.*) in (.*) description html field")]
        public void ThenISeeInDescriptionHtmlField(string description, string type)
        {
            _description.GetValue(type)
                .Should().Be(description);
        }
    }
}
