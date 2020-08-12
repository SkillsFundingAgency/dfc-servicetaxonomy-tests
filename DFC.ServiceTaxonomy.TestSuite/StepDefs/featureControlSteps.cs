using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class featureControlSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _FeatureContext;

        public featureControlSteps(ScenarioContext context, FeatureContext fContext)
        {
            _scenarioContext = context;
            _FeatureContext = fContext;
        }

        [Given(@"I only want to run this once with this feature")]
        public void GivenIOnlyWantToRunThisOnceWithThisFeature()
        {
            if (_scenarioContext.ContainsKey("SingleBackgroundRun") && (bool)_scenarioContext["SingleBackgroundRun"])
            {
                _scenarioContext["RestrictSteps"] = true;
            }
            _FeatureContext["SingleBackgroundRun"] = true;
        }

        [Given(@"I have completed the run once section")]
        public void GivenIHaveCompletedTheRunOnceSection()
        {
            _scenarioContext["RestrictSteps"] = false;
        }
    }
}
