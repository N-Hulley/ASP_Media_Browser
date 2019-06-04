using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MediaBrowserWSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }


        public UserWSDTO ValidateUser(UserWSDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Invalid Arguments");
            }

            ControllerLayer.iUserManager UserManager = new ControllerLayer.UserManagerImp();
            try
            {
                return Translate(UserManager.ValidateUser(user.Username, user.Password));
            }
            catch
            {
                return "";
            }


        }

        private UserWSDTO Translate(ControllerLayer.UserDTO user)
        {
            UserWSDTO Output = new UserWSDTO();
            Output.email = user.Email;
            Output.Username = user.Username;
            return Output;
        }
    }
}
