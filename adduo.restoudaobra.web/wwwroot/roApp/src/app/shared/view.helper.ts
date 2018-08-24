import { PropertyStringModel } from "./propertystring.model";
import { StatusPropertyEnum } from "../enum/status-property.enum";
import { ErrorCodeEnum } from "../enum/error-code.enum";
import { Injectable } from "@angular/core";
import { AdTypeEnum } from "../enum/ad-type.enum";

@Injectable()
export class ViewHelper {

  public isErrorCodeAlready(property: PropertyStringModel): boolean {
    return property.status == StatusPropertyEnum.invalid && property.code == ErrorCodeEnum.already;
  }

  public isErrorCodeEmpty(property: PropertyStringModel): boolean {
    return property.status == StatusPropertyEnum.invalid && property.code == ErrorCodeEnum.empty;
  }

  public isErrorCodeInvalid(property: PropertyStringModel): boolean {
    return property.status == StatusPropertyEnum.invalid && property.code == ErrorCodeEnum.invalid;
  }

  public isErrorCodeInactive(property: PropertyStringModel): boolean {
    return property.status == StatusPropertyEnum.invalid && property.code == ErrorCodeEnum.inactive;
  }

  public isErrorCodeErro(property: PropertyStringModel): boolean {
    return property.status == StatusPropertyEnum.invalid && property.code == ErrorCodeEnum.erro;
  }

  public isErrorCodeDifferent(property: PropertyStringModel): boolean {
    return property.status == StatusPropertyEnum.invalid && property.code == ErrorCodeEnum.different;
  }

  public isErrorCodeNotFound(property: PropertyStringModel): boolean {
    return property.status == StatusPropertyEnum.invalid && property.code == ErrorCodeEnum.notfound;
  }

  public isValid(property: PropertyStringModel): boolean {
    return property.status == StatusPropertyEnum.valid;
  }

  public isAdTypeSale(type:AdTypeEnum): boolean {
    return type == AdTypeEnum.sale;
  }
  public isAdTypeDonation(type: AdTypeEnum): boolean {
    return type == AdTypeEnum.donation;
  }
}


