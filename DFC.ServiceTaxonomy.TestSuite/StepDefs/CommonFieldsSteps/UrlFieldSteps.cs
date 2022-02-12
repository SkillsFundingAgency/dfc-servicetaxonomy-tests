using DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs.CommonFieldsSteps
{
    [Binding]
    public class UrlFieldSteps
    {
        private readonly UrlField _urlField;

        public UrlFieldSteps(UrlField urlField)
        {
            _urlField = urlField;
        }

        [Then(@"I see (.*) in (.*) url field")]
        public void ThenISeeInInfoField(string description, string type)
        {
            _urlField.GetValue(type)
                .Should().Be(description);
        }
    }
}
