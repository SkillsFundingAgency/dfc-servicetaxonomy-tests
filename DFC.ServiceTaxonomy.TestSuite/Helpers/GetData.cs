using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Helpers
{
    class GetData
    {
        private readonly ScenarioContext _scenarioContext;
        public GetData(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        public string GetContentType(string contentType)
        {
            return contentType;
        }

        public object GetJsonData(string dataFile)
        {
            var jsonText = File.ReadAllText(dataFile);
            var jsonData = JsonConvert.DeserializeObject<IList<RelatedSkills>>(jsonText);
            return jsonData;
        }
    }
}
