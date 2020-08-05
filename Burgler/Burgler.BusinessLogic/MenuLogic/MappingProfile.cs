
using AutoMapper;
using Burgler.Entities.FoodItem;
using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using Burgler.Entities.OrderNS;
using Burgler.Entities.User;
using System.Collections.Generic;

namespace Burgler.BusinessLogic.MenuLogic
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Burger, BurgerDto>();
            CreateMap<Bun, BunDto>();
            CreateMap<Topping, ToppingDto>();
            CreateMap<Patty, PattyDto>();
            CreateMap<Side, SideDto>();
            CreateMap<Drink, DrinkDto>();
        }
    }
}
