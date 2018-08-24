import { TypeHelper } from "../shared/type.helper";
import { AdTypeEnum } from "../enum/ad-type.enum";
import { AdStatusEnum } from "../enum/ad-status.enum";

export class AdDetailModel {

  constructor(
    public id: number,
    public guid: string,
    public name: string,
    public option: string,
    public brand: string,
    public quantity: string,
    public price: number,
    public type: AdTypeEnum,
    public status: AdStatusEnum,
    public StatusName: string,
    public url: string,
    public created: string) { }


  static _new(): AdDetailModel {
    return new AdDetailModel(
      0,
      TypeHelper.guidEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      0,
      AdTypeEnum.none,
      AdStatusEnum.none,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty)
  }
}
