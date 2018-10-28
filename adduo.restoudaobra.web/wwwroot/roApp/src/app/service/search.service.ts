import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';

import { map, catchError, finalize } from 'rxjs/operators';
import { throwError } from 'rxjs';

import { HttpResponse, HttpClient } from '@angular/common/http';
import { ResponseEnvelope } from '../envelope/response.envelope';
import { HttpRequest } from 'selenium-webdriver/http';
import { Configs } from '../app.configs';
import { CardDetailModel } from '../model/card-detail.model';
import { AdCacheService } from './ad-cache.service';
import { reject } from '../../../node_modules/@types/q';

@Injectable()
export class SearchService {

    
  constructor(
    private http: HttpService, 
    public adCacheService : AdCacheService) { }

  public list(guid: string): Observable<CardDetailModel[]> {
  
    return new Observable<CardDetailModel[]>((o) => {
    
      if(this.adCacheService.hasCards())
      {
          o.next(this.adCacheService.get())
      }
      else 
      {
     
       this.http.get<CardDetailModel>('search/list')
          .pipe(
            map((m) => m.body),
            catchError((e) => {
              o.next([]);
              o.complete();
              return Observable.create();
            }))
          .subscribe((response: ResponseEnvelope<CardDetailModel>) => {
          
            this.adCacheService.set(response.dtos)
            
            o.next(response.dtos);
          });    
          
      }
    
    })
    
    
    
  }
  
    public get(guid: string): Observable<HttpResponse<ResponseEnvelope<CardDetailModel>>> {
    return this.http.get<CardDetailModel>('search/' + guid);
  }

  
}
