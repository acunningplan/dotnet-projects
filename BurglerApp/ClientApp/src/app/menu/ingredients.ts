export class Ingredients {
  buns: Bun[] = [];
  patties: Patty[] = [];
  pattySizes: string[];
  toppings: Topping[] = [];
}

export class Ingredient {
  name: string;
  calories: number;
  price: number;
  description: string;
}

export class Food {
  name: string;
  description: string;
  imageUrl: string;
  options: { size: string; calories: number; price: number }[] = [];
}

class Bun extends Ingredient {}
class Topping extends Ingredient {}
class Patty extends Ingredient {
  size: string;
}
