using AutoMapper;
using TravelBug.Dtos;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<AppUser, User>();
            CreateMap<Blog, BlogDto>();
            CreateMap<Image, ImageDto>();
        }
    }
}
