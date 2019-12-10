using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMCMediaPLayer
{
    class User
    {
        HashComputer hasher = new HashComputer();

        //User Properties
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        

        //public constructors for the user object
        public User() { }
        public User(string userName, string password)
        {
            UserName = userName;
            Salt = hasher.generateSalt();
            PasswordHash = hasher.getHashedSaltedPassword(password, Salt);
        }
    }
}
