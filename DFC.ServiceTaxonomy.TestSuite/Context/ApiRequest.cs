using System;
using System.Collections.Generic;
using System.Text;
using DFC.ServiceTaxonomy.TestSuite.Models;

namespace DFC.ServiceTaxonomy.TestSuite.Context
{
    public class ApiRequest
    {
        public IList<Occupation> occupations;
        public IList<EscoDataItem> escoData = new List<EscoDataItem>();
        public EnvironmentSettings envSettings;
        public Dictionary<string, string> taxonomyApiHeaders = new Dictionary<string, string>();

        string UriGetAllOccupations = "GetAllOccupations/Execute/";

        public ApiRequest (EnvironmentSettings injectEnvSettings)
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
                default: return envSettings.taxonomyApiBaseUrl + UriGetAllOccupations;
            }
        }
    }
}
