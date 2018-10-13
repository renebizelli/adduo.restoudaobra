import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';

import { map } from 'rxjs/operators';
import { HttpResponse, HttpClient } from '@angular/common/http';
import { ResponseEnvelope } from '../envelope/response.envelope';
import { HttpRequest } from 'selenium-webdriver/http';
import { Configs } from '../app.configs';
import { CardDetailModel } from '../model/card-detail.model';

@Injectable()
export class SearchService {

    
  constructor(
    private http: HttpService) { }

  public list(guid: string): Observable<HttpResponse<ResponseEnvelope<CardDetailModel>>> {
    return this.http.get<CardDetailModel>('search/list');
  }
  
    public get(guid: string): Observable<HttpResponse<ResponseEnvelope<CardDetailModel>>> {
    return this.http.get<CardDetailModel>('search/' + guid);
  }

  
}
