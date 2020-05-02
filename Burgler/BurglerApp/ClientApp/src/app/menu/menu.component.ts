import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.css"],
})
export class MenuComponent implements OnInit {
  constructor(private http: HttpClient) {}

  ngOnInit() {}
  onClick() {}
  addToOrder() {
    this.http.post(`${environment.serverUrl}/order`, {});
  }
}
