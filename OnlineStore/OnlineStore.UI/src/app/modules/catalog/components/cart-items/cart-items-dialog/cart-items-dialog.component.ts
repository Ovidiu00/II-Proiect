import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CartItem } from '../../../models/cart-item.model';
import { OrdersService } from '../../../services/orders.service';

@Component({
  selector: 'app-cart-items-dialog',
  templateUrl: './cart-items-dialog.component.html',
  styleUrls: ['./cart-items-dialog.component.css']
})
export class CartItemsDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<CartItemsDialogComponent>,
    private orderService:OrdersService
    ) { }


 public itemsInCart:CartItem[];
  ngOnInit(): void {
    this.orderService.getItemsInCart().subscribe(x => this.itemsInCart = x);
  }

  onExitClick(): void {
    this.dialogRef.close();
  }

  onOrderClicked() {
    this.orderService.orderProductsFromCart().subscribe();
  }
}
