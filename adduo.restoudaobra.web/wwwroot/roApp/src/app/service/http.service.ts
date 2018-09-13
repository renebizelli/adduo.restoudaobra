import { Injectable, Directive } from '@angular/core';
import { Response } from '@angular/http'
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { retry } from 'rxjs/operators';

import { Configs } from '../app.configs'
import { RequestEnvelope } from '../envelope/request.envelope';
import { ResponseEnvelope } from '../envelope/response.envelope';
import { AuthService } from './auth.service';


@Injectable()
@Directive({selector:"[app-http-service]"})
export class HttpService {

  constructor(
    private httpclient: HttpClient,
    private configs: Configs,
    private authService:AuthService ) { }

  public post<T>(url: string, o: any): Observable<HttpResponse<ResponseEnvelope<T>>> {
    let request = this.createRequest(o);
    return this.httpclient.post<ResponseEnvelope<T>>(this.configs.host + url, request, { observe: 'response' });
  }

  public put<T>(url: string, o: any): Observable<HttpResponse<ResponseEnvelope<T>>> {
    let request = this.createRequest(o);
    return this.httpclient.put<ResponseEnvelope<T>>(this.configs.host + url, request, { observe: 'response' });
  }

  public get<T>(url: string): Observable<HttpResponse<ResponseEnvelope<T>>> {
    return this.httpclient.get<ResponseEnvelope<T>>(this.configs.host + url, { observe: 'response' });
  }

  public delete(url: string): Observable<HttpResponse<any>> {
    return this.httpclient.delete<any>(this.configs.host + url, { observe: 'response' });
  }


  private createRequest(o: any): RequestEnvelope {

    let request = new RequestEnvelope();

    request.dto = o;

    return request;
  }
}
