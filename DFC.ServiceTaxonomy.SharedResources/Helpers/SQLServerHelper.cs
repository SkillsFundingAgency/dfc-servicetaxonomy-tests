
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;



namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public class SQLServerHelper
    {
        private const string Apos = "'";
        private const string permissionsSql = "SELECT count(permission_name) FROM fn_my_permissions('','DATABASE') where permission_name in (__VALUES__)";

        private SqlConnection Connection;
        private Dictionary<string, string> ReplacementDict = new Dictionary<string, string>();

        public string parameterTableReferenceFieldName { get; set; } = "ParameterName";
        public string parameterTableValueFieldName { get; set; } = "ParameterValue";

        public void AddReplacementRule(string original, string replacement)
        {
            ReplacementDict[original] = replacement;
        }

        public void SetConnection(string connectionString)
        {
            connectionString.Should().NotBeNullOrEmpty();
            Connection = new SqlConnection(connectionString);
        }

        public Boolean OpenConnection()
        {
            if (Connection.ConnectionString != string.Empty)
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
            return (Connection.State == System.Data.ConnectionState.Open);
        }

        public Boolean CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Dispose();
                return true;
            }
            return false;
        }

        string checkForReplacements(string fieldName)
        {
            string returnString = fieldName;
            foreach (var item in ReplacementDict)
            {
                if (item.Key == fieldName)
                {
                    returnString = item.Value;
                }
            }
            return returnString;
        }

        public bool DoesResourceExist(string table, string recordId)
        {
            bool returnValue = false;
            string sql = @"select* from[" + table + "] where id = '" + recordId + "'";
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();//(CommandBehavior.CloseConnection);
                        if (reader.HasRows)
                        {
                            returnValue = true;  // data exists
                        }
                        reader.Close();
                    }
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se);
                }
            }
            return returnValue;
        }

        public DataSet GetRecord(string table, string recordId, string orderBy = "", string additionalClause = "")
        {
            DataSet ds = new DataSet(table);
            string sql = @"select* from[" + table + "] where id = '" + recordId + "'" + (additionalClause.Length >0 ? " AND " + additionalClause : "" );

            if (orderBy.Length > 0)
            {
                sql = sql + " order by " + orderBy;

            }
            Console.WriteLine("SQLHelper: GetRecord. Table: " + table + " id: " + recordId);
            Console.WriteLine("SQLHelper: sql: " + sql);
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try { 
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                    }
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se);
                }
            }
            return ds;
        }

        public string GetFieldValueFromRecord(string field, string table, string whereClause = "")
        {
            DataSet ds = new DataSet(table);
            string sql = @"select " + field + " from[" + table + "] where " + whereClause + ";"  ;
            string returnValue = "";

            Console.WriteLine("SQLHelper: GetRecord. Table: " + table + " where: " + whereClause);
            Console.WriteLine("SQLHelper: sql: " + sql);
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        returnValue = cmd.ExecuteScalar().ToString();
                    }
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se);
                }
            }
            return returnValue;
        }


        public long GetRecordCount(string table, string recordId )
        {
            return GetRecordCount( table, "id",  recordId);
        }

        public long GetRecordCount(string table, string columnName, string recordId)
        {
            string sql = @"select count(1) from[" + table + "] where " + columnName + " = '" + recordId + "'";
            string returnValueString = "0";

            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        returnValueString = cmd.ExecuteScalar().ToString(); ;
                    }
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se);
                }
            }
            return long.Parse(returnValueString);
        }

        public List<Dictionary<string, string>> GetDataTableDictionaryList(DataSet dataSet, string primaryKey)
        {
            DataTable dataTable = dataSet.Tables[0];
            DateTime dateValue;
            return dataTable.AsEnumerable().Select(
                row => dataTable.Columns.Cast<DataColumn>().ToDictionary(
                    column => ( column.ColumnName=="id" ? primaryKey : column.ColumnName ),
                    column => (DateTime.TryParse(row[column].ToString(), out dateValue) ? dateValue.ToString("yyyy-MM-ddTHH:mm:ss.ffffZ") : row[column].ToString())
                )).ToList();
        }

        public bool InsertRecordFromJson(string table, string json)
        {
            string sqlString = "insert into [" + table + "] (";
            string sqlValuesString = ") VALUES (";
            bool firstOne = true;
            // check if connected
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                //translate json into sql insert statement  
                Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach (var item in dict)
                {
                    sqlString += (firstOne ? "" : ",") + checkForReplacements(item.Key);
                    sqlValuesString += (firstOne ? "" : ",") + (string.IsNullOrEmpty(item.Value) ? "NULL" : "'" + item.Value.Replace("'", "''") + "'");
                    firstOne = false;
                }
                sqlString += sqlValuesString + ")";
                try
                {
                    SqlCommand newCommand = new SqlCommand(sqlString, Connection);
                    newCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return true;
        }
        public DataSet ExecuteTableFunction(string functionName, string[] parameters)
        {
            DataSet ds = new DataSet(functionName);
            string paramsString = "";
            parameters.Where((data, index) =>
            {
                paramsString += (index > 0 ? "," : "(") + Apos + data + Apos + (index == parameters.Length - 1 ? ")" : "");
                return false;
            }).Any();

            string sqlString = "select * from [" + functionName + "] " + paramsString;
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(sqlString, Connection);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = myCommand;
                    da.Fill(ds);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return ds;
        }

        public IEnumerable<T> ExecuteObject<T>(string sqlString) where T : class, new()
        {
            List<T> items = new List<T>();
            DataSet ds = new DataSet();
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(sqlString, Connection);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = myCommand;
                    da.Fill(ds);

                    foreach (var row in ds.Tables[0].AsEnumerable())
                    {
                        T obj = new T();

                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            try
                            {
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                                propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        items.Add(obj);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return items;
        }

        public int ExecuteNonQuery(string commandText)
        {
            int rowsAffected = 0;
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(commandText, Connection);
                    rowsAffected = myCommand.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return rowsAffected;
        }

        public (bool,string) ExecuteScalar(string commandText, string[] parameters)
        {
            string message = string.Empty;
            bool success = true;
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(commandText, Connection);
                    message = myCommand.ExecuteScalar().ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    message = e.Message;
                    success = false;
                }
            }
            return (success,message);
        }
 
        public bool CheckRecordExists(string table, string primaryKey, string recordId)
        {
            bool success = false;
            string sqlString = "select * from [" + table + "] where " + checkForReplacements(primaryKey) + " = '" + recordId + "'";
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(sqlString, Connection);
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            if (myReader[checkForReplacements(primaryKey)].ToString() == recordId)
                            {
                                success = true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return success;
        }

        public bool DeleteRecord(string table, string primaryKey, string recordId)
        {
            bool success = false;
            string sqlString = "delete from [" + table + "] where " + checkForReplacements(primaryKey) + " = '" + recordId + "'";
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    using (SqlCommand myCommand = new SqlCommand(sqlString, Connection))
                    {
                        var result = myCommand.ExecuteNonQuery();
                        success = (result == 1);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return success;
        }

        public bool CheckPermissions(string[] requiredPermissions)
        {
            bool success = false;
            string returnValue;
            string list = string.Empty;
            foreach (var item in requiredPermissions)
            {
                list += (list == string.Empty ? string.Empty : ", ") + $"'{item}'";
            }
            (success, returnValue ) = ExecuteScalar(permissionsSql.Replace("__VALUES__", list),null);
            success = success && int.Parse(returnValue) == requiredPermissions.Count();
            return success;
        }
    }
}
