using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CrudFunctions<TypeA, TypeB>
    {
        private static String connectionDetales = "Data Source=SQL5020.site4now.net;Initial Catalog = DB_9AB8B7_B19ES7077; User ID = DB_9AB8B7_B19ES7077_admin; Password=qbES4uQW";
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


        public static Boolean UpdateField(string table, string fieldName, TypeA value, string whereField, TypeB whereValue) {
            
            using (SqlConnection connection = openConnection())
            {
                
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE " + table + " SET " + fieldName + "='" + value + "' WHERE " + whereField + "= " + whereValue + "; ";

                command.ExecuteNonQuery();
                closeConnection(connection);
            }
            

            return false;
        }
    }
}
