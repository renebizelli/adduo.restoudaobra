import { TypeHelper } from "../shared/type.helper";
import { AdStatusEnum } from "../enum/ad-status.enum";

export class AdChangeStatusModel {

  constructor(
    public guid: string,
    public status: AdStatusEnum) { }

  static _new(): AdChangeStatusModel {
    return new AdChangeStatusModel(TypeHelper.guidEmpty, AdStatusEnum.none);
  }

}
