import { TypeHelper } from "../shared/type.helper";

export class ItemModel {

  constructor(
    public id: number,
    public name: string) { }

  static _new(): ItemModel {
    return new ItemModel(0, TypeHelper.stringEmpty);
  }
}
