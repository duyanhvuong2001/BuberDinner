using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Auth
{
    public class AuthService : IAuthService
    {
        public AuthResult Login(string email, string password)
        {
            return new AuthResult(Guid.NewGuid(), "fname", "lname", email, "token");
        }

        public AuthResult Register(string firstname, string lastname, string email, string password)
        {
            return new AuthResult(Guid.NewGuid(), firstname, lastname, email, "token");
        }

    }
}
