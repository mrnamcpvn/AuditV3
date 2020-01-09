using Audit_API.DTOs;
using Audit_API.Models;
using AutoMapper;

namespace Audit_API.Helpers.AutoMapper
{
    public class DtoToEfMappingProfile : Profile
    {
        public DtoToEfMappingProfile()
        {
            CreateMap<KindDto, Kind>();
            CreateMap<CategoryDto, Category>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserForDetailDto, User>();
        }
    }
}