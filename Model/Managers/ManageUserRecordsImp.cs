using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ManageUserRecordsImp : IManageUserRecords
    {
        private static string table = "TabUser";
        public bool DeleteUser(string username, string password)
        {
            IDictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters["Password"] = username;
            Parameters["UserName"] = password;

            return CrudFunctions.Delete(table, Parameters) > 0;
        }

        public UserDTO RegisterUser(UserDTO userDetales)
        {
            if (UserNameExists(userDetales.UserName)) throw new Exceptions.ValidationException("Username Already Exists");
            if (EmailExists(userDetales.UserEmail)) throw new Exceptions.ValidationException("Email Already Exists");

            IDictionary<string, object> values = new Dictionary<string, object>();

            values["Password"] = userDetales.Password;
            values["UserName"] = userDetales.UserName;
            values["UserLevel"] = userDetales.UserLevel;
            values["UserEmail"] = userDetales.UserEmail;


            userDetales.UID = CrudFunctions.Create("UID", values, table);
            
            return userDetales;

        }
        public bool UserNameExists(string username) { return Exists("UserName", username); }
        public bool EmailExists(string email) { return Exists("UserEmail", email); }

        private static bool Exists(string field, string value)
        {
            IDictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters[field] = value;

            return CrudFunctions.Read(table, Parameters).Rows.Count > 0;
        }
        public bool UpdatePassword(UserDTO user, string newPassword)
        {
            IDictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters["Password"] = user.Password;
            Parameters["UserName"] = user.UserName;

            return CrudFunctions.UpdateField(table, "Password", newPassword, Parameters);
        }

        public UserDTO ValidateUser(string username, string password)
        {
            IDictionary<string, object> Parameters = new Dictionary<string, object>();

            Parameters["UserName"] = username;
            Parameters["Password"] = password;

            DataTable Results = CrudFunctions.Read(table, Parameters);
            if (Results.Rows.Count > 0)
                return Translate(Results.Rows[0]);
            else
                throw new Exceptions.ValidationException("Username or Password was incorrect");

        }
        public IList<UserDTO> Translate(DataTable records)
        {
            IList<UserDTO> DTOs = new List<UserDTO>();
            foreach (DataRow row in records.Rows)
            {
                DTOs.Add(Translate(row));
            }
            return DTOs;
        }
        public UserDTO Translate(DataRow userRecord)
        {
            return new UserDTO(
                userRecord.Field<string>("UserName"),
                userRecord.Field<string>("Password"),
                userRecord.Field<int>("UserLevel"),
                userRecord.Field<string>("UserEmail"),
                userRecord.Field<int>("UID")
                );
        }

        public IList<UserDTO> ListUsers(int? id = null)
        {
            IDictionary<string, object> Parameters = new Dictionary<string, object>();

            if (id != null) Parameters["UID"] = id; else Parameters["1"] = 1;

            return Translate(CrudFunctions.Read(table, Parameters));
        }
    }
}
