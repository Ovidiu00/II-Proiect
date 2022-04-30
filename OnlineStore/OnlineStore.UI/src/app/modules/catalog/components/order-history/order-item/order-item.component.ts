import { Component, Input, OnInit } from '@angular/core';
import { Order } from '../../../models/order.model';

@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.css'],
})
export class OrderItemComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  @Input()
  order: Order;
}
