using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DFC.ServiceTaxonomy.TestSuite
{
    public class EnvironmentSettings
    {
        private static readonly IConfiguration Configuration =
        new EnvironmentSettingsConfigurationBuilder(nameof(DFC.ServiceTaxonomy.TestSuite)).BuildConfiguration();

        public string taxonomyApiBaseUrl => Configuration["TaxonomyApi:BaseUrl"];
        public string taxonomySubscriptionKey => Configuration["TaxonomyApi:SubscriptionKey"];

        public string escoApiBaseUrl => Configuration["EscoApi:BaseUrl"];

        public string editorBaseUrl => Configuration["EscoApi:BaseUrl"];
        public string editorUid => Configuration["Editor:UserName"];
        public string editorPassword => Configuration["Editor:Password"];

        public string neo4JUrl => Configuration["Neo4j:Url"];
        public string neo4JUid => Configuration["Neo4j:Uid"];
        public string neo4JPassword => Configuration["Neo4j:Password"];

    }
}
