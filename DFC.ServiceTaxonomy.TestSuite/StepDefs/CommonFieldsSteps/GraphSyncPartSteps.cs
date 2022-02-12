using DFC.ServiceTaxonomy.TestSuite.PageObjects.CommonFields;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs.CommonFieldsSteps
{
    [Binding]
    public sealed class GraphSyncPartSteps
    {
        private readonly GraphSyncUri _graphSyncPart;
        public GraphSyncPartSteps(GraphSyncUri graphSyncPart)
        {
            _graphSyncPart = graphSyncPart;
        }

        [Then(@"I see (.*) in Uri field")]
        public void ThenISeeInUriField(string id)
        {
            _graphSyncPart.GetId()
                .Should().Be(id);
        }
    }
}
