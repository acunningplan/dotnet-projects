import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Order } from '../order';

@Injectable({
  providedIn: 'root'
})
export class OrderConfirmationService {
  orderConfirmationSubject = new Subject<{
    order: Order,
    mode: string
  }>();
}
