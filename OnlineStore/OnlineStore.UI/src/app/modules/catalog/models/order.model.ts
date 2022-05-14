import { CartItem } from "./cart-item.model";

export class Order{
  orderId:number;
  orderDate:Date;
  productVms:CartItem[]
}
