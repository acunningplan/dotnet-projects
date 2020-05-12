using AutoMapper;
using Burgler.Entities.FoodItem;
using Burgler.Entities.OrderNS;
using Burgler.Entities.User;
using System;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class MappingProfile : Profile
    {
        private string returnOrderStatus(Order order)
        {
            if (order.CancelledAt != DateTime.MinValue)
                return "cancelled";
            else if (order.FoodTakenAt != DateTime.MinValue)
                return "picked-up";
            else if (order.ReadyAt != DateTime.MinValue)
                return "ready";
            else if (order.OrderedAt != DateTime.MinValue)
                return "placed";
            else if (order.OrderedAt == DateTime.MinValue)
                return "pending";
            return "cancelled";
        }
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => returnOrderStatus(src)));
            CreateMap<AppUser, UserDto>();
            CreateMap<BurgerItem, BurgerItemDto>();
            CreateMap<SideItem, SideItemDto>();
            CreateMap<DrinkItem, DrinkItemDto>();

            CreateMap<OrderDto, Order>();
            CreateMap<UserDto, AppUser>();
            CreateMap<BurgerItemDto, BurgerItem>();
            CreateMap<SideItemDto, SideItem>();
            CreateMap<DrinkItemDto, DrinkItem>();
        }
    }
}
