import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';

import { map, first } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';
import { ResponseEnvelope } from '../envelope/response.envelope';
import { PropertyStringModel } from '../shared/propertystring.model';
import { RedefinePasswordSolicitationModel } from '../model/redefine-password-solicitation.model';
import { RedefinePasswordChangeModel } from '../model/redefine-password-change.model';
import { AuthenticatedModel } from '../model/authenticated.model';

@Injectable({
  providedIn: 'root'
})
export class RedefinePasswordService {

  constructor(private http: HttpService) { }

  public solicitation(model: RedefinePasswordSolicitationModel): Observable<HttpResponse<ResponseEnvelope<RedefinePasswordSolicitationModel>>> {
    return this.http.post<RedefinePasswordSolicitationModel>('redefinepassword', model);
  }

  public change(model: RedefinePasswordChangeModel): Observable<HttpResponse<ResponseEnvelope<RedefinePasswordChangeModel>>> {
    return this.http.put<RedefinePasswordChangeModel>('redefinepassword', model);
  }

  public get(id: string): Observable<HttpResponse<ResponseEnvelope<AuthenticatedModel>>> {
    return this.http.get<AuthenticatedModel>('redefinepassword?key=' + id);
  }


}
