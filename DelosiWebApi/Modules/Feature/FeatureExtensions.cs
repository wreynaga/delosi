namespace DelosiWebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiDelosi";

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                               .AllowAnyHeader()
                                                                                        .AllowAnyMethod()
                                                                                        .AllowAnyOrigin()));
            services.AddMvc();

            return services;
        }
    }
}
