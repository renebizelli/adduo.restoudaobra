import { Directive, HostListener, ElementRef, Renderer } from "@angular/core";
import { Mask } from "./mask";

@Directive({ selector: '[cellphone-mask]' })
export class CellPhoneMask extends Mask {

  constructor(
    public elementRef: ElementRef,
    public renderer: Renderer) {

    super(elementRef, renderer)
    this.config.limit = 11;
    this.config.special[0] = '(';
    this.config.special[2] = ') ';
    this.config.special[7] = '-';

  }

}
