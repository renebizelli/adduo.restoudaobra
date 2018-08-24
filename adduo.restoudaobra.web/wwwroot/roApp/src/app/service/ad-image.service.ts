import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';
import { LoginModel } from '../model/login.model';

import { map } from 'rxjs/operators';
import { HttpResponse, HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { ResponseEnvelope } from '../envelope/response.envelope';
import { PropertyStringModel } from '../shared/propertystring.model';
import { CardRegisterModel } from '../model/card-register.model';
import { AdRegisterInitialModel } from '../model/ad-register-initial.model';
import { HttpRequest } from 'selenium-webdriver/http';
import { Configs } from '../app.configs';
import { UploadService } from './upload.service';

@Injectable({
  providedIn: 'root'
})
export class AdImageService {


  constructor(
    private httpclient: HttpClient,
    private http: HttpService,
    private uploadService: UploadService) { }

  public delete(id: number): Observable<HttpResponse<any>> {
    return this.http.delete('adimage/' + id);
  }

  public upload(data: FormData): Observable<any> {
    return this.uploadService.upload('adimage', data);
  }
}
