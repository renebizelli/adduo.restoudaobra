import { TypeHelper } from "../shared/type.helper";

export class AdImageRegisterModel {

  constructor(
    public full: string,
    public index: number,
    public id: number,
    public guidProduct: string) { }


  static _new(): AdImageRegisterModel {
    return new AdImageRegisterModel(
      TypeHelper.stringEmpty,
      0,
      0,
      TypeHelper.guidEmpty)
  }

}
