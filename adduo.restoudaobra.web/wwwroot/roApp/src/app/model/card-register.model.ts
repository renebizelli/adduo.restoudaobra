import { PropertyStringModel } from "../shared/propertystring.model";
import { AdRegisterModel } from "./ad-register.model";
import { AddressRegisterModel } from "./address-register.model";
import { PropertyListModel } from "../shared/propertylist.model";
import { AdRegisterInitialModel } from "./ad-register-initial.model";
import { AdImageRegisterModel } from "./ad-image-register.model";

export class CardRegisterModel {


  constructor(
    public ad: AdRegisterModel,
    public address: AddressRegisterModel,
    public images: PropertyListModel<AdImageRegisterModel>,
    public initial: AdRegisterInitialModel) { }


  static _new(): CardRegisterModel {
    return new CardRegisterModel(
      AdRegisterModel._new(),
      AddressRegisterModel._new(),
      new PropertyListModel<AdImageRegisterModel>(),
      AdRegisterInitialModel._new());
  }

}
