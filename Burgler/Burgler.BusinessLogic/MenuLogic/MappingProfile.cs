
using AutoMapper;
using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;


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
