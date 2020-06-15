import { Component, OnInit, Input } from '@angular/core';
import { FoodItem } from '../../order';

@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.css']
})
export class OrderItemComponent implements OnInit {
  @Input() foodItem: FoodItem;

  constructor() { }

  ngOnInit(): void {
  }

}
