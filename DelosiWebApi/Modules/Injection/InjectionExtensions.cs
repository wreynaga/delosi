using Delosi.Application.Interface;
using Delosi.Application.Main;
using Delosi.Domain.Core;
using Delosi.Domain.Interface;
using Delosi.Infrastructure.Data;
using Delosi.Infrastructure.Interface;
using Delosi.Infrastructure.Repository;
using Delosi.Transversal.Common;
using Delosi.Transversal.Logging;

namespace DelosiWebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DelosiContext>();
         
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();

            services.AddScoped<ILogicApplication, LogicApplication>();
            services.AddScoped<ILogicDomain, LogicDomain>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
