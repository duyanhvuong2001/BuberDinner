using BuberDinner.Application.Common.Interfaces.Auth;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
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
        private readonly IUserRepository _userRepository;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthResult Login(string email, string password)
        {
            //Validate if user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email doesnt exist");
            }

            //Validate if password is correct
            if (user.Password != password)
            {
                throw new Exception("Wrong password");
            }

            //Create new JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResult(user, token);
        }

        public AuthResult Register(string firstname, string lastname, string email, string password)
        {
            //Validate user doesnt exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists");
            }

            //Create user (generate UID) & persist to db
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            //Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResult(user, token);
        }

    }
}
