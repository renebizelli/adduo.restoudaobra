import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';

import { map, first } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';
import { ResponseEnvelope } from '../envelope/response.envelope';
import { AuthenticatedModel } from '../model/authenticated.model';
import { PropertyStringModel } from '../shared/propertystring.model';
import { AddressDetailModel } from '../model/address-detail.model';

@Injectable({
  providedIn: 'root'
})
export class OwnerService {

  constructor(private http: HttpService) { }

  public get(): Observable<HttpResponse<ResponseEnvelope<AddressDetailModel[]>>> {
    return this.http.get<AddressDetailModel[]>('address');
  }
}
