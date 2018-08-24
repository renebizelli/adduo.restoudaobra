import { Directive, HostListener, Renderer, ElementRef } from "@angular/core";
import { Mask } from "./mask";

@Directive({ selector: '[cpf-mask]' })
export class CPFMask extends Mask {

  constructor(
    public elementRef: ElementRef,
    public renderer: Renderer) {

    super(elementRef, renderer)

    this.config.limit = 10;
    this.config.special[0] = '(';
    this.config.special[6] = '-';
    this.config.special[2] = ') ';

  }

}
