using AutoMapper;
using TravelBug.Entities;
using TravelBug.Entities.UserData;
using TravelBug.Infrastructure;

namespace TravelBug.CrudServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<Blog, BlogDto>();
            CreateMap<Image, ImageDto>();
        }
    }
}
