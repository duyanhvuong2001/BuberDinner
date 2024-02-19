using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Auth.Common;
using BuberDinner.Application.Auth.Commands.Register;
using BuberDinner.Application.Auth.Queries.Login;
using BuberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Authorization;
using MapsterMapper;

namespace BuberDinner.Api.Controllers
{

    [Route("/api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = _mapper.Map<RegisterCommand>(registerRequest);

            ErrorOr<AuthResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
                errors => Problem(errors)
                );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var query = _mapper.Map<LoginQuery>(loginRequest);

            var authResult = await _mediator.Send((query));

            if (authResult.IsError && authResult.FirstError == Errors.Auth.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
                errors => Problem(errors)
                );
        }
    }
}