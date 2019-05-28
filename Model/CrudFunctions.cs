using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CrudFunctions
    {
        private static string connectionDetales = "Data Source=SQL5020.site4now.net;Initial Catalog = DB_9AB8B7_B19ES7077; User ID = DB_9AB8B7_B19ES7077_admin; Password=qbES4uQW";
        private static SqlConnection openConnection() {
            try
            {
                SqlConnection Connection = new SqlConnection(connectionDetales);
                Connection.Open();
                return Connection;
            } catch (Exception)
            {
                throw new Exceptions.DatabaseException("Failed to connect to Database");
            }
        }
        private static void closeConnection(SqlConnection connection)
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
        public static Boolean Create(UserDTO user, string password)
        {
            const string tableName = "TabUser";
            IDictionary<string, object> values = new Dictionary<string, object>();
            
            values["Password"] = password;
            values["UserName"] = user.UserName;
            values["UserLevel"] = user.UserLevel;
            values["UserEmail"] = user.UserEmail;

            bool userCreated = false;

            using (SqlConnection connection = openConnection())
            {

                string sqlInsertInto = "";
                string sqlInsertIntoValues = "";
                for (int i = 0; i < values.Count; i++)
                {
                    sqlInsertInto += "'" + values.ElementAt(i).Key + "'";

                    bool isString = values.ElementAt(i).Value.Equals(typeof(String));

                    sqlInsertIntoValues += (isString ? "'" : "") + "@"  + values.ElementAt(i).Key + (isString ? "'" : "");

                    if (i < values.Count - 1)
                    {
                        sqlInsertInto += ", ";
                    }
                }

                String Query = " INSERT INTO " + tableName + " (" + sqlInsertInto + ") VALUES (" + sqlInsertIntoValues + ")";

                SqlCommand command = connection.CreateCommand();

                for (int i = 0; i < values.Count; i++)
                {
                    command.Parameters.AddWithValue("@" + values.ElementAt(i).Key, values.ElementAt(i).Value);
                }

                userCreated = command.ExecuteNonQuery() > 0;
                
                closeConnection(connection);
            }
            return userCreated;
        }

        public static Boolean Create(MediaDTO media)
        {
            const string tableName = "TabMedia";
            IDictionary<string, object> values = new Dictionary<string, object>();            

            values["Title"] = media.Title;
            values["Genre"] = media.Genre.GID;
            values["Director"] = media.Director.DID;
            values["Language"] = media.Language.LID;
            values["PublishYear"] = media.Year;
            values["Budget"] = media.Budget;
            
            bool userCreated = false;

            using (SqlConnection connection = openConnection())
            {

                string sqlInsertInto = "";
                string sqlInsertIntoValues = "";
                for (int i = 0; i < values.Count; i++)
                {
                    sqlInsertInto += values.ElementAt(i).Key ;

                    bool isString = values.ElementAt(i).Value is string;

                    sqlInsertIntoValues += (isString ? "'" : "") + "@" + values.ElementAt(i).Key + (isString ? "'" : "");
                    //sqlInsertIntoValues += "?";
                    if (i < values.Count - 1)
                    {
                        sqlInsertInto += ", ";
                        sqlInsertIntoValues += ", ";
                    }
                }

                String Query = "INSERT INTO " + tableName + " (" + sqlInsertInto + ") VALUES (" + sqlInsertIntoValues + ")";
                
                SqlCommand command = connection.CreateCommand();
                command.CommandText = Query;
                for (int i = 0; i < values.Count; i++)
                {
                    command.Parameters.AddWithValue("@" + values.ElementAt(i).Key, values.ElementAt(i).Value);
                }

                userCreated = command.ExecuteNonQuery() > 0;

                closeConnection(connection);
            }
            return userCreated;
        }

        private static Boolean UpdateField(string table, string fieldName, object value, string whereField, object whereValue) {
            
            using (SqlConnection connection = openConnection())
            {
                
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE " + table + " SET " + fieldName + "='" + value + "' WHERE  = @whereValue; ";
                command.Parameters.AddWithValue("@whereValue", whereValue);
                
                command.ExecuteNonQuery();
                closeConnection(connection);
            }
            
            return false;
        }

        
    }
}
