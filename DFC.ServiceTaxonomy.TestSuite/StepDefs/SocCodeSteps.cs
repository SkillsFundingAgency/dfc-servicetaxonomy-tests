using DFC.ServiceTaxonomy.TestSuite.PageObjects;

using FluentAssertions;

using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public class SocCodeSteps
    {
        private readonly SocCode _socCode;

        public SocCodeSteps(ScenarioContext context)
        {
            _socCode = new SocCode(context);
        }

        [Then(@"I see (.*) in onet occupation code field")]
        public void ThenISeeInOnetOccupationCodeField(string onetCode)
        {
            _socCode.GetOnetCode()
                .Should().Be(onetCode);
        }

        [Then(@"I see (.*) items in the list")]
        public void ThenISeeItemsInTheList(string listItmes)
        {
            if (!string.IsNullOrWhiteSpace(listItmes))
            {
                var list = _socCode.GetApprenticeshipStandards();
                var items = listItmes.Split(",", System.StringSplitOptions.RemoveEmptyEntries);
                list.Should().Contain(items);
            }
        }
    }

    [Binding]
    public sealed class SocSkillsMatrixSteps
    {
        private readonly SocSkillsMatrix _socSkillsMatrix;

        public SocSkillsMatrixSteps(SocSkillsMatrix socSkillsMatrix)
        {
            _socSkillsMatrix = socSkillsMatrix;
        }

        [When(@"I enter (.*) in the the contextualised field")]
        public void WhenIEnterInTheTheContextualisedField(string text)
        {
            _socSkillsMatrix.EnterContextualisationText(text);
        }
    }
}
