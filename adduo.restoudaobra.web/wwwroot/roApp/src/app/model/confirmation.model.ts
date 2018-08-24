import { TypeHelper } from "../shared/type.helper";

export class ConfirmationModel {
  constructor(public guid: string) { }

  static _new(): ConfirmationModel {
      return new ConfirmationModel(TypeHelper.guidEmpty)
  }


}
