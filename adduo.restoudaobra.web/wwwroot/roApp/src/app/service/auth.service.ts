import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { SESSION_STORAGE, StorageService } from 'angular-webstorage-service';
import { AuthenticatedModel } from '../model/authenticated.model';
import { HttpService } from './http.service';


@Injectable()
export class AuthService {

  private SESSION_KEY: string = 'RO-AUTH';
  private state: BehaviorSubject<AuthenticatedModel> = new BehaviorSubject(null);

  currentState = this.state.asObservable();

  constructor(
    @Inject(SESSION_STORAGE) private storage: StorageService) {
    let auth = this.get();
    this.state.next(auth);
  }

  public login(auth: AuthenticatedModel): Observable<string> {

    console.log(auth)
    this.storage.set(this.SESSION_KEY, auth);
    this.state.next(auth);

    let urlToNextLogin = this.storage.get('RO-NEXT-LOGIN');
    return new Observable<string>((o) => {
      o.next(urlToNextLogin);
    });
  }

  public get(): AuthenticatedModel {
    return this.storage.get(this.SESSION_KEY);
  }

  public logout(): Observable<any> {

    return new Observable<any>((o) => {
      this.state.next(null);
      this.storage.remove(this.SESSION_KEY);
      o.next(null);
      o.complete();
    });



  }

}
