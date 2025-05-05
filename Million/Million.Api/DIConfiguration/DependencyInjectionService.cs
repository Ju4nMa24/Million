﻿using Microsoft.OpenApi.Models;
using Million.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;

namespace Million.Api.DIConfiguration
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// DI Configuration builder.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme() { In = ParameterLocation.Header, Name = "Authorization", Type = SecuritySchemeType.ApiKey });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            #region Health Check Configuration
            services.AddHealthChecksUI().AddInMemoryStorage();
            #endregion
            services.AddIdentityApiEndpoints<UserEntity>();
            return services;
        }
    }
}
