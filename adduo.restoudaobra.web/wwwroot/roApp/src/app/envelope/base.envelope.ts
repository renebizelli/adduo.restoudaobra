import { ErrorEnvelope } from "./error.envelope";

export class BaseEnvelope {
  public culture: string = 'pt-BR'
  public success: boolean
  public error: ErrorEnvelope
}



