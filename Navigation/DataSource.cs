using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Navigation
{
    static class DataSource
    {

        private static List<User> myusers = new List<User>();
        private static ObservableCollection<Task> myTasks = new ObservableCollection<Task>();

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

        public static bool AddTask(Task tsk)
        {
            foreach (Task task in myTasks)
            {
                if(task.TaskId == tsk.TaskId)
                {
                    return false;
                }
            }
            myTasks.Add(tsk);
            return true;
        }

        public static ObservableCollection<Task> GetTasks()
        {
            return myTasks;
        }

        public static List<User> GetUsers()
        {
            return myusers;
        }
    }
}
