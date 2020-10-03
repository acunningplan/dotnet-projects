using AutoMapper;
using TravelBug.CrudServices;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, User>();
            CreateMap<Blog, BlogDto>();
        }
    }
}
