import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";

export class AuthInterceptorService implements HttpInterceptor {
  constructor() {}
 intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = sessionStorage.getItem('token');

   if (token) {
     request = request.clone({
        setHeaders: {Authorization: `Bearer ${token}`}
     });
  }
  return next.handle(request);
  }
}
