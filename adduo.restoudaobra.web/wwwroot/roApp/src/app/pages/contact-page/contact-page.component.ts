import { Component, OnInit } from '@angular/core';
import { ContactModel } from '../../model/contact.model';
import { BaseComponent } from '../../base.component';
import { DataTransferService } from '../../service/data-transfer.service';
import { Router } from '@angular/router';
import { ContactService } from '../../service/contact.service';
import { map, catchError, finalize } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { throwError } from 'rxjs';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-contact-page',
  templateUrl: './contact-page.component.html',
  providers : [ ContactService ]
})
export class ContactPageComponent
  extends BaseComponent
  implements OnInit {

  public model: ContactModel = ContactModel._new();

  constructor(
    public contactService: ContactService, 
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title: Title) {
    super(dataTransferService, router, title);
  }


  ngOnInit() {
    this.setTitle('Contato')
  }

  public contact(): void {

    this.processRunningStart();

    this.contactService.send(this.model)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<ContactModel> = response.error as ResponseEnvelope<ContactModel>;
          this.model = e.dto;
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
        }))
      .subscribe((response) => {
        this.redirect('contato/enviado');
      });

  }


}
