import { HttpService } from "./http.service";
import { ContactModel } from "../model/contact.model";
import { ResponseEnvelope } from "../envelope/response.envelope";
import { Observable } from "rxjs";
import { HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(public http: HttpService) { }

  public send(contactModel: ContactModel): Observable<HttpResponse<ResponseEnvelope<ContactModel>>> {
    return this.http.post<ContactModel>('contact', contactModel);
  }



}
