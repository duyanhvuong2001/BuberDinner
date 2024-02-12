using BuberDinner.Application.Common.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthResult Login(string email, string password)
        {
            return new AuthResult(Guid.NewGuid(), "fname", "lname", email, "token");
        }

        public AuthResult Register(string firstname, string lastname, string email, string password)
        {
            //Check if user exists

            //Create user (generate UID)
            var userId = Guid.NewGuid();

            //Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(userId, firstname, lastname);

            return new AuthResult(userId, firstname, lastname, email, token);
        }

    }
}
