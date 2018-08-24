import { PropertyStringModel } from "../shared/propertystring.model";
import { TypeHelper } from "../shared/type.helper";

export class RedefinePasswordSolicitationModel {
  constructor(public cpfemail: PropertyStringModel,
    public ofuscated: string) { }


  static _new(): RedefinePasswordSolicitationModel {
    return new RedefinePasswordSolicitationModel(new PropertyStringModel(), TypeHelper.stringEmpty);
  }



}
