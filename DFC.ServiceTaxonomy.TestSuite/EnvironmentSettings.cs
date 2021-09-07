using System;

using Microsoft.Extensions.Configuration;

namespace DFC.ServiceTaxonomy.TestSuite
{
    public class EnvironmentSettings
    {
        private static readonly IConfiguration Configuration =
        new EnvironmentSettingsConfigurationBuilder(nameof(DFC.ServiceTaxonomy.TestSuite)).BuildConfiguration();

        public IConfiguration GetConfiguration() { return Configuration; }

        public string TaxonomyApiBaseUrl => Configuration["TaxonomyApi:BaseUrl"];
        public string TaxonomySubscriptionKey => Configuration["TaxonomyApi:SubscriptionKey"];

        public string JobProfileApiBaseUrl => Configuration["JobProfileApi:BaseUrl"];
        public string JobProfileSubscriptionKey => Configuration["JobProfileApi:SubscriptionKey"];

        public string ContentApiBaseUrl => Configuration["ContentApi:BaseUrl"].EndsWith("/api/execute") ?
                                                Configuration["ContentApi:BaseUrl"] :
                                                $"{Configuration["ContentApi:BaseUrl"]}/api/execute";

        public string ContentApiDraftBaseUrl => Configuration["ContentApi:BaseUrlDraft"].EndsWith("/api/execute") ?
                                                Configuration["ContentApi:BaseUrlDraft"] :
                                                $"{Configuration["ContentApi:BaseUrlDraft"]}/api/execute";
        public string ContentApiSubscriptionKey => Configuration["ContentApi:SubscriptionKey"];

        public string EscoApiBaseUrl => Configuration["EscoApi:BaseUrl"];

        public string EditorBaseUrl => Configuration["Editor:BaseUrl"];
        public string EditorUid => Configuration["Editor:Uid"];
        public string EditorPassword => Configuration["Editor:Password"];

        public string Neo4JGraphName => Configuration["Neo4j:GraphName"];
        public string Neo4JGraphName1 => Configuration["Neo4j:GraphName1"];
        public string Neo4JGraphNameDraft => Configuration["Neo4j:GraphNameDraft"];
        public string Neo4JGraphNameDraft1 => Configuration["Neo4j:GraphNameDraft1"];

        public string Neo4JUrl => Configuration["Neo4j:Url"];
        public string Neo4JUrlDraft => Configuration["Neo4j:UrlDraft"];
        public string Neo4JUrl1 => Configuration["Neo4j:Url1"];
        public string Neo4JUrlDraft1 => Configuration["Neo4j:UrlDraft1"];
        public string Neo4JUid => Configuration["Neo4j:Uid"];
        public string Neo4JPassword => Configuration["Neo4j:Password"];
        public string Neo4JUidDraft => Configuration["Neo4j:UidDraft"];
        public string Neo4JPasswordDraft => Configuration["Neo4j:PasswordDraft"];

        public bool SqlServerChecksEnabled => Configuration["SqlServer:ChecksEnabled"].ToLower() == "true";
        public string SqlServerConnectionString => Configuration["SqlServer:ConnectionString"];

        public bool CheckEvents => Configuration["EventStore:CheckEvents"].ToLower() == "true";
        public string EventStoreEndPoint => Configuration["EventStore:BaseUrl"];
        public string EventStoreKey => Configuration["EventStore:Key"];

        public bool SendEvents => Configuration["EventGrid:PublishEvents"].ToLower() == "true";
        public string EventTopicUrl => Configuration["EventGrid:TopicEndpoint"];
        public string AegSasKey => Configuration["EventGrid:AegSasKey"];

        public bool CaptureScreenshots => Configuration["Config:CaptureScreenshots"].ToLower() == "true";
        public string TargetEnv => Configuration["Config:Environment"];
        public bool PipelineRun => Environment.GetEnvironmentVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI") == "https://sfa-gov-uk.visualstudio.com/";
    }
}
