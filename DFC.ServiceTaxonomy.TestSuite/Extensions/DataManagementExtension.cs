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
using System.Runtime.CompilerServices;

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

        public static (bool,string) DeleteSQLRecordsWithPrefix(this ScenarioContext context, string prefix)
        {
            string message;
            bool result;
            if (!context.GetEnv().sqlServerChecksEnabled)
                return (true,string.Empty);
            //todo error handling
            string sqlCommand = sql_ClearDownAllContentItemsOfType.Replace("@WHERECLAUSE@", "left(DisplayText," + prefix.Length + ") = '" + prefix + "'");
            (result,message) = GetSQLConnection(context).ExecuteScalar(sqlCommand, null);
            CloseSQLConnection(context);
            // delete transaction has 3 parts hence affected record cout is 3 time larger than delete count
            return (result,message);
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
                connection.SetConnection(context.GetEnv().sqlServerConnectionString);
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

        public static Neo4JHelper GetGraphConnection (this ScenarioContext context, string graph, int instance = 0)
        {
            Neo4JHelper connection;
            string graphUri;
            string userId;
            string password;
            string graphName;
            switch ( graph)
            {
                case constants.publish:
                    graphUri = instance == 0 ? context.GetEnv().neo4JUrl : context.GetEnv().neo4JUrl1;
                    graphName = instance == 0 ? context.GetEnv().neo4JGraphName : context.GetEnv().neo4JGraphName1;
                    userId = context.GetEnv().neo4JUid;
                    password = context.GetEnv().neo4JPassword;
                    break;
                case constants.preview:
                    graphUri = instance == 0 ? context.GetEnv().neo4JUrlDraft : context.GetEnv().neo4JUrlDraft1;
                    graphName = instance == 0 ? context.GetEnv().neo4JGraphNameDraft : context.GetEnv().neo4JGraphNameDraft1;
                    userId = context.GetEnv().neo4JUidDraft;
                    password = context.GetEnv().neo4JPasswordDraft;
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
                connection.connect(graphUri,
                                    userId,
                                    password);
                context[contextRef] = connection;
            }
            if (!connection.Verify())
            {
                context.Remove(contextRef);
                connection = GetGraphConnection(context, graph, instance);
            }
            return connection;
        }

        public static bool DeleteGraphNodesWithPrefix(this ScenarioContext context, string fieldName, string prefix)
        {
            //todo error handling
            string cypher = constants.cypher_ClearDownItemsWithPrefix.Replace("@PREFIX@", prefix)
                                                                     .Replace("@FIELDNAME@",fieldName);
            GetGraphConnection(context, constants.publish).ExecuteTableQuery(cypher, null);
            if (context.GetEnv().neo4JUrl1.Length > 0)
                GetGraphConnection(context, constants.publish, 1).ExecuteTableQuery(cypher, null);
            GetGraphConnection(context, constants.preview).ExecuteTableQuery(cypher, null);
            if (context.GetEnv().neo4JUrlDraft1.Length > 0)
                GetGraphConnection(context, constants.preview, 1).ExecuteTableQuery(cypher, null);
            return true;
        }

        public static bool DeleteGraphNodesWithUri(this ScenarioContext context, string uri)
        {
            //todo error handling
            string cypher = constants.cypher_ClearDownItemsWithUri.Replace("@URI@", uri);
            GetGraphConnection(context, constants.publish).ExecuteTableQuery(cypher, null);
            if (context.GetEnv().neo4JUrl1.Length > 0)
                GetGraphConnection(context, constants.publish, 1).ExecuteTableQuery(cypher, null);
            GetGraphConnection(context, constants.preview).ExecuteTableQuery(cypher, null);
            if (context.GetEnv().neo4JUrlDraft1.Length > 0)
                GetGraphConnection(context, constants.preview, 1).ExecuteTableQuery(cypher, null);

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
     }
}
