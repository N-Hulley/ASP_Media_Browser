using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IManageUserRecords<T>
    {
        Model.UserDTO ValidateUser(string username, string password);
        Boolean DeleteUser(string username, string password);
        Boolean UpdatePassword(string fieldName, T value);

    }
}
