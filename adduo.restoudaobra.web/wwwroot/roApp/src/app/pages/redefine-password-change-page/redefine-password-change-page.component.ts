import { Component, OnInit } from '@angular/core';
import { RedefinePasswordChangeModel } from '../../model/redefine-password-change.model';
import { PropertyStringModel } from '../../shared/propertystring.model';
import { RedefinePasswordService } from '../../service/redefine-password.service';
import { BaseComponent } from '../../base.component';
import { map, catchError, finalize } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { throwError } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { ViewHelper } from '../../shared/view.helper';
import { AuthService } from '../../service/auth.service';
import { DataTransferService } from '../../service/data-transfer.service';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-redefine-password-change-page',
  templateUrl: './redefine-password-change-page.component.html',
  providers: [ViewHelper]
})
export class RedefinePasswordChangePageComponent extends BaseComponent implements OnInit {

  public model: RedefinePasswordChangeModel = new RedefinePasswordChangeModel(
    new PropertyStringModel(),
    new PropertyStringModel()
  )

  constructor(
    private redefinePasswordService: RedefinePasswordService,
    private activatedRoute: ActivatedRoute,
    private viewHelper: ViewHelper,
    private authService: AuthService,
    public dataTransferService: DataTransferService,
    public router: Router,
    public title: Title
  ) {
    super(dataTransferService, router, title);
  }

  ngOnInit() {
  this.setTitle('Redefinir senha')
    this.getRedefine();
  }

  private getRedefine(): void {

    this.processRunningStart();

    this.redefinePasswordService.get(this.activatedRoute.snapshot.params.key)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {

          let e: ResponseEnvelope<RedefinePasswordChangeModel> = response.error as ResponseEnvelope<RedefinePasswordChangeModel>;
          //this.processHttpErrorResponse(response)
          return throwError(response);
        }),
        finalize(() => {
          this.isAlready = true;
          this.processRunningStop();
        }))
      .subscribe((response) => {
        console.log(response)
        this.authService.login(response.dto);
      });
  }

  public change(): void {

    this.processRunningStart();

    this.redefinePasswordService.change(this.model)
      .pipe(
        map((m) => m.body),
        catchError((error: HttpErrorResponse) => {
          let e: ResponseEnvelope<RedefinePasswordChangeModel> = error.error as ResponseEnvelope<RedefinePasswordChangeModel>;
         // this.processHttpErrorResponse(error)
          this.model = e.dto;
          return throwError(error);
        }),
        finalize(() => {
          this.processRunningStop();
        }))
      .subscribe((response) => {
        this.model = response.dto;
        this.redirect('/conta/redefinir-senha/sucesso');
      });

  }


}
