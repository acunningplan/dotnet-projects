import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import {
  Event,
  NavigationEnd,
  NavigationStart,
  Router,
  RoutesRecognized,
} from "@angular/router";
import { Subscription } from "rxjs";
import { filter, pairwise } from "rxjs/operators";
import { Blog } from "src/app/models/blog";
import { RouterTrackingService } from "src/app/services/router-tracking.service";

@Component({
  selector: "app-blog-detail",
  templateUrl: "./blog-detail.component.html",
  styleUrls: ["./blog-detail.component.css"],
})
export class BlogDetailComponent implements OnInit, OnDestroy {
  @Input() blog: Blog;
  private routerSub: Subscription;
  private prevUrl: string;
  private newUrl: string;

  constructor() {

  }

  ngOnInit() {
  }

  ngOnDestroy() {
    // this.routerSub.unsubscribe();
  }
}
