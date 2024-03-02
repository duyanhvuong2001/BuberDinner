using BuberDinner.Application.Auth.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Auth.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthResult>>;
}
