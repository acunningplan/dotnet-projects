using AutoMapper;
using TravelBug.Dtos;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.CrudServices.Comments
{
  public class MappingProfile : Profile
  {

    public MappingProfile()
    {
      CreateMap<Comment, CommentDto>()
        .ForMember(c => c.BlogId, cfg => cfg.MapFrom(c => c.Blog.Id));
      CreateMap<AppUser, User>();
    }
  }
}
