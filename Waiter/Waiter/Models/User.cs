using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public User()
        {

        }

        public User(string UserName, string UserPassword)
        {
            this.Name     = UserName;
            this.Password = UserPassword;
        }
    }
}
