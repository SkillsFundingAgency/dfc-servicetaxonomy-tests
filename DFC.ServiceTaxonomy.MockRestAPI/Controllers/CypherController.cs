using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using Neo4j.Driver.V1;

namespace DFC.ServiceTaxonomy.MockRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class cypherController : ControllerBase
    {
        private readonly ILogger<cypherController> _logger;

        public cypherController(ILogger<cypherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //[Route("cypher/{id}")]
        public IEnumerable<ResponseRow> Get()
        {
            string id = "114e1eff-215e-47df-8e10-45a5b72f8197";
            Neo4JHelper neo = new Neo4JHelper();
            IStatementResult result;
            var skills = new List<ResponseRow>();
            string query = "MATCH (s:esco__Skill)" +
                        "-[r: esco__isEssentialSkillFor | esco__isOptionalSkillFor]->" +
                        "(o: esco__Occupation { uri: 'http://data.europa.eu/esco/occupation/" + id + "'})" + //'http://data.europa.eu/esco/occupation/114e1eff-215e-47df-8e10-45a5b72f8197'})" +
                        "RETURN s.skos__prefLabel as skillDescription, " +
                        "case (type(r)) WHEN 'esco__isEssentialSkillFor' THEN 'true' " +
                        "WHEN 'esco__isOptionalSkillFor' THEN 'false'" +
                        "ELSE ''" +
                        "END AS IsEssential";

            result = neo.executeTableQuery(query);
            var a = result.Summary.ResultAvailableAfter;
            foreach (var record in result)
            {
                // var node = record["movie"].As<INode>();
                skills.Add(new ResponseRow
                {
                    skillDescription = record.Values["skillDescription"].ToString(),//node["SkillDescription"].As<String>(),
                    isEssential = record.Values["IsEssential"].ToString()
                });

            }

            return skills.ToArray();
        }

        [HttpGet("{id}")]
        //[Route("cypher/{id}")]
       public IEnumerable<ResponseRow> Get( string id)
       // public IEnumerable<ResponseRow> Get()
        {
            //string id = "114e1eff-215e-47df-8e10-45a5b72f8197";
            Neo4JHelper neo = new Neo4JHelper();
            IStatementResult result;
            var skills = new List<ResponseRow>();
            string query = "MATCH (s:esco__Skill)" +
                        "-[r: esco__isEssentialSkillFor | esco__isOptionalSkillFor]->" +
                        "(o: esco__Occupation { uri: 'http://data.europa.eu/esco/occupation/" + id + "'})" + //'http://data.europa.eu/esco/occupation/114e1eff-215e-47df-8e10-45a5b72f8197'})" +
                        "RETURN s.skos__prefLabel as skillDescription, " +
                        "case (type(r)) WHEN 'esco__isEssentialSkillFor' THEN 'true' " +
                        "WHEN 'esco__isOptionalSkillFor' THEN 'false'" +
                        "ELSE ''" +
                        "END AS IsEssential";
            
            result = neo.executeTableQuery(query);

            foreach (var record in result)
            {
                // var node = record["movie"].As<INode>();
                skills.Add(new ResponseRow
                {
                    skillDescription = record.Values["skillDescription"].ToString(),//node["SkillDescription"].As<String>(),
                    isEssential = record.Values["IsEssential"].ToString()
                });

            }

            return skills.ToArray();
        }
    }
}
