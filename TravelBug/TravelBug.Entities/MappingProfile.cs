using AutoMapper;

namespace TravelBug.Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogDto>();
        }
    }
}
