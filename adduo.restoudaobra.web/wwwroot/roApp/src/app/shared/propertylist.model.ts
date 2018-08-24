import { PropertyModel } from "./property.model";

export class PropertyListModel<T> extends PropertyModel<T[]> {
  public list: T[] = []
  public defaultlist: T[] = []

  constructor() {
    super([], [])
  }
}

