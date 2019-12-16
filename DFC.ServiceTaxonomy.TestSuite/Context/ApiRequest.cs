using System;
using System.Collections.Generic;
using System.Text;
using DFC.ServiceTaxonomy.TestSuite.Models;
using RestSharp;

namespace DFC.ServiceTaxonomy.TestSuite.Context
{
    public class ApiRequestOld
    {
        public IList<Occupation> occupations = new List<Occupation>();
        public IList<Skill> skills = new List<Skill>();
        public IList<EscoDataItem> escoData = new List<EscoDataItem>();
        public IList<string> valueList = new List<string>();
        public EnvironmentSettings envSettings;
        public Dictionary<string, string> taxonomyApiHeaders = new Dictionary<string, string>();
        public IRestResponse apiResponse;
        string UriGetAllOccupations = "GetAllOccupations/Execute/";
        string UriGetAllSkills = "GetAllSkills/Execute/";

        public ApiRequestOld (EnvironmentSettings injectEnvSettings)
        {
            envSettings = injectEnvSettings;

            // prime headers for taxonomy API
            taxonomyApiHeaders.Add("Content-Type", "application/json");
            taxonomyApiHeaders.Add("Ocp-Apim-Subscription-Key", envSettings.taxonomySubscriptionKey);
        }

        public string GetTaxonomyUri ( string resource)
        {
            switch (resource)
            {
                case "GetAllSkills":
                    return envSettings.taxonomyApiBaseUrl + UriGetAllSkills;
                case "GetAllOccupations":
                    return envSettings.taxonomyApiBaseUrl + UriGetAllOccupations;
                default:
                    return "";
            }
        }

        public string GetSkillOrKnowlegeFromSkillTypeUri(string uri)
        {
            return ( uri.Contains("knowledge") ? "knowledge" : "competency" );
        }
    }
}
