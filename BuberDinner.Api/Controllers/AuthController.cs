using BuberDinner.Application.Auth;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            var authResult = _authService.Register(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password);

            var response = new AuthResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);

            return Ok(response);
        }

        [HttpPost("/login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authResult = _authService.Login(loginRequest.Email, loginRequest.Password);
            var response = new AuthResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
            return Ok(response);
        }
    }
}
