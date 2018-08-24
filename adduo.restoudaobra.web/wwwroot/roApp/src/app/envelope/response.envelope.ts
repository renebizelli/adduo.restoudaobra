import { BaseEnvelope } from "./base.envelope";

export class ResponseEnvelope<T> extends BaseEnvelope {
  public dto: T;
  public dtos: T[];
}


