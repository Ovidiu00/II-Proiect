import { Component, HostListener, Input, OnInit } from '@angular/core';
import { CartItem } from '../../../models/cart-item.model';
import { faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {

  constructor() { }
  @Input()
  fromCartView:boolean = false;

  public showDeleteButton:boolean = false;
  @HostListener('mouseenter')
  onMouseEnter() {
    this.showDeleteButton = true && this.fromCartView;
  }

  @HostListener('mouseleave')
  onMouseLeave() {
    this.showDeleteButton = false && this.fromCartView;
  }


  trash= faTrash;
  @Input()
  item:CartItem;
  public image:string;

  ngOnInit(): void {
    this.image = this.item.filePath;
    console.log(this.item.filePath.indexOf('http'),)
    if (this.item.filePath.indexOf('http') == -1)
      this.image =
        'http://localhost:4200/assets/images/' + this.item.filePath;
  }
}
