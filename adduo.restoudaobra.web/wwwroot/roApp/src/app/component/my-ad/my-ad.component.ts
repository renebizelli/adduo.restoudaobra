import { Component, OnInit, Input, OnChanges, SimpleChanges, EventEmitter, Output } from '@angular/core';
import { CardDetailModel } from '../../model/card-detail.model';
import { ViewHelper } from '../../shared/view.helper';
import { TypeHelper } from '../../shared/type.helper';
import { AdChangeStatusModel } from '../../model/ad-change-status.model';
import { AdStatusEnum } from '../../enum/ad-status.enum';
import { MyAdService } from '../../service/my-ad.service';
import { map, catchError, finalize } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-my-ad',
  templateUrl: './my-ad.component.html'
})
export class MyAdComponent implements OnInit, OnChanges {

  @Input() public card: CardDetailModel = CardDetailModel._new();

  public urlComplement: string = TypeHelper.stringEmpty;
  public absolute: boolean = true;
  public loader: boolean = false;

  @Output() public refresh: EventEmitter<any> = new EventEmitter();

  constructor(
    public viewHelper: ViewHelper,
    public typeHelper: TypeHelper,
    public myAdService: MyAdService) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.prepareAd();
  }

  private prepareAd(): void {

    if (this.typeHelper.isNumber(this.card.ad.quantity)) {
      this.card.ad.quantity += ' unidades'
    }

    this.urlComplement = this.isAdTypeDonation() ? 'quero-doar' : 'quero-vender';

  }


  ngOnInit() {

  }

  private changeStatus(change: AdChangeStatusModel): void {

    this.loader = true;

    this.myAdService.changeStatus(change)
      .pipe(
        map(m => m.body),
        catchError(e => throwError(e)),
        finalize(() => { this.loader = false })
      ).subscribe((response) => {
        this.card.ad.status = change.status;
        this.refresh.next({});
      });
  }

  public paused(card: CardDetailModel): void {

    if (confirm("Deseja realmente ocultar o anúncio " + this.card.ad.name.toUpperCase() + "?")) {
      let change = new AdChangeStatusModel(this.card.ad.guid, AdStatusEnum.paused);
      this.changeStatus(change);
    }
  }

  public published(card: CardDetailModel): void {
    let change = new AdChangeStatusModel(this.card.ad.guid, AdStatusEnum.published);
    this.changeStatus(change);
  }

  public finished(card: CardDetailModel): void {
    if (confirm("Deseja realmente finalizar o anúncio " + this.card.ad.name.toUpperCase() + "?")) {
      let change = new AdChangeStatusModel(this.card.ad.guid, AdStatusEnum.finished);
      this.changeStatus(change);
    }
  }

  public isAdTypeDonation(): boolean {
    return this.viewHelper.isAdTypeDonation(this.card.ad.type);
  }

  public isAdTypeSale(): boolean {
    return this.viewHelper.isAdTypeSale(this.card.ad.type);
  }


  public showEdit(): boolean {
    return this.card.ad.status == AdStatusEnum.published ||
      this.card.ad.status == AdStatusEnum.paused;
  }

  public showPaused(): boolean {
    return this.card.ad.status == AdStatusEnum.published;
  }

  public showPublished(): boolean {
    return this.card.ad.status == AdStatusEnum.paused;
  }

  public showFinished(): boolean {
    return this.card.ad.status == AdStatusEnum.paused ||
      this.card.ad.status == AdStatusEnum.published;
  }


}
