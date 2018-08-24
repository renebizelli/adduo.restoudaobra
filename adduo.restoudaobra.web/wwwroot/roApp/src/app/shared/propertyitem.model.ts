import { PropertyModel } from "./property.model";
import { ItemModel } from "../model/item.model";

export class PropertyItemModel extends PropertyModel<ItemModel> {


  constructor() {
    super(ItemModel._new(), ItemModel._new());
  }

}

