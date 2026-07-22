using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login1
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static class UserManager
    {
        public static List<User> users = new List<User>();

        public static bool Register(string username, string password)
        {
            if (users.Any(u => u.Username == username))
                return false;

            users.Add(new User
            {
                Username = username,
                Password = password
            });

            return true;
        }

        public static bool Login(string username, string password)
        {
            return users.Any(u =>
                u.Username == username &&
                u.Password == password);
        }
    }
}