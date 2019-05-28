using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDTO
    {
        public int UID { get; set; }
        public string UserName { get; set; }
        private string Password;
        public int UserLevel { get; set; }
        public string UserEmail { get; set; }

        public Boolean VerifyUser(string password)
        {
            bool userVerified = false;
            return userVerified;
        }
    }
}
