import { StatusPropertyEnum } from '../enum/status-property.enum';
import { ErrorCodeEnum } from '../enum/error-code.enum';
import { TypeHelper } from './type.helper';

export class PropertyModel<T> {
  public prop: boolean = false;;
  public code: ErrorCodeEnum = ErrorCodeEnum.none;
  public status: StatusPropertyEnum = StatusPropertyEnum.none;
  public format: string = TypeHelper.stringEmpty;
  public edit: boolean = false;
  public maxlength: number = 0;

  constructor(public value: T, public defaultvalue: T) { }

  


}


