using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserWSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserLoginService
    {


        [OperationContract]
        UserWSDTO ValidateUser(UserWSDTO user);

        [OperationContract]
        UserWSDTO ChangePassword(UserWSDTO user);

        [OperationContract]
        UserWSDTO RegisterNewUser(UserWSDTO user);

        bool DeleteUser(UserWSService.UserWSDTO user, int iD);
        UserWSDTO Translate(ControllerLayer.UserDTO user);
        IList<UserWSDTO> GetUsers(UserWSDTO user, int? iD = null);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserWSDTO
    {
        bool isValid = false;
        string username = null;
        string password = null;
        string email = null;
        string errorMessage = null;
        int? userLevel = null;
        int? uID = null;



        [DataMember]
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        [DataMember]
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        [DataMember]
        public int? UserLevel
        {
            get { return userLevel; }
            set { userLevel = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        [DataMember]
        public int? UID
        {
            set { uID = value; }
            get { return uID; }
        }
    }
}
