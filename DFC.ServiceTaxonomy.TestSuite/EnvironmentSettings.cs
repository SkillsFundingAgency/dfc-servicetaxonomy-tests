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

        public string jobProfileApiBaseUrl => Configuration["JobProfileApi:BaseUrl"];
        public string jobProfileSubscriptionKey => Configuration["JobProfileApi:SubscriptionKey"];

        public string contentApiBaseUrl => Configuration["ContentApi:BaseUrl"].EndsWith("/api/execute") ?
                                                Configuration["ContentApi:BaseUrl"] :
                                                $"{Configuration["ContentApi:BaseUrl"]}/api/execute";

        public string contentApiDraftBaseUrl => Configuration["ContentApi:BaseUrlDraft"].EndsWith("/api/execute")?
                                                Configuration["ContentApi:BaseUrlDraft"] :
                                                $"{Configuration["ContentApi:BaseUrlDraft"]}/api/execute";   
        public string contentApiSubscriptionKey => Configuration["ContentApi:SubscriptionKey"];

        public string escoApiBaseUrl => Configuration["EscoApi:BaseUrl"];

        public string editorBaseUrl => Configuration["Editor:BaseUrl"];
        public string editorUid => Configuration["Editor:Uid"];
        public string editorPassword => Configuration["Editor:Password"];

        public string neo4JUrl => Configuration["Neo4j:Url"];
        public string neo4JUrlDraft => Configuration["Neo4j:UrlDraft"];
        public string neo4JUid => Configuration["Neo4j:Uid"];
        public string neo4JPassword => Configuration["Neo4j:Password"];

        public bool sqlServerChecksEnabled = Configuration["SqlServer:ChecksEnabled"].ToLower() == "true";
        public string sqlServerConnectionString = Configuration["SqlServer:ConnectionString"];

        public bool checkEvents = Configuration["EventStore:CheckEvents"].ToLower() == "true";
        public string eventStoreEndPoint = Configuration["EventStore:BaseUrl"];
        public string eventStoreKey = Configuration["EventStore:Key"];
    }
}
