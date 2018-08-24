import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError, empty, of } from "rxjs";
import { catchError, tap, audit } from "rxjs/operators";
import { HttpStatusEnum } from "../enum/http-status.enum";
import { AuthService } from "../service/auth.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let auth = this.authService.get();
    if (auth && auth.token && auth.token.hash) {
      request = request.clone({
        setHeaders: { Authorization: `${auth.token.type}  ${auth.token.hash}` }
      });
    }
    return next.handle(request);
  }
}

