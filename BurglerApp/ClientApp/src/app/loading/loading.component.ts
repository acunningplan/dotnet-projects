import { Component, OnInit, Input, OnDestroy } from "@angular/core";

@Component({
  selector: "app-loading",
  templateUrl: "./loading.component.html",
  styleUrls: ["./loading.component.css"],
})
export class LoadingComponent implements OnInit, OnDestroy {
  @Input() loadingText: string;
  dots = ["", ".", "..", "..."];
  counter = 0;
  interval = 300;
  loadingInterval: NodeJS.Timeout;
  timeout = false;

  ngOnInit() {
    this.loadingInterval = setInterval(() => {
      this.counter++;
      if (this.interval * this.counter > 10000) this.timeout = true;
    }, this.interval);
  }

  ngOnDestroy() {
    clearInterval(this.loadingInterval);
  }
}
