import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { validateConfig } from '@angular/router/src/config';
import { Observable, throwError } from 'rxjs'
import { map, catchError, finalize } from 'rxjs/operators';

import { LoginService } from '../../service/login.service';
import { LoginModel } from '../../model/login.model';
import { Subject } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { BaseComponent } from '../../base.component';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { ErrorCodeEnum } from '../../enum/error-code.enum';
import { ErrorEnvelope } from '../../envelope/error.envelope';
import { AuthService } from '../../service/auth.service';
import { AuthenticatedModel } from '../../model/authenticated.model';
import { Router } from '@angular/router';
import { DataTransferService } from '../../service/data-transfer.service';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  providers: [LoginService]
})
export class LoginComponent extends BaseComponent implements OnInit {

  public model: LoginModel =  LoginModel._new();

  constructor(
    private loginService: LoginService,
    private authService: AuthService,
    public dataTransferService: DataTransferService,
    public router: Router,
    public title: Title
  ) {
    super(dataTransferService, router, title);
  }

  ngOnInit() {
  };

  public errorCode: ErrorCodeEnum = ErrorCodeEnum.none;

  public isStatusInvalid(): boolean {
    return this.errorCode == ErrorCodeEnum.invalid
  }

  public isStatusInactive(): boolean {
    return this.errorCode == ErrorCodeEnum.inactive
  }

  public summaryError(): void {

    this.initSummary();

    if (this.isStatusInvalid()) {
      this.addSummaryItem('Seus dados de acesso não estão corretos :(');
    }
    if (this.isStatusInactive()) {
      this.addSummaryItem('Estamos aguardando você confirmar seu cadastro.');
    }
  }

  public login(): void {

    this.processRunningStart();

    this.loginService.login(this.model)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<AuthenticatedModel> = response.error as ResponseEnvelope<AuthenticatedModel>;
          this.errorCode = e.error.code;
          this.summaryError();
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
        }))
      .subscribe((response) => {
        this.authService.login(response.dto)
          .subscribe(s =>
          {
            let urlNextLogin = s ? s : '/conta/meus-anuncios';
            this.redirect(urlNextLogin)
          });
      });
  }


}
