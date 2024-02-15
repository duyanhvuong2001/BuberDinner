using ErrorOr;


namespace BuberDinner.Application.Services.Auth
{
    public interface IAuthService
    {
        ErrorOr<AuthResult> Register(string firstname, string lastname, string email, string password);

        ErrorOr<AuthResult> Login(string email, string password);
    }
}
