import { Directive, ElementRef, Input } from '@angular/core';

declare var $: any;


@Directive({
 selector: '[fotorama]'
})
export class FotoramaDirective {
 constructor(private el: ElementRef) {
 }
 
 @Input() images: string[] = []
 
  
  ngAfterViewInit() {
    let div = $(this.el.nativeElement).fotorama();
    let fotorama = div.data('fotorama')
    this.images.forEach((img, index, a) => {
      fotorama.push({ img: 'http://www.restoudaobra.com.br'+img})
    })
 }
}