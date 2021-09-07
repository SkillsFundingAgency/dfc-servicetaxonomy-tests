using DFC.ServiceTaxonomy.TestSuite.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.PageObjects
{
    public class ValidatedAndRepairResults
    {
        int RecordsCheck { get; set; }
        int RecordsInvalid { get; set; }
        int RecordsRepaired { get; set; }
    }

    public class ValidatedAndRepair
    {
        private ScenarioContext _scenarioContext;
        private EnvironmentSettings _env;
        private IWebDriver _driver;

        public ValidatedAndRepair(ScenarioContext context)
        {
            _scenarioContext = context;
            _env = context.GetEnv();
            _driver = context.GetWebDriver();
        }

        public ValidatedAndRepair RunValidateAndRepair()
        {
            _driver.Navigate().GoToUrl(_env.EditorBaseUrl + "/Admin/DFC.ServiceTaxonomy.GraphSync/GraphSync/TriggerSyncValidation");
            return this;
        }

        public bool CheckIfAlreadyRunning()
        {
            var elements = _driver.FindElements(By.XPath("//*[text()='a validation and repair is already in progress']"));
            return (elements.Count == 1);
            
        }
        public bool CheckForSuccess()
        {
            var elements = _driver.FindElements(By.XPath("/html/body/div[1]/div[3]/div[1]"));
            return (elements.Count == 1);
        }

        private IWebElement FindReportSection(string graph,string sectionReference)
        {
            string graphRef = "";
            switch (graph)
            {
                case "publish":
                    graphRef = "published";
                    break;
                default:
                    graphRef = graph;
                    break;
            }
            string id = "";
            switch (sectionReference)
            {
                case "Validated":
                    id = $"validated-{graphRef}_instance_0-neo4j";
                    break;
                case "Failed Validation":
                    id = $"failed-validation-{graphRef}_instance_0-neo4j";
                    break;
                case "Repaired":
                    id = $"repaired-{graphRef}_instance_0-neo4j";
                    break;
                default:
                    break;
            }
            var elements = _driver.FindElements(By.Id(id));
            if ( elements.Count > 0 )
            {
                return elements[0];
            }
            else
            {
                return null;
            }
        }

        public bool FindRecordInSection(string graph, string sectionReference, string recordId)
        {
            var reportSection = FindReportSection(graph, sectionReference);
            var reportItems = reportSection.FindElements(By.XPath($"//*[text()[contains(.,'{recordId}')]]"));
            return reportItems.Count > 1;
        }
    }
}
