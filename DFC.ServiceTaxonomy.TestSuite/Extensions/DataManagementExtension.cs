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
        private static Dictionary<string, string> tokens = new Dictionary<string,string>();

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

        public static bool DeleteGraphNodesWithPrefix(this ScenarioContext context, string fieldName, string prefix)
        {
            //todo error handling
            string cypher = constants.cypher_ClearDownItemsWithPrefix.Replace("@PREFIX@", prefix)
                                                                     .Replace("@FIELDNAME@",fieldName);
            Neo4JHelper neo4JHelper = new Neo4JHelper();
            neo4JHelper.connect(context.GetEnv().neo4JUrl,
                                context.GetEnv().neo4JUid,
                                context.GetEnv().neo4JPassword);
            
            neo4JHelper.ExecuteTableQuery(cypher, null);
            
            return true;
        }

        public static bool DeleteGraphNodesWithUri(this ScenarioContext context, string uri)
        {
            //todo error handling
            string cypher = constants.cypher_ClearDownItemsWithUri.Replace("@URI@", uri);
            Neo4JHelper neo4JHelper = new Neo4JHelper();
            neo4JHelper.connect(context.GetEnv().neo4JUrl,
                                context.GetEnv().neo4JUid,
                                context.GetEnv().neo4JPassword);

            neo4JHelper.ExecuteTableQuery(cypher, null);

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
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void StoreToken(this ScenarioContext context, string token, string value)
        {
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
           return tokens;
        }

        public static string ReplaceTokensInString(this ScenarioContext context, string text)
        {
            string newText = text;
            foreach ( var token in tokens)
            {
                newText = newText.Replace(token.Key, token.Value);
            }
            return newText;
        }
    }
}
