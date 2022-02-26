import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css'],
})
export class ProductCardComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}


  status: boolean = false;

  @HostListener('click')
  onClick() {
    this.productSelected.emit(this.product.id)
  }

  @Input()
  public product: Product;
  @Output()
  public productSelected : EventEmitter<number> = new EventEmitter<number>();


  mouseHover() {
    this.status = !this.status;
  }
}
