import { Injectable, Inject } from '@angular/core';
import { HttpService } from './http.service'
import { Observable } from 'rxjs';
import { SESSION_STORAGE, StorageService } from 'angular-webstorage-service';
import { map, first } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';

import { ResponseEnvelope } from '../envelope/response.envelope';
import { PropertyStringModel } from '../shared/propertystring.model';
import { RedefinePasswordSolicitationModel } from '../model/redefine-password-solicitation.model';

@Injectable({
  providedIn: 'root'
})
export class DataTransferService {

  private SESSION_KEY: string = 'RO-DATA-TRANSFER-';

  constructor(@Inject(SESSION_STORAGE) private storage: StorageService) { }

  public set(key: string, o: any):void  {
    this.storage.set(this.keyFactory(key), o);
  }

  public get(key: string): any {
    return this.storage.get(this.keyFactory(key));
  }

  public keyFactory(key: string): string {
    return this.SESSION_KEY + key.toUpperCase();
  }

}
