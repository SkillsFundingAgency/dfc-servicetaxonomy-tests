using DFC.ServiceTaxonomy.TestSuite;
using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
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

        [AfterScenario("webtest", Order = 10)]
        public void TearDownData()
        {
            if (_scenarioContext.ContainsKey("prefix"))
            {
                string prefix = _scenarioContext["prefix"].ToString();
                string prefixField = _scenarioContext["prefixField"].ToString();
                // attempt to clear down data from sql and neo where title / skos__PrefLabel begins with prefix

                //SQL
                int count = _scenarioContext.DeleteSQLRecordsWithPrefix(prefix);
                Console.WriteLine("CLEANUP: Deleted " + count + "content items prefixed with " + prefix);
                
                //graph
                bool result = _scenarioContext.DeleteGraphNodesWithPrefix(prefixField, prefix);
                Console.WriteLine("CLEANUP: Succesfully deleted GRAPH items prefixed with " + prefix);
            }
        }

        [AfterScenario("webtest", Order = 20)]
        public void CLoseWebDriver()
        {
            _scenarioContext.GetWebDriver().Close();
            _scenarioContext.GetWebDriver().Quit();
        }
    }
}
