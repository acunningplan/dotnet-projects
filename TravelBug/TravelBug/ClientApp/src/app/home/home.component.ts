import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loggedIn: boolean;

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.loggedIn = !!this.accountService.getProfile();
  }
}
