using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;



namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public class Neo4JHelper
    {
        public IDriver Neo4jDriver { get; private set; }

        public Neo4JHelper()
        {
        }

        public Neo4JHelper ( string uri)
        {
            connect(uri, string.Empty, string.Empty);
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

        public IStatementResult ExecuteTableQuery( string queryText, Dictionary<string,object> queryParameters)
        {
            IStatementResult result= null;
            try
            {
                using (var session = Neo4jDriver.Session())
                {
                    result = session.Run(queryText, queryParameters);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error occured executing Cypher query" +
                                 "\n Exception:" + e);
            }
            return result;
        }

        public int ExecuteCountQuery(string queryText, Dictionary<string, object> queryParameters)
        {
            int recordCount = -1;
            IStatementResult result = ExecuteTableQuery(queryText, queryParameters);
            foreach (IRecord record in result)
            {
                string a = record.Values[record.Keys[0]].ToString(); ;  
                int.TryParse(a, out recordCount);
            }
            return recordCount;

        }

        public int GetRecordCount(string queryText, Dictionary<string, object> queryParameters)
        {
            IStatementResult result = ExecuteTableQuery(queryText, queryParameters);
            return result.Keys.Count;

        }

        public Dictionary<string,string> GetSingleRowAsDictionary(string queryText)
        {
            IStatementResult result = ExecuteTableQuery(queryText, null);
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (IRecord record in result)
            {
                foreach (var item in record.Values)
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
            IStatementResult result = ExecuteTableQuery(queryText, queryParameters);

            foreach (IRecord record in result)
            {
                T newItem = new T();
                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    string value;
                    try
                    {
                        value = record.Values[property.Name].ToString();
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
            IStatementResult result = ExecuteTableQuery(queryText, queryParameters);

            foreach (IRecord record in result)
            {
                object newItem = Activator.CreateInstance(type);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    string value;
                    try
                    {
                        value = record.Values[property.Name].ToString();
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
