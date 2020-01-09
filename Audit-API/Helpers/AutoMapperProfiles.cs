using Audit_API.DTOs;
using Audit_API.Models;
using AutoMapper;

namespace Audit_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserForDetailDto, User>();
            CreateMap<User, UserForDetailDto>();
            CreateMap<KindDto, Kind>();
            CreateMap<Kind, KindDto>();
            CreateMap<KindForUpdateDto, Kind>();
            CreateMap<Kind, KindForUpdateDto>();
            CreateMap<Category, CategoriesForListDto>()
                .ForMember(dest => dest.KindName, opt =>
                {
                    opt.MapFrom(src => src.Kind.name);
                });
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}