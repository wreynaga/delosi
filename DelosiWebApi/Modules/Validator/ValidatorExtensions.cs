using Delosi.Application.Validator;

namespace DelosiWebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDtoValidator>();
            return services;
        }
    }
}
