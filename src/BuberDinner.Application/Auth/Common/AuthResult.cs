using BuberDinner.Domain.User;

namespace BuberDinner.Application.Auth.Common
{
    public record AuthResult(
        User User,
        string Token
        );
}
