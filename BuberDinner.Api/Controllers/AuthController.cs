using BuberDinner.Application.Services.Auth;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using BuberDinner.Application.Common.Errors;
using ErrorOr;

namespace BuberDinner.Api.Controllers
{

    [Route("/api/[controller]")]

    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            ErrorOr<AuthResult> authResult = _authService.Register(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
        }

        private static AuthResponse MapAuthResult(AuthResult authResult)
        {
            return new AuthResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        }

        [HttpPost("/login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authResult = _authService.Login(loginRequest.Email, loginRequest.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
        }
    }

}