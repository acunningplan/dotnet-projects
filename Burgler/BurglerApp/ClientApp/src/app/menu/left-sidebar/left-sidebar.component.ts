import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-left-sidebar",
  templateUrl: "./left-sidebar.component.html",
  styleUrls: ["./left-sidebar.component.css"],
})
export class LeftSidebarComponent implements OnInit {
  sortJson = (a: object, b: object): object => a;

  menu = {
    Burgers: {
      Beef: {
        "Classic Burgler": { description: "", calories: 0, price: 1 },
      },
    },
    Sides: {
      Chips: {
        "Hot chips": { description: "", calories: 0, price: 1 },
      },
    },
    Drinks: {
      "Fizzy drinks": {
        Coke: { description: "", calories: 0, price: 1 },
      },
      "Tea and Coffee": {
        "Lemon tea": { description: "", calories: 0, price: 1 },
      },
      Others: {
        Chocolate: { description: "", calories: 0, price: 1 },
      },
    },
  };

  burgers = [
    "Classic Burgler",
    "Bacon Burgler",
    "Mushroom Swiss",
    "Veggie Burgler",
  ];
  constructor() {}

  ngOnInit() {}

  onClickSubcategory(subcategory: MenuItem[]) {}
}

interface MenuItem {
  description: string;
  calories: number;
  price: number;
  image: string;
}

// menu = {
//   Burgers: {
//     "Classic Burgler": {
//       base_price: 4.99,
//       calories: 400,
//     },
//     "Bacon Burgler": {
//       base_price: 5.49,
//       calories: 400,
//     },
//     "Mushroom Swiss": {
//       base_price: 5.49,
//       calories: 400,
//     },
//     "Tofu Burgler": {
//       base_price: 3.99,
//       calories: 150,
//     },
//   },
//   Sides: {
//     "Regular Chips": {
//       base_price: 4.99,
//       calories: 300,
//     },
//     "Potato Wedges": {
//       base_price: 4.99,
//       calories: 300,
//     },
//     "Onion Rings": {
//       base_price: 4.99,
//       calories: 300,
//     },
//     "Brussel Sprouts": {
//       base_price: 4.99,
//       calories: 180,
//     },
//   },
// };
