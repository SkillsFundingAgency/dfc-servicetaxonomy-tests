
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;



namespace DFC.ServiceTaxonomy.SharedResources.Helpers
{
    public class SQLServerHelper
    {

        private SqlConnection Connection;
        private Dictionary<string, string> ReplacementDict = new Dictionary<string, string>();
        private const string Apos = "'";
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


        public long GetRecordCount(string table, string recordId )
        {
            return GetRecordCount( table, "id",  recordId);
        }

        public long GetRecordCount(string table, string columnName, string recordId)
        {
            // DataSet ds = new DataSet(table);
            string sql = @"select count(1) from[" + table + "] where " + columnName + " = '" + recordId + "'";
            string returnValueString = "0";

            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        returnValueString = cmd.ExecuteScalar().ToString(); ;
                        //SqlDataAdapter da = new SqlDataAdapter();
                        //da.SelectCommand = cmd;
                        //da.Fill(ds);
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

        public int ExecuteNonQuery(string commandText, string[] parameters)
        {
            string paramsString = "";
            int rowsAffected = 0;
            //parameters.Where((data, index) =>
            //{
            //    paramsString += (index > 0 ? "," : "(") + Apos + data + Apos + (index == parameters.Length - 1 ? ")" : "");
            //    return false;
            //}).Any();

    //        string sqlString = "select * from [" + functionName + "] " + paramsString;
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(commandText, Connection);
                    // myCommand.CommandText = commandText;


                    rowsAffected = myCommand.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return rowsAffected;
        }


        public DataSet ExecuteStoredProcedure(string procName)
        {
            DataSet ds = new DataSet(procName);
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(procName, Connection);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Add("@TouchPointId", SqlDbType.VarChar).Value = "9000000001";
                    myCommand.Parameters.Add("@TaxYear", SqlDbType.VarChar).Value = "1920";
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
        public string GetParameterValue(string table, string parameterName)
        {
            //todo
            return null;
        }
        //public bool UpsertParameterValue(string table, string parameterName, string ParameterValue)
        //{
        //    bool success = true;
        //    //   parameterTableReferenceFieldName
        //    //   parameterTableValueFieldName
        //    string sqlString =
        //        "IF EXISTS (SELECT {NAMEFIELD} FROM [dbo].[{TABLE}] WHERE {NAMEFIELD} = '{NAME}')" + System.Environment.NewLine +
        //        "BEGIN" + System.Environment.NewLine +
        //        "UPDATE[dbo].[{TABLE}] SET {VALUEFIELD} = '{VALUE}' WHERE {NAMEFIELD} = '{NAME}'" + System.Environment.NewLine +
        //        "END" + System.Environment.NewLine +
        //        "ELSE" + System.Environment.NewLine +
        //        "BEGIN" + System.Environment.NewLine +
        //        "INSERT INTO[dbo].[{TABLE}]" + System.Environment.NewLine +
        //        "({NAMEFIELD}, {VALUEFIELD}) VALUES('{NAME}', '{VALUE}')" + System.Environment.NewLine +
        //        "END";
        //    sqlString = sqlString.Replace("{TABLE}", table);
        //    sqlString = sqlString.Replace("{NAMEFIELD}", parameterTableReferenceFieldName);
        //    sqlString = sqlString.Replace("{VALUEFIELD}", parameterTableValueFieldName);
        //    sqlString = sqlString.Replace("{NAME}", parameterName);
        //    sqlString = sqlString.Replace("{VALUE}", ParameterValue);
        //    // check if connected
        //    if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
        //    {
        //        try
        //        {
        //            SqlCommand newCommand = new SqlCommand(sqlString, Connection);
        //            newCommand.ExecuteNonQuery();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.ToString());
        //            success = false;
        //        }
        //    }
        //    return success;
        //}


    }
}
