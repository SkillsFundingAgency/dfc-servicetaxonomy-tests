using DFC.ServiceTaxonomy.TestSuite;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class DataManagementExtension
    {
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

        public static bool ReplaceTokensInDirectory(this ScenarioContext context, string directory, string token, string replacement)
        {
            string[] files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                try
                {
                    string contents = File.ReadAllText(file);
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
            return true;
        }

    }
}
