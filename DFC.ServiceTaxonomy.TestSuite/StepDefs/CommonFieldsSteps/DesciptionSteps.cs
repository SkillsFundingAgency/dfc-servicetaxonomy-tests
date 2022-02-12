using DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs.CommonFieldsSteps
{
    [Binding]
    public class DesciptionSteps
    {
        private readonly Description _description;

        public DesciptionSteps(Description description)
        {
            _description = description;
        }

        [Then(@"I see (.*) in (.*) description field")]
        public void ThenISeeInDescriptionField(string description, string type)
        {
            _description.GetValue(type)
                .Should().Be(description);
        }

    }
}
