using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;

namespace Rocksmith_Custom_DLC_Updater.Lib
{
    public class Model
    {
        public string table = "";
        public string[] tableColumns = { };

        public int Insert()
        {
            // Get the current table and data
            string table = this.GetTable();
            Dictionary<object, object> data = this.GetData();

            // Create the base of the sql string
            string sql = "INSERT INTO " + table;

            // Create two strings for column and value sql
            string columnSql = "(";
            string valuesSql = "VALUES (";

            // Loop through all data. Add the columns to the columns array, and values to the values array. Also create the column and value sql
            int parameterCount = 0;
            List<SQLiteParameter> values = new List<SQLiteParameter>();
            foreach (var pair in data)
            {
                string key = (string)pair.Key;
                object value = pair.Value;

                // This is for auto incrementing the id row
                if (key == "id")
                {
                    value = "null";
                }
                else
                {
                    SQLiteParameter parameter = new SQLiteParameter("@parameter" + parameterCount, value);
                    values.Add(parameter);
                    value = "@parameter" + parameterCount;
                    parameterCount++;
                }

                columnSql += key + ", ";
                valuesSql += value + ", ";
            }

            // Remove the last two characters from the columns and values sql strings
            columnSql = columnSql.Substring(0, columnSql.Length - 2);
            valuesSql = valuesSql.Substring(0, valuesSql.Length - 2);

            // Add the closing brackets to the two sql strings
            columnSql += ")";
            valuesSql += ")";

            // Add the two sql strings to the entire sql string
            sql += " " + columnSql + " " + valuesSql;

            // Create a command and execute the query
            SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
            command.Parameters.AddRange(values.ToArray());
            int amountAffected = command.ExecuteNonQuery();

            // Get the last inserted id
            string lastInsertSql = "SELECT last_insert_rowid()";
            SQLiteCommand command2 = new SQLiteCommand(lastInsertSql, DB.GetInstance());
            long lastId = (long)command2.ExecuteScalar();

            // Set the current object's id to the last id
            this.GetType().GetProperty("id").SetValue(this, lastId);

            // Return the amount of rows affected
            return amountAffected;
        }

        public int Update()
        {
            // Get the current table and data
            string table = this.GetTable();
            Dictionary<object, object> data = this.GetData();

            // Get the current id
            long id = (long)this.GetType().GetProperty("id").GetValue(this);

            if (id == 0)
            {
                return 0;
            }

            // Create the base of the sql string
            string sql = "UPDATE " + table + " SET ";

            // Create a string for the value sql
            string valueSql = "";

            // Loop through all the data and create the value sql
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            int parameterCount = 0;
            foreach (var pair in data)
            {
                if ((string)pair.Key != "id")
                {
                    SQLiteParameter parameter = new SQLiteParameter("@parameter" + parameterCount, pair.Value);
                    parameters.Add(parameter);
                    valueSql += pair.Key + " = @parameter" + parameterCount + ", ";
                    parameterCount++;
                }
            }

            // Remove the last two charactes from the value sql
            valueSql = valueSql.Substring(0, valueSql.Length - 2);

            // Create a string for the where sql
            string where = " WHERE id = " + id;

            // Add the two sql strings to the entire sql string
            sql += valueSql + where;

            // Create a command and execute the query
            SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
            command.Parameters.AddRange(parameters.ToArray());
            int amountAffected = command.ExecuteNonQuery();

            // Return the amount of rows affected
            return amountAffected;
        }

        public int Delete()
        {
            // Get the current table
            string table = this.GetTable();

            // Get the current id
            long id = (long)this.GetType().GetProperty("id").GetValue(this);

            if (id == 0)
            {
                return 0;
            }

            // Create the base of the sql string
            string sql = "DELETE FROM " + table + " WHERE id = " + id;

            // Create a command and execute the query
            SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
            int amountAffected = command.ExecuteNonQuery();

            // Return the amount of rows affected
            return amountAffected;
        }

        public void Find(string[] where, string orderBy = "")
        {
            // Get the current table and data
            string table = this.GetTable();
            Dictionary<object, object> data = this.GetData();

            // Create the base of the sql string
            string sql = "SELECT * FROM " + table;

            // Create the where part of the sql string
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            if (where != null)
            {
                sql += " WHERE " + where[0] + " " + where[1] + " @parameter1";
                parameters.Add(new SQLiteParameter("@parameter1", where[2]));
            }

            sql += " " + orderBy;

            try
            {
                // Create a command and a reader and execute the query
                SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
                command.Parameters.AddRange(parameters.ToArray());
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Loop through the reader and set the properties
                    while (reader.Read())
                    {
                        foreach (var pair in data)
                        {
                            object value = reader[(string)pair.Key];
                            if (value is System.DBNull)
                            {
                                value = "";
                            }
                            this.GetType().GetProperty((string)pair.Key).SetValue(this, value);
                        }
                    }
                }
            }
            catch (SQLiteException exception)
            {
                //Console.WriteLine(exception.Message);
            }
        }

        public void Find(string[,] whereArray, string orderBy = "")
        {
            // Get the current table and data
            string table = this.GetTable();
            Dictionary<object, object> data = this.GetData();

            // Create the base of the sql string
            string sql = "SELECT * FROM " + table;

            // Create the where part of the sql string
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            if (whereArray != null)
            {
                sql += " WHERE ";
                string whereSql = "";
                int parameterCount = 0;

                for (int i = 0; i < whereArray.Rank; i++)
                {
                    if (whereSql == "")
                    {
                        whereSql += whereArray[i, 0] + " " + whereArray[i, 1] + " @parameter" + parameterCount;
                    }
                    else
                    {
                        whereSql += " AND " + whereArray[i, 0] + " " + whereArray[i, 1] + " @parameter" + parameterCount;
                    }
                    parameters.Add(new SQLiteParameter("@parameter" + parameterCount, whereArray[i, 2]));
                    parameterCount++;
                }

                sql += whereSql;
            }

            sql += " " + orderBy;

            try
            {
                // Create a command and a reader and execute the query
                SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
                command.Parameters.AddRange(parameters.ToArray());
                SQLiteDataReader reader = command.ExecuteReader();

                // Loop through the reader and set the properties
                while (reader.Read())
                {
                    foreach (var pair in data)
                    {
                        object value = reader[(string)pair.Key];
                        if (value is System.DBNull)
                        {
                            value = "";
                        }
                        this.GetType().GetProperty((string)pair.Key).SetValue(this, value);
                    }
                }
            }
            catch (SQLiteException exception)
            {
                //Console.WriteLine(exception.Message);
            }
           
        }

        public List<object> FindAll(string orderBy = "")
        {
            // Get the current table and data
            string table = this.GetTable();
            Dictionary<object, object> data = this.GetData();

            // Create the base of the sql string
            string sql = "SELECT * FROM " + table + " " + orderBy;

            // Create a new list of objects
            List<object> result = new List<object>();

            try
            {
                // Create a command and a reader and execute the query
                SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
                SQLiteDataReader reader = command.ExecuteReader();

                // Loop through the reader and set the properties
                while (reader.Read())
                {
                    // Create a new object
                    var newObject = Activator.CreateInstance(this.GetType());

                    // Set the new object's properties
                    foreach (var pair in data)
                    {
                        object value = reader[(string)pair.Key];
                        if (value is System.DBNull)
                        {
                            value = "";
                        }
                        newObject.GetType().GetProperty((string)pair.Key).SetValue(newObject, value);
                    }

                    // Add the new object to the list
                    result.Add(newObject);
                }
            }
            catch (SQLiteException exception)
            {
                //Console.WriteLine(exception.Message);
            }

            return result;
        }

        public List<object> FindAll(string[] where, string orderBy = "")
        {
            // Get the current table and data
            string table = this.GetTable();
            Dictionary<object, object> data = this.GetData();

            // Create the base of the sql string
            string sql = "SELECT * FROM " + table;

            // Create the where part of the sql string
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            if (where != null)
            {
                sql += " WHERE " + where[0] + " " + where[1] + " @parameter1";
                parameters.Add(new SQLiteParameter("@parameter1", where[2]));
            }

            sql += " " + orderBy;

            // Create a new list of objects
            List<object> result = new List<object>();

            try
            {
                // Create a command and a reader and execute the query
                SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
                command.Parameters.AddRange(parameters.ToArray());
                SQLiteDataReader reader = command.ExecuteReader();

                // Loop through the reader and set the properties
                while (reader.Read())
                {
                    // Create a new object
                    var newObject = Activator.CreateInstance(this.GetType());

                    // Set the new object's properties
                    foreach (var pair in data)
                    {
                        object value = reader[(string)pair.Key];
                        if (value is System.DBNull)
                        {
                            value = "";
                        }
                        newObject.GetType().GetProperty((string)pair.Key).SetValue(newObject, value);
                    }

                    // Add the new object to the list
                    result.Add(newObject);
                }
            }
            catch (SQLiteException exception)
            {
                //Console.WriteLine(exception.Message);
            }

            return result;
        }

        public List<object> FindAll(string[,] whereArray, string orderBy = "")
        {
            // Get the current table and data
            string table = this.GetTable();
            Dictionary<object, object> data = this.GetData();

            // Create the base of the sql string
            string sql = "SELECT * FROM " + table;

            // Create the where part of the sql string
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            if (whereArray != null)
            {
                sql += " WHERE ";
                string whereSql = "";
                int parameterCount = 0;

                for (int i = 0; i < whereArray.Rank; i++)
                {
                    if (whereSql == "")
                    {
                        whereSql += whereArray[i, 0] + " " + whereArray[i, 1] + " @parameter" + parameterCount;
                    }
                    else
                    {
                        whereSql += " AND " + whereArray[i, 0] + " " + whereArray[i, 1] + " @parameter" + parameterCount;
                    }
                    parameters.Add(new SQLiteParameter("@parameter" + parameterCount, whereArray[i, 2]));
                    parameterCount++;
                }

                sql += whereSql;
            }

            sql += " " + orderBy;

            // Create a new list of objects
            List<object> result = new List<object>();

            try
            {
                // Create a command and a reader and execute the query
                SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
                command.Parameters.AddRange(parameters.ToArray());
                SQLiteDataReader reader = command.ExecuteReader();

                // Loop through the reader and set the properties
                while (reader.Read())
                {
                    // Create a new object
                    var newObject = Activator.CreateInstance(this.GetType());

                    // Set the new object's properties
                    foreach (var pair in data)
                    {
                        object value = reader[(string)pair.Key];
                        if (value is System.DBNull)
                        {
                            value = "";
                        }
                        newObject.GetType().GetProperty((string)pair.Key).SetValue(newObject, value);
                    }

                    // Add the new object to the list
                    result.Add(newObject);
                }
            }
            catch (SQLiteException exception)
            {
                //Console.WriteLine(exception.Message);
            }

            return result;
        }

        public void CreateTable(bool remove = false)
        {
            try
            {
                string table = this.GetTable();
                string[] tableColumns = this.GetTableColumns();

                string sql = "";
                SQLiteCommand command;
                if (remove)
                {
                    sql = "DELETE TABLE " + table;
                    command = new SQLiteCommand(sql, DB.GetInstance());
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE IF NOT EXISTS " + table + " (";
                foreach (string tableColumn in tableColumns)
                {
                    sql += tableColumn;
                }

                sql += ")";

                command = new SQLiteCommand(sql, DB.GetInstance());
                command.ExecuteNonQuery();
            }
            catch (SQLiteException exception)
            {
                //Console.WriteLine(exception.Message);
            }
        }

        public bool TableExists()
        {
            try
            {
                // Get the current table
                string table = this.GetTable();

                // Create the sql string
                string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='" + table + "'";

                // Create an sqlite command and execute it
                SQLiteCommand command = new SQLiteCommand(sql, DB.GetInstance());
                SQLiteDataReader reader = command.ExecuteReader();

                // If there are no rows, return false
                if (!reader.HasRows)
                {
                    return false;
                }

                return true;
            }
            catch (SQLiteException exception)
            {
                //Console.WriteLine(exception.Message);
            }
            return false;
        }

        public string GetTable()
        {
            return (string)this.GetType().GetField("table").GetValue(this);
        }

        public string[] GetTableColumns()
        {
            return (string[])this.GetType().GetField("tableColumns").GetValue(this);
        }

        public Dictionary<object, object> GetData()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            Dictionary<object, object> data = new Dictionary<object, object>();

            foreach (PropertyInfo property in properties)
            {
                data.Add(property.Name, property.GetValue(this, null));
            }

            return data;
        }
    }
}
