import { PropertyStringModel } from "../shared/propertystring.model";
import { PropertyNumberModel } from "../shared/propertynumber.model";
import { AdTypeEnum } from "../enum/ad-type.enum";
import { TypeHelper } from "../shared/type.helper";

export class AdRegisterModel {

  constructor(
    public id: number,
    public guid: string,
    public type:AdTypeEnum,
    public name: PropertyStringModel,
    public option: PropertyStringModel,
    public brand: PropertyStringModel,
    public quantity: PropertyStringModel,
    public price: PropertyNumberModel) { }

  static _new(): AdRegisterModel {
    return new AdRegisterModel(
      0,
      TypeHelper.guidEmpty,
      AdTypeEnum.none,
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyNumberModel()
    );
  }

}


