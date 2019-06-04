using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MediaBrowserWSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        UserWSDTO ValidateUser(UserWSDTO user);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserWSDTO
    {
        bool isValid = true;
        string username = null;
        string password = null;
        string email = null;
        string errorMessage = null;

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
            set { password = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
        }
    }
}
