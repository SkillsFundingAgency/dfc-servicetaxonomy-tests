
using DFC.ServiceTaxonomy.TestSuite.PageObjects;

using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{
    [Binding]
    public sealed class Logon
    {
        private readonly LogonScreen _logonScreen;

        public Logon(ScenarioContext scenarioContext)
        {
            _logonScreen = new LogonScreen(scenarioContext);
        }

        [BeforeScenario("logon")]
        public void LoginUser()
        {
            _logonScreen.SubmitLogonDetails();
        }
    }
}
