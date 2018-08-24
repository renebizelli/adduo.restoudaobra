import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { throwError, Observable } from "rxjs";
import { catchError, map, take } from "rxjs/operators";

import { LoginService } from "../service/login.service";
import { Injectable, Inject } from "@angular/core";
import { AuthService } from "../service/auth.service";
import { SESSION_STORAGE, StorageService } from 'angular-webstorage-service';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(
    @Inject(SESSION_STORAGE) private storage: StorageService,
    private authService: AuthService,
    private loginService: LoginService,
    private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {

    return new Observable<boolean>((o) => {
      this.loginService
        .auth()
        .subscribe((s: boolean) => {
          o.next(s)
          if (!s) {
            this.storage.set('RO-NEXT-LOGIN', state.url);
            this.authService.logout().subscribe(() => this.router.navigate(['/conta']));
          }
          o.complete();
        });
    });

  }
}
