import { Component, OnInit, Directive } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PropertyStringModel } from '../../shared/propertystring.model';
import { AdRegisterModel } from '../../model/ad-register.model';
import { PropertyNumberModel } from '../../shared/propertynumber.model';
import { CardRegisterModel } from '../../model/card-register.model';
import { AdService } from '../../service/ad.service';
import { finalize, catchError, map } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { throwError } from 'rxjs';
import { AdRegisterInitialModel } from '../../model/ad-register-initial.model';
import { AuthService } from '../../service/auth.service';
import { AdTypeEnum } from '../../enum/ad-type.enum';
import { DataTransferService } from '../../service/data-transfer.service';
import { AdComponent } from './ad.component';
import { ActionTypeEnum } from '../../enum/action-type.enum';
import { ViewHelper } from '../../shared/view.helper';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Directive({
  selector: 'app-ad-register',
  providers: [AdService]
})
export class AdRegisterComponent extends AdComponent implements OnInit {

  constructor(
    public viewHelper: ViewHelper,
    public authService: AuthService,
    public adService: AdService,
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title: Title) {
    super(viewHelper, authService, adService, dataTransferService, router, title);
  }

  ngOnInit() {
    super.ngOnInit();
  } 

  protected setActionType() {
    this.actionType = ActionTypeEnum.new;
  }
  
  public setTitle(text:string) : void {
    super.setTitle(text)
  }

  public init(): void {

    this.processRunningStart();

    this.adService.initial()
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          return throwError(response);
        }),
        finalize(() => {
          this.isAlready = true;
          this.processRunningStop();
        }))
      .subscribe((response) => {

          this.initial = JSON.parse(JSON.stringify(response.dto));
      });

  }

  public save(): void {

    this.processRunningStart();

    this.model.ad.guid = this.initial.guid;
    this.model.ad.type = this.type;
    this.model.initial.addresses = [];

    this.adService.register(this.model)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<CardRegisterModel> = response.error as ResponseEnvelope<CardRegisterModel>;

          this.model = e.dto;

          return throwError(response);
        }),
        finalize(() => {
          this.isAlready = true;
          this.processRunningStop();
          this.scrollToTop()
        }))
      .subscribe((response) => {
        this.nextStep();
      });

  }

}
