using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ControllerLayer;

namespace UserWSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserLoginServiceImp : IUserLoginService
    {
        ControllerLayer.iUserManager UserManager = new ControllerLayer.UserManagerImp();
        public UserWSDTO ChangePassword(UserWSDTO user)
        {
            throw new NotImplementedException();
        }


        public UserWSDTO RegisterNewUser(UserWSDTO user)
        {
            //ControllerLayer.UserDTO user = new ControllerLayer.UserDTO();

            //UserManager.RegisterNewUser(, user.Password);
            return null;
        }

        public UserWSDTO ValidateUser(UserWSDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Invalid Arguments");
            }

            try
            {
                return Translate(UserManager.ValidateUser(user.Username, user.Password));
            }
            catch (Exception e)
            {
                UserWSDTO failedMessage = new UserWSDTO();
                failedMessage.IsValid = false;
                failedMessage.ErrorMessage = e.Message;
                return failedMessage;
            }


        }
        public UserWSDTO Translate(ControllerLayer.UserDTO user)
        {
            UserWSDTO Output = new UserWSDTO();
            Output.UID = user.UID;
            Output.Email = user.Email;
            Output.Username = user.Username;
            Output.UserLevel = user.UserLevel;
            Output.IsValid = user.isValid;
            return Output;
        }

        public bool DeleteUser(UserWSDTO user, int iD)
        {
            if (user.IsValid && user.UserLevel >= 3)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new System.Web.HttpRequestValidationException("Invalid user");
            }
        }

        public IList<UserWSDTO> GetUsers(UserWSDTO user, int? iD = null)
        {
            if (user.IsValid && user.UserLevel >= 3)
            {
                IList<UserWSDTO> Output = new List<UserWSDTO>();
                IList<ControllerLayer.UserDTO> users = UserManager.ListUsers(iD);
                for (int i = 0; i < users.Count; i++)
                {
                    Output.Add(Translate(users[i]));
                }
                return Output;
            }
            else
            {
                throw new System.Web.HttpRequestValidationException("Invalid user");
            }
        }
    }
}
