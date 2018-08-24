import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { throwError } from 'rxjs';
import { catchError, finalize, map } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

import { OwnerService } from '../../service/owner.service';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { BaseComponent } from '../../base.component';
import { AuthService } from '../../service/auth.service';
import { AuthenticatedModel } from '../../model/authenticated.model';
import { ErrorCodeEnum } from '../../enum/error-code.enum';
import { DataTransferService } from '../../service/data-transfer.service';


@Component({
  selector: 'app-register-confirmation-page',
  templateUrl: './register-confirmation-page.component.html'
})
export class RegisterConfirmationPageComponent extends BaseComponent implements OnInit {

  private id: string = '';
  private status: ErrorCodeEnum = ErrorCodeEnum.none;

  constructor(private activatedRoute: ActivatedRoute,
    private ownerService: OwnerService,
    private authService: AuthService,
    public dataTransferService: DataTransferService,
    public router: Router) {
    super(dataTransferService, router);

    this.id = activatedRoute.snapshot.params.id;

    this.processRunningStart();

    ownerService.confirmation(this.id)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<AuthenticatedModel> = response.error as ResponseEnvelope<AuthenticatedModel>;
          this.status = e.error.code;
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
          this.isAlready = true;
        }))
      .subscribe((response) => {
        this.authService.login(response.dto);

      });
  }

  ngOnInit() {
  }

  public ok(): boolean {
    return this.status == ErrorCodeEnum.none;
  }

  public error(): boolean {
    return this.status == ErrorCodeEnum.erro;
  }

  public already(): boolean {
    return this.status == ErrorCodeEnum.already;
  }

  public empty(): boolean {
    return this.status == ErrorCodeEnum.empty;
  }

}
