using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Auth
{
    public interface IAuthService
    {
        AuthResult Register(string firstname, string lastname, string email, string password);

        AuthResult Login(string email, string password);
    }
}
