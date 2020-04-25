export class Menu {
  burgers: { [key: string]: Burger[] } = {};
  sides: { [key: string]: Side[] } = {};
  drinks: { [key: string]: Drink[] } = {};
}

class MenuItem {
  name: string;
  calories: number;
  price: number;
  description: string;
}

class Burger extends MenuItem {
  [key: string]: any;
}

class Side extends MenuItem {
  [key: string]: any;
}

class Drink extends MenuItem {
  [key: string]: any;
}
