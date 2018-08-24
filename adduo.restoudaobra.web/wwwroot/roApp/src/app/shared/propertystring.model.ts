import { PropertyModel } from "./property.model";
import { TypeHelper } from "./type.helper";

export class PropertyStringModel extends PropertyModel<string> {

  constructor() {
    super(TypeHelper.stringEmpty, TypeHelper.stringEmpty);
  }


}

