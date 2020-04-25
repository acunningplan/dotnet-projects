export class MenuJson {
  burgersList: Burger[];
  bunsList: Bun[];
  toppingsList: Topping[];
  pattiesList: Patty[];
  sidesList: Side[];
  drinksList: Drink[];
}

class Ingredient {
  name: string;
  calories: number;
  price: number;
  description: string;
}

class Burger extends Ingredient {
  type: string;
  burgerBun: string;
  burgerPatty: string;
  burgerToppings: string;
}

class Bun extends Ingredient {}
class Topping extends Ingredient {}
class Patty extends Ingredient {
  size: string;
}

class Side extends Ingredient {
  type: string;
}

class Drink extends Ingredient {
  type: string;
  volume: string;
}
