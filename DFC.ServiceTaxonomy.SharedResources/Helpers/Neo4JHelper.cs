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

        private Neo4jConnection connection;
        private string graphName = "neo4j";

        public IDriver Neo4jDriver { get; private set; }

        public Neo4JHelper(Neo4jConnection _connection)
        {
            connection = _connection;
            if (connection.graphName.Length > 0)
                graphName = connection.graphName;
            Connect(connection.uri, connection.userName, connection.password);
        }

        private void initalise()
        {
            connection = new Neo4jConnection();
        }
        public Neo4JHelper ( string _graphName)
        {
            initalise();
            if (_graphName.Length > 0)
                graphName = _graphName;
        }

        public Neo4JHelper(string uri, string userName, string password)
        {
            initalise();
            Connect(uri, userName, password);
        }

        public void Connect()
        {
            Connect(connection.uri, connection.uri, connection.password);
        }

        public void Connect(Neo4jConnection conn)
        {
            Connect(conn.uri, conn.uri, conn.password);
        }

        public void Connect( string uri, string userName, string password)
        {
            connection.uri = uri;
            connection.userName = userName;
            connection.password = password;
            var authToken = ( userName.Equals(string.Empty) ? AuthTokens.None : AuthTokens.Basic(userName, password) ) ;
            Neo4jDriver = GraphDatabase.Driver(new Uri(uri), authToken);
        }

        public bool Verify()
        {
            int tries = 0;
            while (tries++ <= 2)
            {
                try
                {
                    ExecuteTableQuery(verificationCypher, null);
                    return true;
                }
                catch (Neo4jException e)
                {
                    switch (tries)
                    {
                        case 1:
                            Neo4jDriver.Dispose();
                            Connect();
                            break;
                        case 2:
                            throw e;
                    }
                }
            }
            return false;
        }

        public List<Dictionary<string, object>> ExecuteTableQuery( string queryText, Dictionary<string,object> queryParameters)
        {
            List<Dictionary<string, object>> resultList = new List< Dictionary<string, object>>();
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
            catch (Neo4jException e)
            {
                throw e;
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
