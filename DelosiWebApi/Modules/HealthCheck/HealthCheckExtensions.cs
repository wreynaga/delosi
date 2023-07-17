using Microsoft.Extensions.DependencyInjection;

namespace DelosiWebApi.Modules.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), tags: new[] { "database" })
                .AddCheck<HealthCheckCustom>("HealthCheckCustom", tags: new[] { "custom" });

            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }
    }
}
