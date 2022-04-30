import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Order } from '../../../models/order.model';
import { OrdersService } from '../../../services/orders.service';

@Component({
  selector: 'app-order-history-dialog',
  templateUrl: './order-history-dialog.component.html',
  styleUrls: ['./order-history-dialog.component.css'],
})
export class OrderHistoryDialogComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<OrderHistoryDialogComponent>,
    private orderService: OrdersService
  ) {}

  public orders: Order[];
  ngOnInit(): void {
    this.orderService.getOrders().subscribe((x) => (this.orders = x));
  }
}
