import { PropertyStringModel } from '../shared/propertystring.model';

export class LoginModel {

  constructor(
    public email: PropertyStringModel,
    public password: PropertyStringModel) {
  }

  static _new(): LoginModel {
    return new LoginModel(new PropertyStringModel(), new PropertyStringModel())
  }

}


