using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation
{
    class User
    {
        string username;
        string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
