using AutoMapper;
using Million.Application.Database.Commands.Address.CreateAddressCommand;
using Million.Application.Database.Commands.Address.DeleteAddressCommand;
using Million.Application.Database.Commands.Address.UpdateAddressCommand;
using Million.Application.Database.Commands.Owner.CreateOwnerCommand;
using Million.Application.Database.Commands.Owner.DeleteOwnerCommand;
using Million.Application.Database.Commands.Owner.UpdateOwnerCommand;
using Million.Application.Database.Commands.OwnerContact.CreateOwnerContactCommand;
using Million.Application.Database.Commands.OwnerContact.UpdateOwnerContactCommand;
using Million.Application.Database.Commands.Property.CreatePropertyCommand;
using Million.Application.Database.Commands.Property.DeleteAddressCommand;
using Million.Application.Database.Commands.Property.UpdatePropertyCommand;
using Million.Application.Database.Commands.PropertyImage.CreatePropertyImageCommand;
using Million.Application.Database.Commands.PropertyImage.DeletePropertyImageCommand;
using Million.Application.Database.Commands.PropertyImage.UpdatePropertyImageCommand;
using Million.Application.Database.Commands.PropertyTrace.CreatePropertyTraceCommand;
using Million.Application.Database.Commands.PropertyTrace.UpdatePropertyTraceCommand;
using Million.Application.Database.Queries.GetAddressQuery;
using Million.Application.Database.Queries.GetOwnerQuery;
using Million.Application.Database.Queries.GetPropertyImageQuery;
using Million.Application.Database.Queries.GetPropertyQuery;
using Million.Application.Database.Queries.GetPropertyTraceQuery;
using Million.Domain.Entities.Address;
using Million.Domain.Entities.Owner;
using Million.Domain.Entities.OwnerContact;
using Million.Domain.Entities.Property;
using Million.Domain.Entities.PropertyImage;
using Million.Domain.Entities.PropertyTrace;

namespace Million.Application.Configuration
{
    public class MapperProfile : Profile
    {
        /// <summary>
        /// Mapper profile for mapping between models and entities.
        /// </summary>
        public MapperProfile() 
        {
            #region Maps to Address
            CreateMap<AddressEntity, CreateAddressModel>().ReverseMap();
            CreateMap<AddressEntity, GetAddressModel>().ReverseMap();
            CreateMap<AddressEntity, UpdateAddressModel>().ReverseMap();
            CreateMap<AddressEntity, DeleteAddressModel>().ReverseMap();
            #endregion
            #region Maps to Owners
            CreateMap<OwnerEntity, CreateOwnerModel>().ReverseMap();
            CreateMap<OwnerEntity, GetOwnerModel>().ReverseMap();
            CreateMap<OwnerEntity, UpdateOwnerModel>().ReverseMap();
            CreateMap<OwnerEntity, DeleteOwnerModel>().ReverseMap();
            #endregion
            #region Maps to Properties
            CreateMap<PropertyEntity, GetPropertyModel>().ReverseMap();
            CreateMap<PropertyEntity, CreatePropertyModel>().ReverseMap();
            CreateMap<PropertyEntity, UpdatePropertyModel>().ReverseMap();
            CreateMap<PropertyEntity, DeletePropertyModel>().ReverseMap();
            #endregion
            #region Maps to Properties Image
            CreateMap<PropertyImageEntity, GetPropertyImageModel>().ReverseMap();
            CreateMap<PropertyImageEntity, CreatePropertyImageModel>().ReverseMap();
            CreateMap<PropertyImageEntity, UpdatePropertyImageModel>().ReverseMap();
            CreateMap<PropertyImageEntity, DeletePropertyImageModel>().ReverseMap();
            #endregion
            #region Maps to Property Traces
            CreateMap<PropertyTraceEntity, GetPropertyTraceModel>().ReverseMap();
            CreateMap<PropertyTraceEntity, CreatePropertyTraceModel>().ReverseMap();
            CreateMap<PropertyTraceEntity, UpdatePropertyTraceModel>().ReverseMap();
            CreateMap<PropertyTraceEntity, DeleteAddressModel>().ReverseMap();
            #endregion
            #region Maps to Owners Contact
            CreateMap<OwnerContactEntity, CreateOwnerContactModel>().ReverseMap();
            CreateMap<OwnerContactEntity, UpdateOwnerContactModel>().ReverseMap();

            #endregion
        }
    }
}
