import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { HttpResponse } from "@angular/common/http";
import { ResponseEnvelope } from "../envelope/response.envelope";
import { MyAdModel } from "../model/myad.model";
import { Injectable } from "@angular/core";
import { AdChangeStatusModel } from "../model/ad-change-status.model";

@Injectable({
  providedIn: 'root'
})

export class MyAdService {

  constructor(public http: HttpService) { }

  public get(): Observable<HttpResponse<ResponseEnvelope<MyAdModel>>> {
    return this.http.get<MyAdModel>('myad');
  }

  public changeStatus(myad: AdChangeStatusModel): Observable<HttpResponse<ResponseEnvelope<AdChangeStatusModel>>> {
    return this.http.put<AdChangeStatusModel>('ad/status', myad);
  }


}
