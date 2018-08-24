import { PropertyStringModel } from "../shared/propertystring.model";

export class RedefinePasswordChangeModel {
  constructor(
    public password: PropertyStringModel,
    public confirmation: PropertyStringModel) { }

  static _new(): RedefinePasswordChangeModel {
    return new RedefinePasswordChangeModel(new PropertyStringModel(), new PropertyStringModel());
  }


}
