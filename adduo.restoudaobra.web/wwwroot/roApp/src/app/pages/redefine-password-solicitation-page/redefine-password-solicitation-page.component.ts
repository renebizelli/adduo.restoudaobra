import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { map, catchError, finalize } from 'rxjs/operators';
import { throwError } from 'rxjs';

import { BaseComponent } from '../../base.component';
import { RedefinePasswordSolicitationModel } from '../../model/redefine-password-solicitation.model';
import { RedefinePasswordService } from '../../service/redefine-password.service';
import { PropertyStringModel } from '../../shared/propertystring.model';
import { ViewHelper } from '../../shared/view.helper';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { OwnerModel } from '../../model/owner.model';
import { DataTransferService } from '../../service/data-transfer.service';
import { TypeHelper } from '../../shared/type.helper';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-redefine-password-solicitation-page',
  templateUrl: './redefine-password-solicitation-page.component.html',
  providers: [ViewHelper]
})
export class RedefinePasswordSolicitationPageComponent extends BaseComponent implements OnInit {

  public model: RedefinePasswordSolicitationModel = new RedefinePasswordSolicitationModel(new PropertyStringModel(), TypeHelper.stringEmpty);

  constructor(
    private redefinePasswordService: RedefinePasswordService,
    public dataTransferService: DataTransferService,
    public viewHelper: ViewHelper,
    public router: Router, 
    public title: Title) {
    super(dataTransferService, router, title);
  }


  ngOnInit() {
  this.setTitle('Redefinir senha')
    let value = this.dataTransferService.get('data');
    console.log('solicitation', this.dataTransferService.get("data"));
    if (value) {
      this.model.cpfemail.value = value;
    }
  }

  public redefine(): void {

    this.processRunningStart();

    this.redefinePasswordService.solicitation(this.model)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<RedefinePasswordSolicitationModel> = response.error as ResponseEnvelope<RedefinePasswordSolicitationModel>;
          this.model = e.dto;
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
        }))
      .subscribe((response) => {
        this.model = response.dto;
        this.redirectAndTransferData('/conta/redefinir-senha/solicitada', this.model.ofuscated);
      });
  }
}
