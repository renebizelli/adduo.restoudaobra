import { PropertyStringModel } from "../shared/propertystring.model";
import { PropertyNumberModel } from "../shared/propertynumber.model";
import { PropertyItemModel } from "../shared/propertyitem.model";
import { ItemModel } from "./item.model";
import { ActionTypeEnum } from "../enum/action-type.enum";

export class AddressRegisterModel {

  constructor(
    public id: PropertyNumberModel,
    public city: PropertyStringModel,
    public state: PropertyItemModel,
    public district: PropertyStringModel,
    public actionType: ActionTypeEnum) { }

  static _new(): AddressRegisterModel {
    return new AddressRegisterModel(
      new PropertyNumberModel(),
      new PropertyStringModel(),
      new PropertyItemModel(),
      new PropertyStringModel(),
      ActionTypeEnum.new
    );
  }



}
