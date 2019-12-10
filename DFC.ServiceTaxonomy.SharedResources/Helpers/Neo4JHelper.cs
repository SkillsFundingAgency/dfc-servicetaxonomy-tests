using System;
using System.Collections.Generic;
using System.Text;
using Neo4j.Driver.V1;


namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public class Neo4JHelper
    {
        public static IDriver Neo4jDriver { get; private set; }

        public IStatementResult executeTableQuery( string queryText)
        {
            var authToken = AuthTokens.None;
            Neo4jDriver = GraphDatabase.Driver(new Uri("bolt://localhost"), authToken);
            IStatementResult result;
            using (var session = Neo4jDriver.Session())
            {
                result = session.Run(queryText);// "MATCH (movie:Movie) WHERE movie.title CONTAINS {title} RETURN movie", new { title = queryText });
            }
            return result;
        }
    }
}
