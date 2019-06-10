using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class CrudFunctions
    {
        private static string ConnectionDetales = "Data Source=SQL5020.site4now.net;Initial Catalog = DB_9AB8B7_B19ES7077; User ID = DB_9AB8B7_B19ES7077_admin; Password=qbES4uQW";
        private static SqlConnection OpenConnection() {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionDetales);
                Connection.Open();
                return Connection;
            } catch (Exception)
            {
                throw new Exceptions.DatabaseException("Failed to connect to Database");
            }
        }
        private static void CloseConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception)
            {
                throw new Exceptions.DatabaseException("Failed to connect to Database");
            }
        }
        public static int Delete(string table, IDictionary<string, object> conditions = null, bool useLike = false)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    string sqlWhereFields = conditions.Count > 0 ? " WHERE " : "";
                    for (int i = 0; i < conditions.Count; i++)
                    {

                        bool insertLike = conditions.ElementAt(i).Value is string && useLike;
                        sqlWhereFields += conditions.ElementAt(i).Key + (insertLike ? " LIKE " : " = ");


                        sqlWhereFields += "@" + conditions.ElementAt(i).Key;
                        //sqlInsertIntoValues += "?";
                        if (i < conditions.Count - 1)
                        {
                            sqlWhereFields += " AND ";
                        }
                    }

                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM " + table + sqlWhereFields;

                    for (int i = 0; i < conditions.Count; i++)
                    {
                        bool insertLike = conditions.ElementAt(i).Value is string && useLike;
                        object insertString = insertLike ? $"%{(string)conditions.ElementAt(i).Value}%" : conditions.ElementAt(i).Value;

                        command.Parameters.AddWithValue("@" + conditions.ElementAt(i).Key, insertString);
                    }
                    int output = command.ExecuteNonQuery();
                    CloseConnection(connection);
                    return output;
                }
                } catch (SqlException e)
            {
                throw new Exceptions.DatabaseException("Failed to delete from database");
            }
            
            
        }

        public static DataTable Read(string table, IDictionary<string, object> conditions = null, bool useLike = false)
        {
            DataTable output = new DataTable();


            using (SqlConnection connection = OpenConnection())
            {
                string sqlWhereFields = conditions.Count > 0 ? " WHERE " : "";
                for ( int i = 0; i < conditions.Count; i++)
                {

                    bool insertLike = conditions.ElementAt(i).Value is string && useLike;
                    sqlWhereFields += conditions.ElementAt(i).Key + (insertLike ? " LIKE " : " = ");


                    sqlWhereFields += "@" + conditions.ElementAt(i).Key;
                    //sqlInsertIntoValues += "?";
                    if (i < conditions.Count - 1)
                    {
                        sqlWhereFields += " AND ";
                    }
                }

                SqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM " + table + sqlWhereFields;

                for (int i = 0; i < conditions.Count; i++)
                {
                    bool insertLike = conditions.ElementAt(i).Value is string && useLike;
                    object insertString = insertLike ? $"%{(string)conditions.ElementAt(i).Value}%" : conditions.ElementAt(i).Value;
                   
                    command.Parameters.AddWithValue("@" + conditions.ElementAt(i).Key, insertString);
                }

                SqlDataAdapter Adapter = new SqlDataAdapter(command);
                Adapter.Fill(output);
                CloseConnection(connection);
            }

            return output;
        }
        public static int Create(string idName, IDictionary<string, object> values, string tableName)
        {

            int modified;
            using (SqlConnection connection = OpenConnection())
            {

                string sqlInsertInto = "";
                string sqlInsertIntoValues = "";
                for (int i = 0; i < values.Count; i++)
                {
                    sqlInsertInto += values.ElementAt(i).Key ;

                    bool isString = values.ElementAt(i).Value is string;

                    if (isString) sqlInsertIntoValues += "";
                    sqlInsertIntoValues +=  "@" + values.ElementAt(i).Key;
                    if (isString) sqlInsertIntoValues += "";

                    //sqlInsertIntoValues += "?";
                    if (i < values.Count - 1)
                    {
                        sqlInsertInto += ", ";
                        sqlInsertIntoValues += ", ";
                    }
                }

                String Query = "INSERT INTO " + tableName + " (" + sqlInsertInto + ") output INSERTED." + idName + " VALUES (" + sqlInsertIntoValues + ")";
                
                SqlCommand command = connection.CreateCommand();
                command.CommandText = Query;
                for (int i = 0; i < values.Count; i++)
                {
                    bool isString = values.ElementAt(i).Value is string;
                    command.Parameters.AddWithValue("@" + values.ElementAt(i).Key, values.ElementAt(i).Value);
                }

                modified = (int)command.ExecuteScalar();

                CloseConnection(connection);
            }
            return modified;
        }

        public static Boolean UpdateField(string table, string fieldName, object value, IDictionary<string, object> parameters = null)
        {
            bool Success = false;

            using (SqlConnection connection = OpenConnection())
            {
                string sqlWhereFields = " WHERE ";
                for (int i = 0; i < parameters.Count; i++)
                {
                    sqlWhereFields += parameters.ElementAt(i).Key + " = ";

                    bool isString = parameters.ElementAt(i).Value is string;

                    if (isString) sqlWhereFields += "'";
                    sqlWhereFields += "@" + parameters.ElementAt(i).Key;
                    if (isString) sqlWhereFields += "'";
                    //sqlInsertIntoValues += "?";
                    if (i < parameters.Count - 1)
                    {
                        sqlWhereFields += " AND ";
                    }
                }

                SqlCommand command = connection.CreateCommand();

;
                command.CommandText = "UPDATE " + table + " SET " + fieldName + " = " + (value is string ? "'" : "") + value + (value is string ? "'" : "") + sqlWhereFields;

                for (int i = 0; i < parameters.Count; i++)
                {
                    command.Parameters.AddWithValue("@" + parameters.ElementAt(i).Key, parameters.ElementAt(i).Value);
                }

                command.ExecuteNonQuery();
                Success = true;
                CloseConnection(connection);
            }
            
            return Success;
        }

        
    }
}
