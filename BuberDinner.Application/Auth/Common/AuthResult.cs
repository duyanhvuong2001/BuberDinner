using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Auth.Common
{
    public record AuthResult(
        User User,
        string Token
        );
}
