using ErrorOr;
using MediatR;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Auth;
using BuberDinner.Application.Auth.Common;
using BuberDinner.Domain.User;

namespace BuberDinner.Application.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            //Validate if user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Auth.InvalidCredentials;
            }

            //Validate if password is correct
            if (!user.Password.VerifyPassword(query.Password))
            {
                return Errors.Auth.InvalidCredentials;
            }

            //Create new JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResult(user, token);

        }
    }
}
