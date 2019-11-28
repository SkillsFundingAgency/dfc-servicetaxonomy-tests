using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Neo4jClient;
using Neo4j.Driver.V1;
namespace DFC.ServiceTaxonomy.FunctionalTests
{
    public class Movie
    {
        public string title { get; set; }
        public int released { get; set; }
        public string tagline { get; set; }
    }

    public class Skill
    {
        public string title { get; set; }
        public string isEssential { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {


        public static IDriver Neo4jDriver { get; private set; }

        [TestMethod]
        public void TestMethod1()
        {

            var client = new GraphClient(new Uri("http://localhost:7474/db/data"),"neo4j","password");
            client.Connect();


        }

        [TestMethod]
        public void TestMethod2()
        {

            //var url = ConfigurationManager.AppSettings["GraphDBUrl"];
            //var username = ConfigurationManager.AppSettings["GraphDBUser"];
            //var password = ConfigurationManager.AppSettings["GraphDBPassword"];
            var authToken = AuthTokens.None;

            //if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(username))   
            //    authToken = AuthTokens.Basic(username, password);

            var q = "Matrix";
            var movies = new List<Movie>();

            Neo4jDriver = GraphDatabase.Driver(new Uri("bolt://localhost"), authToken);

            using (var session = Neo4jDriver.Session())
            {
                var result = session.Run("MATCH (movie:Movie) WHERE movie.title CONTAINS {title} RETURN movie", new { title = q });
              
                foreach (var record in result)
                {
                    var node = record["movie"].As<INode>();
                    movies.Add(new Movie
                    {
                        released = node["released"].As<int>(),
                        tagline = node["tagline"].As<string>(),
                        title = node["title"].As<string>()
                    });

                }
            }
            
            foreach ( var movie in movies)
            {
                Console.WriteLine("Movie: " + movie.title);
            }
          
        }

        [TestMethod]
        public void TestMethod3()
        {

            //var url = ConfigurationManager.AppSettings["GraphDBUrl"];
            //var username = ConfigurationManager.AppSettings["GraphDBUser"];
            //var password = ConfigurationManager.AppSettings["GraphDBPassword"];
            var authToken = AuthTokens.None;
            String query;
            //if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(username))   
            //    authToken = AuthTokens.Basic(username, password);

            query = "MATCH (s:esco__Skill)" +
                    "-[r: esco__isEssentialSkillFor | esco__isOptionalSkillFor]->" +
                    "(o: esco__Occupation { uri: 'http://data.europa.eu/esco/occupation/114e1eff-215e-47df-8e10-45a5b72f8197'})" +
                    "RETURN s.skos__prefLabel as skillDescription, " +
                    "case (type(r)) WHEN 'esco__isEssentialSkillFor' THEN 'true' " +
                    "WHEN 'esco__isOptionalSkillFor' THEN 'false'" +
                    "ELSE ''" +
                    "END AS IsEssential";

            var q = "Matrix";
            var skills = new List<Skill>();

            Neo4jDriver = GraphDatabase.Driver(new Uri("bolt://localhost"), authToken);

            using (var session = Neo4jDriver.Session())
            {
                var result = session.Run(query);

                foreach (var record in result)
                {
                    // var node = record["movie"].As<INode>();
                    skills.Add(new Skill
                    {
                        title = record.Values["skillDescription"].ToString() ,//node["SkillDescription"].As<String>(),
                        isEssential = record.Values["IsEssential"].ToString()
                    });

                }
            }

            foreach (var skill in skills)
            {
                Console.WriteLine("Skill: " + skill.title + " - IsEssential" + skill.isEssential.ToString());
            }

        }
    }
    
}
