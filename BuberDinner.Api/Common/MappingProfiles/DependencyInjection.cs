using Mapster;
using MapsterMapper;
using System.Reflection;

namespace BuberDinner.Api.Common.MappingProfiles
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.Scan(Assembly.GetExecutingAssembly());

            //Create the global config obj
            services.AddSingleton(config);

            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
