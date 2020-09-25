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

  constructor(private router: Router) {
    // router.events
    //   .pipe(
    //     filter((evt: any) => evt instanceof RoutesRecognized),
    //     pairwise()
    //   )
    //   .subscribe((events: RoutesRecognized[]) => {
    //     console.log("previous url", events);
    //     console.log("current url", events);
    //   });
    // router.events
    //   .pipe(filter((event) => event instanceof RoutesRecognized))
    //   .subscribe((val) => {
    //     // see also
    //     console.log("Subscribing to router events:");
    //     console.log(val);
    //     // console.log(val instanceof RoutesRecognized);
    //   });
  }

  ngOnInit() {
    if (!this.prevUrl) {
    }
  }

  ngOnDestroy() {
    // this.routerSub.unsubscribe();
  }
}
