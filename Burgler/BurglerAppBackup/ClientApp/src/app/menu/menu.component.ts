import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.css"]
})
export class MenuComponent implements OnInit {
  burgers = [
    "Classic Burgler",
    "Bacon Burgler",
    "Mushroom Swiss",
    "Veggie Burgler"
  ];

  menu = {
    Burgers: {
      "Classic Burgler": {
        base_price: 4.99,
        calories: 400
      },
      "Bacon Burgler": {
        base_price: 5.49,
        calories: 400
      },
      "Mushroom Swiss": {
        base_price: 5.49,
        calories: 400
      },
      "Veggie Burgler": {
        base_price: 3.99,
        calories: 150
      }
    },
    Sides: {
      "Regular Chips": {
        base_price: 4.99,
        calories: 300
      },
      "Potato Wedges": {
        base_price: 4.99,
        calories: 300
      },
      "Onion Rings": {
        base_price: 4.99,
        calories: 300
      },
      "Brussel Sprouts": {
        base_price: 4.99,
        calories: 180
      }
    }
  };

  constructor() {}

  ngOnInit() {}

  onClick() {}
}
