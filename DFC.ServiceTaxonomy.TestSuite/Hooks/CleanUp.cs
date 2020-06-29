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

        [AfterScenario( Order = 1)]
        public void TearDownDataItems()
        {
            // clear down based on stored uri
            foreach (var item in _scenarioContext.GetDataItems().Where(x => x.TearDownGraph))
            {
                //clear graph based on URI
                bool result = _scenarioContext.DeleteGraphNodesWithUri(item.Uri);
                Console.WriteLine($"CLEANUP: Succesfully deleted GRAPH items with uri {item.Uri}");

            }
            foreach (var item in _scenarioContext.GetDataItems().Where(x => x.TearDownSql))
            {
                //clear SQL based on URI
                Console.WriteLine("CLEANUP: Sql clear down based on URI not yet implemented");

            }
        }

        [AfterScenario("webtest", Order = 20)]
        public void CLoseWebDriver()
        {
            _scenarioContext.GetWebDriver().Close();
        }
    }
}
