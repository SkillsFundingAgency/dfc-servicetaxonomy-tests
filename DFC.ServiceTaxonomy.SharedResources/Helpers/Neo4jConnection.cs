using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public class Neo4jConnection
    {
        public string uri { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string graphName { get; set; } = "neo4j";
    }
}
