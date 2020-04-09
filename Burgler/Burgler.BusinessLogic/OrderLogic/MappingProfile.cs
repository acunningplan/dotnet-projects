using AutoMapper;
using Burgler.Entities.OrderNS;
using Burgler.Entities.User;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<AppUser, UserDto>();
        }
    }
}
