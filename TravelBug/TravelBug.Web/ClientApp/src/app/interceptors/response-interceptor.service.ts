import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpResponse,
  HttpErrorResponse,
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { LoadingService } from "../services/loading.service";

@Injectable()
export class ResponseInterceptorService implements HttpInterceptor {
  constructor(
    private router: Router,
    private loadingService: LoadingService
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          // event = event.clone({ body: this.modifyBody(event.body) });
          // this.router.navigate(["/account"]);
        }
        return event;
      }),

      catchError((err: HttpErrorResponse) => {
        this.loadingService.loading.next(false);
        switch (err.status) {
          case 401:
            this.router.navigate(["/account"]);
            break;
          default:
            return throwError(err);
        }
        // if (err.status === 401) {
        //   // redirect to the login route
        //   // or show a modal
        //   // console.log("Redirected.");
        //   this.router.navigate(["/account"]);
        // }
        // return throwError(err);
      })
    );
  }
}
