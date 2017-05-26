using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_NovichkovaEA_162
{
    public class User
    {
        private string login;
        private string password;

 
        public string Login
        {
            get { return login; }
            set { login = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }

public User()
        {

        }
    }
}
