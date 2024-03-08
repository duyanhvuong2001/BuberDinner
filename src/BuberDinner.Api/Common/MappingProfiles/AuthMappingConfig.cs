using BuberDinner.Application.Auth.Commands.Register;
using BuberDinner.Application.Auth.Common;
using BuberDinner.Application.Auth.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.MappingProfiles
{
    public class AuthMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //Auth mapping profiles
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthResult, AuthResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest.Id, src => src.User.Id.Value.ToString())
                .Map(dest => dest, src => src.User);


        }
    }
}
