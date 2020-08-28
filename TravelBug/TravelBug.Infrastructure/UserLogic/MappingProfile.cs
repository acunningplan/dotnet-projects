using AutoMapper;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, User>();
        }
    }
}
