import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

class Menu {}

@Component({
  selector: "app-left-sidebar",
  templateUrl: "./left-sidebar.component.html",
  styleUrls: ["./left-sidebar.component.css"],
})
export class LeftSidebarComponent implements OnInit {
  menu: object;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.menu = this.http
      .get(`${environment.serverUrl}/menu`)
      .subscribe((res) => {
        this.menu = res;
        console.log(res);
      });
  }
  preserveOrder = (a: object, b: object): object => a;

  // menu = {
  //   Burgers: {
  //     Beef: {
  //       "Classic Burgler": { description: "", calories: 0, price: 1 },
  //     },
  //   },
  //   Sides: {
  //     Chips: {
  //       "Hot chips": { description: "", calories: 0, price: 1 },
  //     },
  //   },
  //   Drinks: {
  //     "Fizzy drinks": {
  //       Coke: { description: "", calories: 0, price: 1 },
  //     },
  //     "Tea and Coffee": {
  //       "Lemon tea": { description: "", calories: 0, price: 1 },
  //     },
  //     Others: {
  //       Chocolate: { description: "", calories: 0, price: 1 },
  //     },
  //   },
  // };

  burgers = [
    "Classic Burgler",
    "Bacon Burgler",
    "Mushroom Swiss",
    "Veggie Burgler",
  ];

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
