import { Component, OnInit, Directive } from '@angular/core';
import { AuthService } from '../../service/auth.service';
import { AdService } from '../../service/ad.service';
import { DataTransferService } from '../../service/data-transfer.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AdTypeEnum } from '../../enum/ad-type.enum';
import { AdComponent } from '../ad-register-page/ad.component';
import { HttpErrorResponse } from '@angular/common/http';
import { catchError, map, finalize } from 'rxjs/operators';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { throwError } from 'rxjs';
import { CardRegisterModel } from '../../model/card-register.model';
import { ActionTypeEnum } from '../../enum/action-type.enum';
import { ViewHelper } from '../../shared/view.helper';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Directive({
  selector: 'app-ad-update'
})
export class AdUpdateComponent extends AdComponent implements OnInit {

  constructor(
    public viewHelper: ViewHelper,
    public activatedRoute: ActivatedRoute,
    public authService: AuthService,
    public adService: AdService,
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title : Title) {
    super(viewHelper, authService, adService, dataTransferService, router, title); 
  }

  ngOnInit() {
    super.setTitle('Editar anúncio')
    super.ngOnInit();
  }

  protected setActionType() {
    this.actionType = ActionTypeEnum.new;
  }

  public init(): void {

    let id = this.activatedRoute.snapshot.params.id;

    this.processRunningStart();

    this.adService.get(id)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<CardRegisterModel> = response.error as ResponseEnvelope<CardRegisterModel>;
          super.processHttpErrorResponse(response)
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
          this.isAlready = true;
        }))
      .subscribe((response) => {
        this.initial = JSON.parse(JSON.stringify(response.dto.initial));
        this.model = response.dto;
      });
  }

  public save(): void {

    this.processRunningStart();

    this.adService.update(this.model)
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
        }))
      .subscribe((response) => {
        this.nextStep();
      });
  }
}
