using Audit_API.DTOs;
using Audit_API.Models;
using AutoMapper;

namespace Audit_API.Helpers.AutoMapper
{
    public class EfToDtoMappingProfile : Profile
    {
        public EfToDtoMappingProfile()
        {
            CreateMap<Kind, KindDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<User, UserForDetailDto>();
        }
        
    }
}