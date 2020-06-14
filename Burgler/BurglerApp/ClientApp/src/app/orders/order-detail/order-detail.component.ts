import { Component, OnInit, Input } from '@angular/core';
import { Order } from '../order';
import { OrderService } from '../order.service';
import * as moment from 'moment';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements OnInit {
  @Input() order: Order;
  @Input() status: string;

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
  }


  cancelOrder(orderId: string) {
    this.orderService
      .changeOrderStatus(orderId, "cancel")
      .subscribe(() => location.reload());
  }

  placeOrder() {
    this.orderService
      .changeOrderStatus(this.order.orderId, "placeOrder")
      .subscribe(() => location.reload());
  }

  reformatDateTime(dateTime: Date) {
    return moment(dateTime).format("MMMM Do YYYY, h:mmA");
  }
}
