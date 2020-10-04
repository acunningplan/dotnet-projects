using AutoMapper;
using TravelBug.Dtos;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.CrudServices
{
  public class MappingProfile : Profile
  {

    public MappingProfile()
    {
      CreateMap<AppUser, User>();
      CreateMap<Blog, BlogDto>();
      CreateMap<Image, ImageDto>();
      CreateMap<UserFollowing, FollowingDto>();
      // CreateMap<List<AppUser>, List<User>>();
    }
  }
}
