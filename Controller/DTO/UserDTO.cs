using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class UserDTO
    {
        public String Username { get; set; }
        public String Email { get; set; }
        public int UserLevel { get; set; }

        /// <summary>
        /// Keep track of information that may be displayed to the user or used for front end processes
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="userLevel"></param>
        public UserDTO(String username, String email, int userLevel)
        {
            this.Username = username;
            this.Email = email;
            this.UserLevel = userLevel;
        }
    }
}