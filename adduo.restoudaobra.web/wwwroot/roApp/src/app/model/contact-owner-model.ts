import { TypeHelper } from "../shared/type.helper";
import { AdTypeEnum } from "../enum/ad-type.enum";
import { AdStatusEnum } from "../enum/ad-status.enum";

export class ContactOwner {

  constructor(
    public phoneFormat: string,
    public cellphoneFormat: string,
    public email: string) { }


  static _new(): ContactOwner {
    return new ContactOwner(
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty)
  }
}
