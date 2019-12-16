using DFC.ServiceTaxonomy.TestSuite.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    [Binding]
    public sealed class CleanUp
    {
        private ScenarioContext _scenarioContext;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public CleanUp(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        [AfterScenario("webtest")]
        public void CLoseWebDriver()
        {
            _scenarioContext.GetWebDriver().Close();
        }
    }
}
