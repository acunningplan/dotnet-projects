using System.Collections.Generic;
using AutoMapper;
using TravelBug.CrudServices;
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
      CreateMap<Blog, BlogDto>();
      CreateMap<List<AppUser>, List<User>>();
    }
  }
}
