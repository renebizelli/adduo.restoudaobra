import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { Router } from '@angular/router';
import { DataTransferService } from '../../service/data-transfer.service';
import { MyAdService } from '../../service/my-ad.service';
import { map, catchError, finalize } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { CardDetailModel } from '../../model/card-detail.model';
import { throwError } from 'rxjs';
import { ItemModel } from '../../model/item.model';
import { MyAdModel } from '../../model/myad.model';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-account-my-ad-page',
  templateUrl: './account-my-ad-page.component.html',
  providers: [MyAdService]
})
export class AccountMyAdPageComponent extends BaseComponent implements OnInit {

  public cards: CardDetailModel[] = [];
  public filteredCards: CardDetailModel[] = [];
  public listStatus: ItemModel[] = [];
  public selectedStatus: ItemModel = ItemModel._new();
  public hasAdsInStatus: boolean = true;

  constructor(
    public myAdService: MyAdService,
    public router: Router,
    public dataTransferService: DataTransferService,
    public title: Title
    
  ) {
    super(dataTransferService, router, title);
  }

  ngOnInit() {
    super.setTitle('Meus anúncios')
    this.init();
  }

  private init(): void {

    this.processRunningStart();

    this.myAdService.get()
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<MyAdModel> = response.error as ResponseEnvelope<MyAdModel>;
          super.processHttpErrorResponse(response)
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
          this.isAlready = true;
        }))
      .subscribe((response) => {
        this.cards = response.dto.cards
        this.listStatus = response.dto.status;
        this.selectStatus(this.listStatus[0]);
      });
  }

  public verifySelectedStatus(status: ItemModel): boolean {
    return this.selectedStatus == status;
  }

  public selectStatus(status: ItemModel): void {
    this.selectedStatus = status;
    this.filter();
  }

  public filter(): void {
    this.filteredCards = this.cards.filter((f) => f.ad.status == this.selectedStatus.id);
    this.hasAdsInStatus = this.filteredCards.length > 0;
  }

  public hide(card: CardDetailModel): void {

  }

}
