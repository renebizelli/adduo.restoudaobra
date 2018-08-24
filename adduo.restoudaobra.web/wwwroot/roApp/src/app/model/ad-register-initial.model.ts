import { AddressDetailModel } from "./address-detail.model";
import { TypeHelper } from "../shared/type.helper";

export class AdRegisterInitialModel {
  constructor(public guid: string,
    public addresses: AddressDetailModel[]) { }


  static _new(): AdRegisterInitialModel {
    return new AdRegisterInitialModel(TypeHelper.guidEmpty, new Array<AddressDetailModel>());
  }

}
