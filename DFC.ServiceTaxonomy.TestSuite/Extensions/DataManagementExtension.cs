using DFC.ServiceTaxonomy.TestSuite;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AngleSharp.Dom;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class DataManagementExtension
    {
        private static Random random = new Random();
       

        public static int DeleteSQLRecordsWithPrefix(this ScenarioContext context, string prefix)
        {
            //todo error handling
            string sqlCommand = constants.sql_ClearDownAllContentItemsOfType.Replace("@WHERECLAUSE@", "left(DisplayText," + prefix.Length + ") = '" + prefix + "'"); 

            SQLServerHelper sqlInstance = new SQLServerHelper();
            sqlInstance.SetConnection(context.GetEnv().sqlServerConnectionString);
            int count = sqlInstance.ExecuteNonQuery(sqlCommand, null);
            
            // delete transaction has 3 parts hence affected record cout is 3 time larger than delete count
            return ( count>0 ? count /3 : 0);
        }


        public static Neo4JHelper GetGraphConnection (this ScenarioContext context, string graph, int instance = 0)
        {
            Neo4JHelper connection;
            string graphUri;
            switch ( graph)
            {
                case constants.publish:
                    graphUri = context.GetEnv().neo4JUrl;
                    break;
                case constants.preview:
                    graphUri = context.GetEnv().neo4JUrlDraft;
                    break;
                default:
                    return null;
            }
            string contextRef = $"graph_{graph}{instance}";
            if (context.ContainsKey(contextRef))
            {
                connection = (Neo4JHelper)context[contextRef];
            }
            else
            {
                connection = new Neo4JHelper();
                connection.connect(graphUri,
                                    context.GetEnv().neo4JUid,
                                    context.GetEnv().neo4JPassword);
                context[contextRef] = connection;
            }
            return connection;
        }

        public static bool DeleteGraphNodesWithPrefix(this ScenarioContext context, string fieldName, string prefix)
        {
            //todo error handling
            string cypher = constants.cypher_ClearDownItemsWithPrefix.Replace("@PREFIX@", prefix)
                                                                     .Replace("@FIELDNAME@",fieldName);
            GetGraphConnection(context, constants.publish).ExecuteTableQuery(cypher, null);
            GetGraphConnection(context, constants.preview).ExecuteTableQuery(cypher, null);
            return true;
        }

        public static bool DeleteGraphNodesWithUri(this ScenarioContext context, string uri)
        {
            //todo error handling
            string cypher = constants.cypher_ClearDownItemsWithUri.Replace("@URI@", uri);
            GetGraphConnection(context, constants.publish).ExecuteTableQuery(cypher, null);
            GetGraphConnection(context, constants.preview).ExecuteTableQuery(cypher, null);

            return true;
        }

        public static bool ReplaceTokensInDirectory(this ScenarioContext context, string directory, string token, string replacement)
        {
            bool found = false;
            string[] files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                try
                {
                    string contents = File.ReadAllText(file);
                    if (contents.Contains(token))
                    {
                        found = true;
                    }
                    contents = contents.Replace(token, replacement);
                    // Make files writable
                    File.SetAttributes(file, FileAttributes.Normal);

                    File.WriteAllText(file, contents);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return found;
        }


        public static string RandomString(this ScenarioContext context, int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void StoreToken(this ScenarioContext context, string token, string value)
        {
           var tokens = GetTokens(context);
           if (!tokens.ContainsKey(token))
           {
                tokens.Add(token, value);
           }
           else
           {
                tokens[token] = value;
           }
           context[constants.tokens] = tokens;
        }

        public static Dictionary<string, string> GetTokens(this ScenarioContext context)
        {
            Dictionary<string, string> tokens = context.ContainsKey(constants.tokens) ? (Dictionary<String, string>)context[constants.tokens] : new Dictionary<string, string>();
            return tokens;
        }

        public static string ReplaceTokensInString(this ScenarioContext context, string text)
        {
            var tokens = GetTokens(context);
            string newText = text;
            foreach ( var token in tokens)
            {
                newText = newText.Replace(token.Key, token.Value);
            }
            return newText;
        }

        public static Table ReplaceTokensInTable(this ScenarioContext context, Table  data)
        {
            var tokens = GetTokens(context);
      //      Table newTable;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var v = data.Rows[0].Values.ToList();
                v.ForEach(c => c = "123"); // context.ReplaceTokensInString(c));
                //for( int j= 0; j < data.Rows[i].Values.Count; j++)
                ////foreach ( var kv in data.Rows[i].Values )
                //{
                //    data.Rows[i].Values.ElementAt(j). = context.ReplaceTokensInString(data.Rows[i].Values[j]);
                //}
            }
           
            return data;
        }
    }
}
