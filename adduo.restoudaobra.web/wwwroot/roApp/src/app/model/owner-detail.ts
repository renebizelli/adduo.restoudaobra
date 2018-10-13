import { TypeHelper } from "../shared/type.helper";

export class OwnerDetail {

  constructor(
    public firstName: string,
    public email: string,
    public phone: string,
    public cellphone: string,
    public phoneFormat: string,
    public cellphoneFormat: string
  ) {
  }
  
  static _new(): OwnerDetail {
    return new OwnerDetail(
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty,
      TypeHelper.stringEmpty
    );
  }

  
  

}
