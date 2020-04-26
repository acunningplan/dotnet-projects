export class Ingredients {
  buns: Bun[] = [];
  patties: Patty[] = [];
  toppings: Topping[] = [];
}

export class Ingredient {
  name: string;
  calories: number;
  price: number;
  description: string;
}

class Bun extends Ingredient {}
class Topping extends Ingredient {}
class Patty extends Ingredient {
  size: string;
}
