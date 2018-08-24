import { PropertyStringModel } from "../shared/propertystring.model";

export class ContactModel {

  constructor(
    public name: PropertyStringModel,
    public email: PropertyStringModel,
    public phone: PropertyStringModel,
    public message: PropertyStringModel) { }


  static _new(): ContactModel {

    return new ContactModel(
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel()
    );

  }



}
