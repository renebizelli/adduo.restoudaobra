import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError, finalize, map } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import { OwnerService } from '../../service/owner.service';
import { BaseComponent } from '../../base.component';
import { OwnerModel } from '../../model/owner.model';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { PropertyStringModel } from '../../shared/propertystring.model';
import { ViewHelper } from '../../shared/view.helper';
import { DataTransferService } from '../../service/data-transfer.service';
import { SummaryItemModel } from '../../model/summary-item.model';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-owner-register',
  templateUrl: './owner-register.component.html',
  providers: [OwnerService, ViewHelper]
})
export class OwnerRegisterComponent
  extends BaseComponent
  implements OnInit {


  public model: OwnerModel =  OwnerModel._new()
    
  constructor(
    private ownerService: OwnerService,
    public viewHelper: ViewHelper,
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title: Title) {
    super(dataTransferService, router, title);
  }


  ngOnInit() {
  }

  public isCpfAlready(): boolean {
    return this.viewHelper.isErrorCodeAlready(this.model.cpf) &&
      !this.viewHelper.isErrorCodeAlready(this.model.email);
  }

  public isEmailAlready(): boolean {
    return !this.viewHelper.isErrorCodeAlready(this.model.cpf) &&
      this.viewHelper.isErrorCodeAlready(this.model.email);
  }

  public isAllAlready(): boolean {
    return this.viewHelper.isErrorCodeAlready(this.model.cpf) &&
      this.viewHelper.isErrorCodeAlready(this.model.email);
  }

  public isAnyAlready(): boolean {
    return this.viewHelper.isErrorCodeAlready(this.model.cpf) ||
      this.viewHelper.isErrorCodeAlready(this.model.email);

  }

  public redefineByCPF(): void {
    this.redirectAndTransferData('/conta/redefinir-senha', this.model.cpf.value );
  }

  public redefineByEmail(): void {
    this.redirectAndTransferData('/conta/redefinir-senha', this.model.email.value);
  }

  public summaryError(): void {

    this.initSummary();

    if (this.isCpfAlready()) {
      this.addSummaryItem('Esse CPF já está cadastrado!');
    }
    if (this.isEmailAlready()) {
      this.addSummaryItem('Esse e-mail já está cadastrado!');
    }
    if (this.isAllAlready()) {
      this.addSummaryItem('Esse CPF e e-mail já estão cadastrados!');
    }
  }
  
  public emailAccept() : void {
    this.model.emailAccept = !this.model.emailAccept;
  }

  public register(): void {

    this.processRunningStart();

    this.ownerService.register(this.model)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<OwnerModel> = response.error as ResponseEnvelope<OwnerModel>;
          this.model = e.dto;
          this.summaryError()
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
          this.scrollToTop()
        }))
      .subscribe((response) => {
        this.redirect('/conta/sucesso');
      });

  }

}
