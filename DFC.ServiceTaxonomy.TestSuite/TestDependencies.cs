using DFC.ServiceTaxonomy.Events.Services.Interfaces;
using DFC.ServiceTaxonomy.Events.Services;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using DFC.ServiceTaxonomy.TestSuite.Extensions;

namespace DFC.ServiceTaxonomy.TestSuite
{
    public class TestDependencies
    {
 //       private static IConfiguration _configuration;
 //       private ScenarioContext _scenarioContext;

        //public TestDependencies(ScenarioContext context)
        //{
        //    _scenarioContext = context;
        //    _configuration = context.GetEnv().GetConfiguration();
        //}

        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            EnvironmentSettings env = new EnvironmentSettings();

            // Add test dependencies
            services.AddEventGridPublishing(env.GetConfiguration());//.AddTransient<IAddEventGridPublishing, EventGridContentClient>();

            // ContextInjectionScope (by using AddScoped instead of AddTransient, the context will be scoped to the Feature across bindings)
            //services.AddScoped<EventGridContentClient>();

            return services;
        }
    }
}
