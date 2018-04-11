using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking
{
    class Account
    {
        private string username;
        private string password;
        private string salt;

        public Account()
        {

        }

        public Account(string username, string password, string salt)
        {
            this.Username = username;
            this.Password = password;
            this.Salt = salt;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Salt { get => salt; set => salt = value; }
    }
}
