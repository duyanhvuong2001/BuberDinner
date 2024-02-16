using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Auth.Common;
using BuberDinner.Application.Auth.Commands.Register;
using BuberDinner.Application.Auth.Queries.Login;
using BuberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Authorization;

namespace BuberDinner.Api.Controllers
{

    [Route("/api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = new RegisterCommand(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);

            ErrorOr<AuthResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
        }

        private static AuthResponse MapAuthResult(AuthResult authResult)
        {
            return new AuthResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var authResult = await _mediator.Send(new LoginQuery(loginRequest.Email, loginRequest.Password));

            if (authResult.IsError && authResult.FirstError == Errors.Auth.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
        }
    }
}