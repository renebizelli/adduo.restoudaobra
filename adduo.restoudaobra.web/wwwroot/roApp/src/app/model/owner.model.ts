import { PropertyStringModel } from '../shared/propertystring.model';

export class OwnerModel {

  constructor(
    public id: number,
    public cpf: PropertyStringModel,
    public firstname: PropertyStringModel,
    public lastname: PropertyStringModel,
    public email: PropertyStringModel,
    public emailconfirm: PropertyStringModel,
    public phone: PropertyStringModel,
    public cellphone: PropertyStringModel,
    public password: PropertyStringModel,
    public passwordconfirm: PropertyStringModel,
    public emailAccept: boolean) { }

  static _new(): OwnerModel {

    return new OwnerModel(
      0,
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      new PropertyStringModel(),
      true
    );

  }

}


