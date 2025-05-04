using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Million.Application.Configuration;

namespace Million.Application.DIConfiguration
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// DI Constructor to Application Layer.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Mapper Repositories
            MapperConfiguration mapper = new(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddSingleton(mapper.CreateMapper());
            #endregion
            return services;
        }
    }
}
