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
export class AdService {

    
  constructor(
    private http: HttpService,
    private uploadService:UploadService) { }

  public register(model: CardRegisterModel): Observable<HttpResponse<ResponseEnvelope<CardRegisterModel>>> {
    return this.http.post<CardRegisterModel>('ad', model);
  }

  public update(model: CardRegisterModel): Observable<HttpResponse<ResponseEnvelope<CardRegisterModel>>> {
    return this.http.put<CardRegisterModel>('ad', model);
  }

  public initial(): Observable<HttpResponse<ResponseEnvelope<AdRegisterInitialModel>>> {
    return this.http.get<AdRegisterInitialModel>('initialad');
  }
  
  public get(guid: string): Observable<HttpResponse<ResponseEnvelope<CardRegisterModel>>> {
    return this.http.get<CardRegisterModel>('ad/' + guid);
  }

}
