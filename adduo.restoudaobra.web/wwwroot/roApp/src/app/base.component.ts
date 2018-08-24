import { Component, Directive } from "@angular/core";
import { ErrorCodeEnum } from "./enum/error-code.enum";
import { HttpErrorResponse } from "@angular/common/http";
import { HttpStatusEnum } from "./enum/http-status.enum";
import { Router } from "@angular/router";
import { DataTransferService } from "./service/data-transfer.service";
import { SummaryItemModel } from "./model/summary-item.model";

@Directive({ selector: 'app-base-component' })
export class BaseComponent {

  public isProcessRunning: boolean = false;
  public isAlready: boolean = false;
  public summaryItens: SummaryItemModel[] = [];

  constructor(
    public dataTransferService: DataTransferService,
    public router: Router) { }

  public processRunningStart(): void {
    this.isProcessRunning = true;
  }

  public processRunningStop(): void {
    this.isProcessRunning = false;
  }

  public redirect(url: string): void {
    this.router.navigate([url]);
  }

  public redirectAndTransferData(url: string, data: any): void {
    this.dataTransferService.set('data', data);
    this.redirect(url);
  }

  public redirectWithQuerystring(url: string, params: string[]): void {
    params.unshift(url);
    this.router.navigate(params);
  }

  public initSummary(): void {
    this.summaryItens = [];
  }

  public addSummaryItem(text: string): void {
    this.summaryItens.push(new SummaryItemModel(text));
  }

  public processHttpErrorResponse(error: HttpErrorResponse): void {

    if (error.status == HttpStatusEnum.notfound) {
      this.redirect('/');
    }
    else if (error.status == HttpStatusEnum.unauthorized) {
      this.redirect('/conta');
    }

  }
}

