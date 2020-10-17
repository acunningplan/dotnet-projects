using System.Collections.Generic;
using AutoMapper;
using TravelBug.Dtos;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<AppUser, User>();
      // CreateMap<Blog, BlogDto>();
      CreateMap<UserFollowing, FollowingDto>()
        .ForMember(u => u.FollowedUser, c => c.MapFrom(f => f.Target.UserName))
        .ForMember(u => u.FollowingUser, c => c.MapFrom(f => f.Observer.UserName));
      CreateMap<UserPhoto, UserPhotoDto>()
        .ForMember(p => p.Username, c => c.MapFrom(u => u.User.UserName));

      // CreateMap<List<AppUser>, List<User>>();
    }
  }
}
