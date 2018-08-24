import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';
import { LoginModel } from '../model/login.model';

import { map, first } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { ResponseEnvelope } from '../envelope/response.envelope';
import { AuthenticatedModel } from '../model/authenticated.model';
import { OwnerModel } from '../model/owner.model';
import { PropertyStringModel } from '../shared/propertystring.model';
import { ConfirmationModel } from '../model/confirmation.model';

@Injectable({
  providedIn: 'root'
})
export class OwnerService {

  constructor(private http: HttpService) { }

  public register(ownerModel: OwnerModel): Observable<HttpResponse<ResponseEnvelope<OwnerModel>>> {
    return this.http.post<OwnerModel>('owner', ownerModel);
  }

  public update(ownerModel: OwnerModel): Observable<HttpResponse<ResponseEnvelope<OwnerModel>>> {
    return this.http.put<OwnerModel>('owner', ownerModel);
  }

  public get(): Observable<HttpResponse<ResponseEnvelope<OwnerModel>>> {
    return this.http.get<OwnerModel>('owner');
  }

  public confirmation(id: string): Observable<HttpResponse<ResponseEnvelope<AuthenticatedModel>>> {
    return this.http.post<AuthenticatedModel>('owner/confirmation', new ConfirmationModel(id));
  }
}
