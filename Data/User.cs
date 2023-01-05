using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Data
{
    internal class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public User(string login = "Admin", string password = "admin123")
        {
            Login = login;
            Password = password;
        }
    }
}
