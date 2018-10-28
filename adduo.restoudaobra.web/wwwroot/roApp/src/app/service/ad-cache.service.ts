import { Injectable } from "../../../node_modules/@angular/core";
import { CardDetailModel } from "../model/card-detail.model";
import { TypeHelper } from "../shared/type.helper";

@Injectable({
  providedIn: 'root'
})
export class AdCacheService { 

  public cards: CardDetailModel[] = [];
  private page:number = 0

  constructor() {}
  
  public set(cards: CardDetailModel[]) : void {
    this.cards = cards;
  }
  
  public reset() : void {
    this.cards = [];
  }
  
  public get() : CardDetailModel[] {
    return this.cards;
  }
  
  public hasCards() : boolean {
    return this.cards.length > 0;
  }

}
