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
        public bool DeleteUser(UserDTO user, string password)
        {
            Model.IManageUserRecords Manager = new Model.ManageUserRecordsImp();
            return Manager.DeleteUser(user.Username, password);
        }

        public UserDTO RegisterNewUser(UserDTO user, string password)
        {
            // Validate username and password
            InputValidation.ValidatePassword(password);

            UserDTO ValidatedUser;
            Model.IManageUserRecords Manager = new Model.ManageUserRecordsImp();

            try
            {
                Model.UserDTO NewUser = user.Translate(password);
                ValidatedUser = new UserDTO(Manager.RegisterUser(NewUser));
            }
            catch (Exceptions.ValidationException e)
            {
                // Throw validation exceptions through
                throw e;
            }
            catch (Exception)
            {
                // Catch generic errors as a database error and throw database error
                throw new Exceptions.DatabaseException("Failed to connect to database.");
            }

            return ValidatedUser;
        }

        public UserDTO ValidateUser(string username, string password)
        {
            // Validate username and password
            InputValidation.ValidateUsername(username);
            InputValidation.ValidatePassword(password);

            // Keep track of the user
            Model.UserDTO CurrentUser;

            try
            {
                Model.IManageUserRecords UserManager = new Model.ManageUserRecordsImp();
                CurrentUser = UserManager.ValidateUser(username, password);
            }
            catch (Exceptions.ValidationException e)
            {
                // Throw validation exceptions through
                throw e;
            }
            catch (Exception)
            {
                // Catch generic errors as a database error and throw database error
                throw new Exceptions.DatabaseException("Failed to connect to database.");
            }
            return new UserDTO(CurrentUser);
        }

    }
}
