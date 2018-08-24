import { TokenModel } from "./toke.model";
import { TypeHelper } from "../shared/type.helper";

export class AuthenticatedModel {
  public token: TokenModel = new TokenModel();
  public name: string = TypeHelper.stringEmpty;
}
