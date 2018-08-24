import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';
import { LoginModel } from '../model/login.model';

import { map, catchError, take } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { ResponseEnvelope } from '../envelope/response.envelope';
import { AuthenticatedModel } from '../model/authenticated.model';
import { PropertyStringModel } from '../shared/propertystring.model';
import { resolve } from 'q';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpService) { }

  public auth(): Observable<boolean> {

    return new Observable<boolean>((o) => {

      this.http.get<boolean>("auth")
        .pipe(
          catchError((e) => {
            o.next(false);
            o.complete();
            return Observable.create();
          })
        )
        .subscribe((s) => {
          o.next(true)
          o.complete();
        })
    });
  }


  public login(f: FormGroup): Observable<HttpResponse<ResponseEnvelope<AuthenticatedModel>>> {
    var model = this.parser(f)
    return this.http.post<AuthenticatedModel>('login', model);
  }

  public parser(f: FormGroup): LoginModel {

    let email = new PropertyStringModel();
    email.value = f.get('email').value;

    let password = new PropertyStringModel();
    password.value = f.get('password').value;

    var model = new LoginModel(email, password);

    return model;
  }
}
