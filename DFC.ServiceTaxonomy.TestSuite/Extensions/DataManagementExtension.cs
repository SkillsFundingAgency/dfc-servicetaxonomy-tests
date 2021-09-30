using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using DFC.ServiceTaxonomy.SharedResources.Helpers;

using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class DataManagementExtension
    {
        private static Random random = new Random();
        public const string sql_ClearDownAllContentItemsOfType =
    @"DECLARE @TableName varchar(255) = '';
    DECLARE @Query varchar(255) = '';
    DECLARE @Deleted INT = 0;
    DECLARE @NewDeleted INT = 0;
    DECLARE @Tables INT = 0;

    DECLARE CUR_INDEXTABS CURSOR FAST_FORWARD FOR
        SELECT Name 
	    FROM
	    SYSOBJECTS
	    WHERE
	    xtype = 'U'
	    and Name like '%Index'
        and Name not in
	    ('WorkflowTypeStartActivitiesIndex','WorkflowIndex','WorkflowBlockingActivitiesIndex','DeploymentPlanIndex','LayerMetadataIndex','UserIndex','UserByRoleNameIndex',
	     'UserByLoginInfoIndex','UserByClaimIndex','WorkflowTypeIndex');

    OPEN CUR_INDEXTABS
    FETCH NEXT FROM CUR_INDEXTABS INTO @TableName

    begin transaction t1

    select DocumentId
    into #tmpdocids
    from [dbo].[ContentItemIndex]
    where @WHERECLAUSE@;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @Query = 'delete from [dbo].' + @TableName + ' where DocumentId in ( select DocumentId from #tmpdocids ) ';
        EXECUTE(@Query); 
		SET @NewDeleted = @@ROWCOUNT
        IF @NewDeleted > 0
        BEGIN
	      SET @TABLES = @TABLES + 1;
	      SET @Deleted = @Deleted + @NewDeleted;
        END
        FETCH NEXT FROM CUR_INDEXTABS INTO @TableName
    END

    delete from [dbo].Document where id in ( select DocumentId from #tmpdocids );
	SET @NewDeleted = @@ROWCOUNT
    IF @NewDeleted > 0
    BEGIN
	 SET @TABLES = @TABLES + 1;
	 SET @Deleted = @Deleted + @NewDeleted;
    END
    drop table #tmpdocids
    commit transaction t1;

    CLOSE CUR_INDEXTABS
    DEALLOCATE CUR_INDEXTABS
    select Concat(@Deleted,' records deleted from ', @Tables,' tables');";

        public static (bool, string) DeleteSQLRecordsWithPrefix(this ScenarioContext context, string prefix)
        {
            string message;
            bool result;
            if (!context.GetEnv().SqlServerChecksEnabled)
                return (true, string.Empty);
            //todo error handling
            string sqlCommand = sql_ClearDownAllContentItemsOfType.Replace("@WHERECLAUSE@", "left(DisplayText," + prefix.Length + ") = '" + prefix + "'");
            (result, message) = GetSQLConnection(context).ExecuteScalar(sqlCommand, null);
            CloseSQLConnection(context);
            // delete transaction has 3 parts hence affected record cout is 3 time larger than delete count
            return (result, message);
        }

        public static SQLServerHelper GetSQLConnection(this ScenarioContext context)
        {
            //if (!context.GetEnv().sqlServerChecksEnabled)
            //    return null;

            SQLServerHelper connection;
            string contextRef = $"sqlConnection";
            if (context.ContainsKey(contextRef))
            {
                connection = (SQLServerHelper)context[contextRef];
            }
            else
            {
                connection = new SQLServerHelper();
                connection.SetConnection(context.GetEnv().SqlServerConnectionString);
                context[contextRef] = connection;
            }
            return connection;
        }

        public static bool CloseSQLConnection(this ScenarioContext context)
        {
            SQLServerHelper connection;
            string contextRef = $"sqlConnection";
            if (context.ContainsKey(contextRef))
            {
                connection = (SQLServerHelper)context[contextRef];
                connection.CloseConnection();
                context.Remove(contextRef);
                return true;
            }
            return false;
        }

        //public static List<Neo4jConnection> GetGraphDetails(this ScenarioContext context, string graph)
        //{
        //    List<Neo4jConnection> graphDetails = new List<Neo4jConnection>();
        //    switch (graph)
        //    {
        //        case constants.publish:
        //            graphDetails.Add(new Neo4jConnection()
        //            {
        //                graphName = context.GetEnv().neo4JGraphName,
        //                uri = context.GetEnv().neo4JUrl,
        //                userName = context.GetEnv().neo4JUid,
        //                password = context.GetEnv().neo4JPassword
        //            });

        //            if (context.GetEnv().neo4JUrl1.Length > 0)
        //                graphDetails.Add(new Neo4jConnection()
        //                {
        //                    graphName = context.GetEnv().neo4JGraphName1,
        //                    uri = context.GetEnv().neo4JUrl1,
        //                    userName = context.GetEnv().neo4JUid,
        //                    password = context.GetEnv().neo4JPassword
        //                });
        //            break;
        //        case constants.preview:
        //            graphDetails.Add(new Neo4jConnection()
        //            {
        //                graphName = context.GetEnv().neo4JGraphNameDraft,
        //                uri = context.GetEnv().neo4JUrlDraft,
        //                userName = context.GetEnv().neo4JUidDraft,
        //                password = context.GetEnv().neo4JPasswordDraft
        //            });

        //            if (context.GetEnv().neo4JUrlDraft1.Length > 0)
        //                graphDetails.Add(new Neo4jConnection()
        //                {
        //                    graphName = context.GetEnv().neo4JGraphNameDraft1,
        //                    uri = context.GetEnv().neo4JUrlDraft1,
        //                    userName = context.GetEnv().neo4JUidDraft,
        //                    password = context.GetEnv().neo4JPasswordDraft
        //                });
        //            break;
        //    }
        //    return graphDetails;
        //}

        //public static List<Neo4JHelper> GetGraphConnections(this ScenarioContext context, string graph)
        //{
        //    List<Neo4JHelper> connections;
        //    string contextRef = $"graphCol_{graph}";

        //    if (context.ContainsKey(contextRef))
        //    {
        //        connections = (List<Neo4JHelper>)context[contextRef];
        //    }
        //    else
        //    {
        //        connections = new List<Neo4JHelper>();
        //        foreach (var conn in context.GetGraphDetails(graph))
        //        {
        //            connections.Add(new Neo4JHelper(conn));
        //        }
        //        context[contextRef] = connections;
        //    }
        //    // verify connections
        //    foreach( var conn in connections)
        //    {
        //        while (!conn.Verify())
        //        {
        //            conn.connect();
        //        }
        //    }
        //    return connections;
        //}

        public static Neo4JHelper GetGraphConnection(this ScenarioContext context, string graph, int instance = 0)
        {
            Neo4JHelper connection;
            string graphUri;
            string userId;
            string password;
            string graphName;
            switch (graph)
            {
                case Constants.publish:
                    graphUri = instance == 0 ? context.GetEnv().Neo4JUrl : context.GetEnv().Neo4JUrl1;
                    graphName = instance == 0 ? context.GetEnv().Neo4JGraphName : context.GetEnv().Neo4JGraphName1;
                    userId = context.GetEnv().Neo4JUid;
                    password = context.GetEnv().Neo4JPassword;
                    break;
                case Constants.preview:
                    graphUri = instance == 0 ? context.GetEnv().Neo4JUrlDraft : context.GetEnv().Neo4JUrlDraft1;
                    graphName = instance == 0 ? context.GetEnv().Neo4JGraphNameDraft : context.GetEnv().Neo4JGraphNameDraft1;
                    userId = context.GetEnv().Neo4JUidDraft;
                    password = context.GetEnv().Neo4JPasswordDraft;
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
                connection = new Neo4JHelper(graphName);
                connection.Connect(graphUri,
                                    userId,
                                    password);
                context[contextRef] = connection;
            }

            connection.Verify();
            //int connectionAttempts;
            //connectionAttempts = context.ContainsKey($"Attempts{contextRef}") ? (int)context[$"Attempts{contextRef}"] : 0;
            //if (!connection.Verify(connectionAttempts > maxAttempts))
            //{
            //    context.Remove(contextRef);
            //    context[$"Attempts{contextRef}"] = ++connectionAttempts;
            //    connection = GetGraphConnection(context, graph, instance);
            //}
            return connection;
        }

        public static bool DeleteGraphNodesWithPrefix(this ScenarioContext context, string fieldName, string prefix)
        {
            //todo error handling
            string cypher = Constants.cypher_ClearDownItemsWithPrefix.Replace("@PREFIX@", prefix)
                                                                     .Replace("@FIELDNAME@", fieldName);
            GetGraphConnection(context, Constants.publish).ExecuteTableQuery(cypher, null);
            GetGraphConnection(context, Constants.preview).ExecuteTableQuery(cypher, null);
            if (context.GetEnv().Neo4JUrl1.Length > 0)
                GetGraphConnection(context, Constants.publish, 1).ExecuteTableQuery(cypher, null);
            if (context.GetEnv().Neo4JUrlDraft1.Length > 0)
                GetGraphConnection(context, Constants.preview, 1).ExecuteTableQuery(cypher, null);
            return true;
        }

        public static bool DeleteGraphNodesWithUri(this ScenarioContext context, string uri)
        {
            //todo error handling
            string cypher = Constants.cypher_ClearDownItemsWithUri.Replace("@URI@", uri);
            GetGraphConnection(context, Constants.publish).ExecuteTableQuery(cypher, null);
            GetGraphConnection(context, Constants.preview).ExecuteTableQuery(cypher, null);
            if (context.GetEnv().Neo4JUrl1.Length > 0)
                GetGraphConnection(context, Constants.publish, 1).ExecuteTableQuery(cypher, null);
            if (context.GetEnv().Neo4JUrlDraft1.Length > 0)
                GetGraphConnection(context, Constants.preview, 1).ExecuteTableQuery(cypher, null);

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
            context[Constants.tokens] = tokens;
        }

        public static Dictionary<string, string> GetTokens(this ScenarioContext context)
        {
            Dictionary<string, string> tokens = context.ContainsKey(Constants.tokens) ? (Dictionary<string, string>)context[Constants.tokens] : new Dictionary<string, string>();
            return tokens;
        }

        public static string ReplaceTokensInString(this ScenarioContext context, string text)
        {
            var tokens = GetTokens(context);
            string newText = text;
            foreach (var token in tokens)
            {
                newText = newText.Replace(token.Key, token.Value);
            }
            return newText;
        }
    }
}
