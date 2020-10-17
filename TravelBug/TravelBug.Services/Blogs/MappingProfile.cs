using System.Linq;
using AutoMapper;
using TravelBug.Dtos;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.CrudServices.Blogs
{
  public class MappingProfile : Profile
  {

    public MappingProfile()
    {
      CreateMap<AppUser, User>();
      CreateMap<Blog, BlogDto>()
        .ForMember(b => b.Comments, cfg => cfg.MapFrom(b => b.Comments.Where(c => c.Deleted == null)));
      CreateMap<Image, ImageDto>();
      CreateMap<Comment, CommentDto>()
        .ForMember(c => c.BlogId, cfg => cfg.MapFrom(c => c.Blog.Id));
      CreateMap<UserFollowing, FollowingDto>();
      // CreateMap<List<AppUser>, List<User>>();
    }
  }
}
