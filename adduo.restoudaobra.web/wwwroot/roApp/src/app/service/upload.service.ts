import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';
import { LoginModel } from '../model/login.model';

import { map } from 'rxjs/operators';
import { HttpRequest, HttpClient } from '@angular/common/http';
import { Configs } from '../app.configs';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  constructor(
    private httpClient: HttpClient,
    private configs: Configs) { }

  public upload(url:string, data: FormData): Observable<any> {

    var httpRequest = new HttpRequest('POST', this.configs.host + url, data, { reportProgress: true });

    return this.httpClient.request(httpRequest);
  }
}
