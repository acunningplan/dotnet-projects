import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
} from "@angular/common/http";

export class AuthInterceptorService implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    let token = localStorage.getItem("travelBug:Token");
    let modifiedReq = req.clone({
      headers: req.headers.append("Authorization", `Bearer ${token}`),
    });
    return next.handle(modifiedReq);
  }
}
