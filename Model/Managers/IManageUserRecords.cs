using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IManageUserRecords
    {
        Model.UserDTO ValidateUser(string username, string password);
        Boolean DeleteUser(string username, string password);
        bool UpdatePassword(UserDTO user, string newPassword);

        UserDTO RegisterUser(Model.UserDTO userDetales);

    }
}
