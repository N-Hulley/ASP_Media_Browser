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
        Model.IManageUserRecords Manager = new Model.ManageUserRecordsImp();
        public bool DeleteUser(UserDTO user, string password)
        {
            Model.IManageUserRecords Manager = new Model.ManageUserRecordsImp();
            return Manager.DeleteUser(user.Username, password);
        }

        public IList<UserDTO> ListUsers(int? id = null)
        {
            IList<UserDTO> Translated = new List<UserDTO>();
            IList<Model.UserDTO> Users = Manager.ListUsers(id);
            for (int i = 0; i < Users.Count; i++)
            {
                Translated.Add(new UserDTO(Users[i]));
            }
            return Translated;
        }

        public UserDTO RegisterNewUser(UserDTO user, string password)
        {
            // Validate username and password
            InputValidation.ValidatePassword(password);

            UserDTO ValidatedUser;

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

        public UserDTO UpdatePassword(UserDTO user, string oldPassword, string newPassword)
        {
            try
            {
                InputValidation.ValidatePassword(oldPassword);
            } catch (Exceptions.ValidationException e)
            {
                throw new Exceptions.ValidationException("Old Password: " + e.Message);
            }
            try
            {
                InputValidation.ValidatePassword(newPassword);
            }
            catch (Exceptions.ValidationException e)
            {
                throw new Exceptions.ValidationException("New Password: " + e.Message);
            }

            if (Manager.UpdatePassword(user.Translate(oldPassword), newPassword))
            {
                return user;
            }
            else
            {
                throw new Exceptions.ValidationException("Password is incorrect");
            }
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
                CurrentUser = Manager.ValidateUser(username, password);
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
