using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.ServiceTaxonomy.TestSuite.Models
{
    class SharedContent// : GenericContent
    {  
        [CypherLabel("skos__prefLabel")]
        [JsonProperty("skos__prefLabel")]
        public string Title { get; set; }
  
        public string Content { get; set; }
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.FFFZ");
        public string ModifiedDate { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.FFFZ");
        public string uri { get; set; }
    }
}

