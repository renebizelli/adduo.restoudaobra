import { AddressDetailModel } from "./address-detail.model";
import { AdDetailModel } from "./ad-detail.model";

export class CardDetailModel {

  constructor(
    public ad: AdDetailModel,
    public adresses: AddressDetailModel,
    public images: string[]) { }

  static _new(): CardDetailModel {
    return new CardDetailModel(AdDetailModel._new(), AddressDetailModel._new(), []);
  }
}
