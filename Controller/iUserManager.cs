using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public interface iUserManager
    {
        Boolean DeleteUser(UserDTO user, String password);
        /// <summary>
        /// Validate users login
        /// </summary>
        /// <exception cref="Controller.ValidationException">
        /// Is thrown if the login has failed, conditions include
        /// <list>
        /// <item><description>Username or password is incorrect</description></item>
        /// <item><description>Username is not valid</description></item>
        /// <item><description>Password is not valid</description></item>
        /// </list>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>A instance of the User class containing the users information</returns>
        UserDTO ValidateUser(String username, String password);
        UserDTO ValidateUser(UserDTO user, String password);

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        UserDTO RegisterNewUser(UserDTO userDTO);
    }
}
