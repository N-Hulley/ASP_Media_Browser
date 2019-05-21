using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ICrudFunctions<T>
    {
        private static String connectionDetales = "";
        private SqlConnection openConnection()
        {
            try
            {
                return new SqlConnection(connectionDetales);
            } catch (Exception)
            {
                throw new Exceptions.DatabaseException("Failed to connect to Database");
            }
        }

        public Boolean UpdateField(string fieldName, T value) {
            using (SqlConnection connection = this.openConnection())
            {
            }


            return false;
        }
    }
}
