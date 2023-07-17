﻿using AutoMapper;
using Delosi.Transversal.Mapper;

namespace DelosiWebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new MappingsProfile());
             });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
