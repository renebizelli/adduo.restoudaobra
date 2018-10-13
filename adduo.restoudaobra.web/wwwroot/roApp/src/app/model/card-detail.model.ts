import { AddressDetailModel } from "./address-detail.model";
import { AdDetailModel } from "./ad-detail.model";
import { TypeHelper } from "../shared/type.helper";
import { OwnerDetail } from "./owner-detail";

export class CardDetailModel {

  public image:string = TypeHelper.stringEmpty

  constructor(
    public ad: AdDetailModel,
    public address: AddressDetailModel,
    public images: string[], 
    public owner: OwnerDetail) { }

  static _new(): CardDetailModel {
    return new CardDetailModel(AdDetailModel._new(), AddressDetailModel._new(), [], OwnerDetail._new());
  }
}
 