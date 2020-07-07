import { Injectable } from "@angular/core";
import { Order } from "./order";
import { Subject, Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class RequestQueueingService {
  queueingSub = new Subject<any>();
  private queuedOrder: Order = null;
  private requestDone = true;

  constructor(private http: HttpClient) {}

  queueUpdate(pendingOrder: Order) {
    if (this.requestDone) {
      this.requestDone = false;
      this.updateOrder(pendingOrder);
    } else {
      this.queuedOrder = pendingOrder;
    }
    return this.queueingSub;
  }

  updateOrder(pendingOrder: Order) {
    this.http
      .patch(`${environment.serverUrl}/order/edit`, pendingOrder)
      .subscribe(() => {
        const queuedOrder = this.queuedOrder;
        this.queuedOrder = null;
        if (!!queuedOrder) {
          this.updateOrder(queuedOrder);
        } else {
          this.queueingSub.next();
          this.requestDone = true;
        }
      });
  }
}
