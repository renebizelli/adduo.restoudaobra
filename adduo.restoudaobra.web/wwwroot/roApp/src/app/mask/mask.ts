import { Directive, HostListener, ElementRef, Renderer, OnInit, DoCheck, Output } from "@angular/core";
import { isNumber, format } from "util";
import { EventEmitter } from "events";

@Directive({ selector: '[mask]' })
export class Mask implements DoCheck {

 // @Output() ngModelChange = new EventEmitter();

  private text: string = ''
  protected config: any = { limit: 0, special: [] };

  private el: HTMLInputElement

  constructor(
    public elementRef: ElementRef,
    public renderer: Renderer) {

    this.el = this.elementRef.nativeElement;
  }


  ngDoCheck(): void {
    this.text = this.el.value;
    this.el.value = this.toformat();
  }

  toformat() {

    var formatted = ''

    var numbers = this.onlyNumber();

    for (var i = 0; i < numbers.length; i++) {

      if (this.config.special[i]) {
        formatted += this.config.special[i];
      }
      formatted += numbers[i];
    }

    return formatted;
  }


  @HostListener('keydown', ['$event'])
  public onKeyDown(e: any) {
     

    if (e.keyCode === 8) {
      let last = this.text.substr(this.text.length - 1, 1);
      let del = isNaN(parseInt(last)) ? 2 : 1;
      this.text = this.text.substr(0, this.text.length - del);
    }

    var numbers = this.onlyNumber();
    if (numbers.length < this.config.limit) {

      if (!isNaN(parseInt(e.key))) {
        this.text += e.key;
      }


      //this.el.value = this.toformat();

      console.log('sdf');  

      this.renderer.setElementProperty(this.el, 'value', this.toformat())
    //  this.ngModelChange.emit(this.el.value)
    }



    return false;
  }

  private onlyNumber(): string {

    var _match = this.text.match(/\d+/g);

    return _match ? _match.reduce((a, b) => a + '' + b) : '';
  }

}
