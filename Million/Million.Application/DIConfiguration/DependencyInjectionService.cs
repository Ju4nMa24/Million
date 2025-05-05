using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Million.Application.Configuration;
using Million.Application.Database.Commands.Address.CreateAddressCommand;
using Million.Application.Database.Commands.Address.DeleteAddressCommand;
using Million.Application.Database.Commands.Address.UpdateAddressCommand;
using Million.Application.Database.Commands.Owner.CreateOwnerCommand;
using Million.Application.Database.Commands.Owner.DeleteOwnerCommand;
using Million.Application.Database.Commands.Owner.UpdateOwnerCommand;
using Million.Application.Database.Commands.OwnerContact.CreateOwnerContactCommand;
using Million.Application.Database.Commands.OwnerContact.DeleteOwnerContactCommand;
using Million.Application.Database.Commands.OwnerContact.UpdateOwnerContactCommand;
using Million.Application.Database.Commands.Property.CreatePropertyCommand;
using Million.Application.Database.Commands.Property.DeleteAddressCommand;
using Million.Application.Database.Commands.Property.UpdatePropertyCommand;
using Million.Application.Database.Commands.PropertyImage.CreatePropertyImageCommand;
using Million.Application.Database.Commands.PropertyImage.DeletePropertyImageCommand;
using Million.Application.Database.Commands.PropertyImage.UpdatePropertyImageCommand;
using Million.Application.Database.Commands.PropertyTrace.CreatePropertyTraceCommand;
using Million.Application.Database.Commands.PropertyTrace.DeleteAddressCommand;
using Million.Application.Database.Commands.PropertyTrace.UpdatePropertyTraceCommand;
using Million.Application.Database.Queries.GetAddressQuery;
using Million.Application.Database.Queries.GetOwnerContactByIdQuery;
using Million.Application.Database.Queries.GetOwnerQuery;
using Million.Application.Database.Queries.GetPropertyImageQuery;
using Million.Application.Database.Queries.GetPropertyQuery;
using Million.Application.Database.Queries.GetPropertyTraceQuery;
using Million.Application.Validators.Address;
using Million.Application.Validators.Owner;
using Million.Application.Validators.Property;

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
            #region Addresses Repositories
            services.AddTransient<IGetAddressQuery, GetAddressQuery>();
            services.AddTransient<ICreateAddressCommand, CreateAddressCommand>();
            services.AddTransient<IUpdateAddressCommand, UpdateAddressCommand>();
            services.AddTransient<IDeleteAddressCommand, DeleteAddressCommand>();
            #endregion
            #region Owners Repositories
            services.AddTransient<IGetOwnerQuery, GetOwnerQuery>();
            services.AddTransient<ICreateOwnerCommand, CreateOwnerCommand>();
            services.AddTransient<IUpdateOwnerCommand, UpdateOwnerCommand>();
            services.AddTransient<IDeleteOwnerCommand, DeleteOwnerCommand>();
            #endregion
            #region Properties Repositories
            services.AddTransient<IGetPropertyQuery, GetPropertyQuery>();
            services.AddTransient<ICreatePropertyCommand, CreatePropertyCommand>();
            services.AddTransient<IUpdatePropertyCommand, UpdatePropertyCommand>();
            services.AddTransient<IDeletePropertyCommand, DeletePropertyCommand>();
            #endregion
            #region Property Images Repository
            services.AddTransient<IGetPropertyImageQuery, GetPropertyImageQuery>();
            services.AddTransient<ICreatePropertyImageCommand, CreatePropertyImageCommand>();
            services.AddTransient<IUpdatePropertyImageCommand, UpdatePropertyImageCommand>();
            services.AddTransient<IDeletePropertyImageCommand, DeletePropertyImageCommand>();
            #endregion
            #region Property Traces Repository
            services.AddTransient<IGetPropertyTraceQuery, GetPropertyTraceQuery>();
            services.AddTransient<ICreatePropertyTraceCommand, CreatePropertyTraceCommand>();
            services.AddTransient<IUpdatePropertyTraceCommand, UpdatePropertyTraceCommand>();
            services.AddTransient<IDeletePropertyTraceCommand, DeletePropertyTraceCommand>();
            #endregion
            #region Owner Contact Repository
            services.AddTransient<ICreateOwnerContactCommand, CreateOwnerContactCommand>();
            services.AddTransient<IUpdateOwnerContactCommand, UpdateOwnerContactCommand>();
            services.AddTransient<IDeleteOwnerContactCommand, DeleteOwnerContactCommand>();
            services.AddTransient<IGetOwnerContactByIdQuery, GetOwnerContactByIdQuery>();

            #endregion
            #region Address Validator
            services.AddScoped<IValidator<CreateAddressModel>, CreateAddressModelValidator>();
            services.AddScoped<IValidator<UpdateAddressModel>, UpdateAddressModelValidator>();
            #endregion
            #region Owner Validator
            services.AddScoped<IValidator<CreateOwnerModel>, CreateOwnerModelValidator>();
            services.AddScoped<IValidator<UpdateOwnerModel>, UpdateOwnerModelValidator>();
            #endregion
            #region Property Validator
            services.AddScoped<IValidator<CreatePropertyModel>, CreatePropertyModelValidator>();
            services.AddScoped<IValidator<UpdatePropertyModel>, UpdatePropertyModelValidator>();
            #endregion
            return services;
        }
    }
}
