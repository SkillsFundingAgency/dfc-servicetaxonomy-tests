using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace DFC.ServiceTaxonomy.TestSuite.Hooks
{


    [Binding]
    public sealed class Configure
    {
        private static IConfiguration config;

        [BeforeScenario]
        public void GetConfig()
        {
            if (config == null)
            {
                config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.local.json", optional: false, reloadOnChange: true)
                    .Build();
            }
        }
        
    }
}

