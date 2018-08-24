import { ErrorCodeEnum } from "../enum/error-code.enum";

export class ErrorEnvelope {
  public messages: string[] = [];
  public code: ErrorCodeEnum = ErrorCodeEnum.none;
}

