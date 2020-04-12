using AutoMapper;
using Burgler.Entities.FoodItem;
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
            CreateMap<BurgerItem, BurgerItemDto>();
            CreateMap<BurgerTopping, BurgerToppingDto>();
            CreateMap<SideItem, SideItemDto>();
            CreateMap<DrinkItem, DrinkItemDto>();

            CreateMap<OrderDto, Order>();
            CreateMap<UserDto, AppUser>();
            CreateMap<BurgerItemDto, BurgerItem>();
            CreateMap<BurgerToppingDto, BurgerTopping>();
            CreateMap<SideItemDto, SideItem>();
            CreateMap<DrinkItemDto, DrinkItem>();
        }
    }
}
