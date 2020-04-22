using AutoMapper;
using Burgler.Entities.FoodItem;
using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using BurglerContextLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.MenuLogic
{
    public class MenuServices : IMenuServices
    {
        private readonly BurglerContext _dbContext;
        private readonly IMapper _mapper;
        public MenuServices(BurglerContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Menu> GetMenu()
        {
            return new Menu()
            {
                BurgersList = _mapper.Map<List<Burger>, List<BurgerDto>>(await _dbContext.Burgers.ToListAsync()),
                BunsList = _mapper.Map<List<Bun>, List<BunDto>>(await _dbContext.Buns.ToListAsync()),
                ToppingsList = _mapper.Map<List<Topping>, List<ToppingDto>>(await _dbContext.Toppings.ToListAsync()),
                PattiesList = _mapper.Map<List<Patty>, List<PattyDto>>(await _dbContext.Patties.ToListAsync()),
                SidesList = _mapper.Map<List<Side>, List<SideDto>>(await _dbContext.Sides.ToListAsync()),
                DrinksList = _mapper.Map<List<Drink>, List<DrinkDto>>(await _dbContext.Drinks.ToListAsync()),
            };
        }
    }
}


