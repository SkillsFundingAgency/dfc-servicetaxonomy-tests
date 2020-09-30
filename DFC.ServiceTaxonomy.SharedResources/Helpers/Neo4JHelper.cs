using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;



namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public class Neo4JHelper
    {
        private const string verificationCypher = "RETURN 1";
        private string graphName = "neo4j";
        public IDriver Neo4jDriver { get; private set; }
        public Neo4JHelper()
        {
        }

        public Neo4JHelper ( string _graphName)
        {
            if (_graphName.Length >0)
                graphName = _graphName;
        }

        public Neo4JHelper(string uri, string userName, string password)
        {
            connect(uri, userName, password);
        }

        public void connect( string uri, string userName, string password)
        {
            var authToken = ( userName.Equals(string.Empty) ? AuthTokens.None : AuthTokens.Basic(userName, password) ) ;
            Neo4jDriver = GraphDatabase.Driver(new Uri(uri), authToken);
        }

        public bool Verify()
        {
            try
            {
                ExecuteTableQuery(verificationCypher,null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Dictionary<string, object>> ExecuteTableQuery( string queryText, Dictionary<string,object> queryParameters)
        {
            List<Dictionary<string, object>> resultList = new List< Dictionary<string, object>>();
            //IResult result= null;
            try
            {
                using (var session = Neo4jDriver.Session(builder => builder.WithDatabase(graphName)) )
                {
                    var result = session.Run(queryText, queryParameters);
                    foreach (var record in result)
                    {
                        Dictionary<string, object> item = new Dictionary<string, object>();

                        foreach (var value in record.Values)
                        {
                            item.Add(value.Key, value.Value);
                        }
                        resultList.Add(item);
                    }
                }
                
            }
            catch (Exception e)
             {
                throw new Exception("Error occured executing Cypher query" +
                                 "\n Exception:" + e);
            }
            return resultList;
        }

        public int ExecuteCountQuery(string queryText, Dictionary<string, object> queryParameters)
        {
            int recordCount = -1;
            var result = ExecuteTableQuery(queryText, queryParameters);
            foreach (var record in result)
            {
                string a = (string)record.First().Value;
                int.TryParse(a, out recordCount);
            }
            return recordCount;
        }

        public int GetRecordCount(string queryText, Dictionary<string, object> queryParameters)
        {
            var result = ExecuteTableQuery(queryText, queryParameters);
            return result.First().Keys.Count;

        }

        public Dictionary<string,string> GetSingleRowAsDictionary(string queryText)
        {
            var result = ExecuteTableQuery(queryText, null);
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (var record in result)
            {
                foreach (var item in record)
                {
                    results.Add(item.Key, (item.Value == null ? "" : item.Value.ToString()) );
                }
                // only want first row so exit
                break;
            }
            return results;
        }


        public IList<T> GetResultsList<T>(string queryText, Dictionary<string, object> queryParameters) where T : new()
        {
            IList<T> resultsList = new List<T>();
            var result = ExecuteTableQuery(queryText, queryParameters);

            foreach (var record in result)
            {
                T newItem = new T();
                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    string value;
                    try
                    {
                        value = record[property.Name].ToString();
                        property.SetValue(newItem, value);
                    }
                    catch { }
                }
                resultsList.Add(newItem);
            }
            return resultsList;
        }

        public IList<Object> GetResultsList(Type type, string queryText, Dictionary<string, object> queryParameters) 
        {
            IList<Object> resultsList = new List<Object>();
            var result = ExecuteTableQuery(queryText, queryParameters);

            foreach (var record in result)
            {
                object newItem = Activator.CreateInstance(type);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    string value;
                    try
                    {
                        value = record[property.Name].ToString();
                        property.SetValue(newItem, value);
                    }
                    catch { }
                }
                resultsList.Add(newItem);
            }
            return resultsList;
        }


    }
}
