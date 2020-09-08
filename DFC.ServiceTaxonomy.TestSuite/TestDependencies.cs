using DFC.ServiceTaxonomy.Events.Services.Interfaces;
using DFC.ServiceTaxonomy.Events.Services;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.TestSuite
{
    public static class TestDependencies
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            // Add test dependencies
            services.AddTransient<IEventGridContentClient, EventGridContentClient>();

            // ContextInjectionScope (by using AddScoped instead of AddTransient, the context will be scoped to the Feature across bindings)
            services.AddScoped<EventGridContentClient>();

            return services;
        }
    }
}
