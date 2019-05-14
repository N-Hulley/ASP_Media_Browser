using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class UserManagerImp : iUserManager
    { 
        public UserDTO RegisterNewUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO ValidateUser(string username, string password)
        {
            // Validate username and password
            InputValidation.ValidatePassword(password);
            InputValidation.ValidateUsername(username);

            // Keep track of the user
            UserDTO CurrentUser;

            try
            {
                // Make a call to the model to validate the user
                Model.ModelDataSet.TabUserDataTable userRows = new Model.ModelDataSet.TabUserDataTable();
                Model.ModelDataSetTableAdapters.TabUserTableAdapter adapter = new Model.ModelDataSetTableAdapters.TabUserTableAdapter();

                Model.ModelDataSet.TabUserDataTable ValidUserTable = adapter.ValidateUser(username, password);

                // Test if password is wrong
                if (ValidUserTable.Count <= 0) throw new Exceptions.ValidationException("Username or password was incorrect");

                // Set the valid user to the first (And presumably only) response
                Model.ModelDataSet.TabUserRow ValidUser = ValidUserTable[0];

                // Create a user DTO to pass on
                CurrentUser = new UserDTO(ValidUser.UserName, ValidUser.UserEmail, ValidUser.UserLevel);
            }
            catch (ValidationException e)
            {
                // Throw validation exceptions through
                throw e;
            }
            catch (Exception)
            {
                // Catch generic errors as a database error and throw database error
                throw new Exceptions.DatabaseException("Failed to connect to database.");
            }
            return CurrentUser;
        }
    }
}
