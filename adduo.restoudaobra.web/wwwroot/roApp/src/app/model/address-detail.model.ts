import { TypeHelper } from "../shared/type.helper";

export class AddressDetailModel {

  constructor(
    public district: string,
    public city: string,
    public State: string,
    public id: number) { }


  static _new(): AddressDetailModel {
    return new AddressDetailModel(
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      0)
  }

}
