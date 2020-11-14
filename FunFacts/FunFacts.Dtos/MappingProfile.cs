using AutoMapper;
using FunFacts.Dtos;
using FunFacts.Entities;
using FunFacts.Entities.UserEntities;

namespace FunFacts.Dtos
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //CreateMap<Topic, TopicDto>()
            //  .ForMember(t => t.Labels, cfg => cfg.MapFrom(t => t.Labels));

            CreateMap<AppUser, User>();
            CreateMap<FunFact, FunFactDto>();
            CreateMap<Label, LabelDto>();
        }
    }
}
