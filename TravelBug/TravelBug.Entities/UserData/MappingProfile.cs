using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TravelBug.Entities.UserData
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>();
        }
    }
}
