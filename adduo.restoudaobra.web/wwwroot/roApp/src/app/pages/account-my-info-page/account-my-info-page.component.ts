import { Component, OnInit } from '@angular/core';
import { throwError, Observable, timer } from 'rxjs';
import { catchError, finalize, map } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import { OwnerService } from '../../service/owner.service';
import { BaseComponent } from '../../base.component';
import { OwnerModel } from '../../model/owner.model';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { PropertyStringModel } from '../../shared/propertystring.model';
import { ViewHelper } from '../../shared/view.helper';
import { AuthService } from '../../service/auth.service';
import { DataTransferService } from '../../service/data-transfer.service';
import { Title } from '../../../../node_modules/@angular/platform-browser';


@Component({
  selector: 'app-account-my-info-page',
  templateUrl: './account-my-info-page.component.html',
  providers: [OwnerService, ViewHelper]
})
export class AccountMyInfoPageComponent
  extends BaseComponent
  implements OnInit {

  public model: OwnerModel = OwnerModel._new();

   public showSuccessMessage: boolean = false;

  constructor(
    private ownerService: OwnerService,
    private authService: AuthService,
    public viewHelper: ViewHelper,
    public dataTransferService: DataTransferService,
    public router: Router,
    public title: Title) {
    super(dataTransferService, router, title);
  }

  public onChange(o: any) {
    console.log(o) 
  }

  ngOnInit() {
    this.setTitle('Meus dados')
    this.get();
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

  public get(): void {

    this.processRunningStart();

    this.ownerService.get()
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<OwnerModel> = response.error as ResponseEnvelope<OwnerModel>;
          this.model = e.dto;
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
          this.isAlready = true;
        }))
      .subscribe((response) => {
        this.model = response.dto;
      });

  }

  public update(): void {

    this.processRunningStart();

    this.ownerService.update(this.model)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<OwnerModel> = response.error as ResponseEnvelope<OwnerModel>;
          this.model = e.dto;
          console.log(e.dto)
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
        }))
      .subscribe((response) => {



        this.model = response.dto;
        this.showSuccessMessage = true;
        const t = timer(4000).subscribe(() => this.showSuccessMessage = false);
      });

  }

}
