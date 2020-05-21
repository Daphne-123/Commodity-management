using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModel
{
    public class UserModel
    {
        private int id;

        public int Id { get => id; set => id = value; }

        private string username;

        public string Username { get => username; set => username = value; }

        private string password;

        public string Password { get => password; set => password = value; }

    }
}
