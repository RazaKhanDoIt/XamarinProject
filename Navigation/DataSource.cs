using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation
{
    static class DataSource
    {

        private static List<User> myusers = new List<User>();

        public static bool AddUser(User usr)
        {
            foreach (User user in myusers)
            {
                if(usr.Username == user.Username)
                {
                    return false;
                }
            }
            myusers.Add(usr);
            return true;
        }

        public static bool Login(string username,string password)
        {
            foreach (User user in myusers)
            {
                if(user.Username == username)
                {
                    if(user.Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
