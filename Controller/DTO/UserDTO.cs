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
        public UserDTO(Model.UserDTO user)
        {
            this.Username = user.UserName;
            this.Email = user.UserEmail;
            this.UserLevel = user.UserLevel;
        }
        public Model.UserDTO Translate(string password)
        {
            return new Model.UserDTO(
                this.Username,
                password,
                this.UserLevel,
                this.Email
            );
        }
    }
}