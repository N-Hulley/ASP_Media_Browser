using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDTO
    {
        public UserDTO(string userName, string password, int userLevel, string userEmail)
        {
            UserName = userName;
            Password = password;
            UserLevel = userLevel;
            UserEmail = userEmail;
        }
        

        public int UID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserLevel { get; set; }
        public string UserEmail { get; set; }

    }
}
