using DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs.CommonFieldsSteps
{
    [Binding]
    public class TextFieldSteps
    {
        private readonly TextField _textField;

        public TextFieldSteps(TextField textField)
        {
            _textField = textField;
        }

        [Then(@"I see (.*) in (.*) text field")]
        public void ThenISeeInTextField(string description, string type)
        {
            _textField.GetValue(type)
                .Should().Be(description);
        }
    }
}
