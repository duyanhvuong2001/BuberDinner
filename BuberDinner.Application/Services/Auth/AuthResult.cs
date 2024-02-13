using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Auth
{
    public record AuthResult(
        User User,
        string Token
        );
}
