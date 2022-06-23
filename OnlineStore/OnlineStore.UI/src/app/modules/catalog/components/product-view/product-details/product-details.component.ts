import { Component, HostBinding, Input, OnInit } from '@angular/core';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { Product } from '../../../models/product.model';
import { OrdersService } from '../../../services/orders.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  constructor(private orderService:OrdersService) { }

  @HostBinding('class.show-view')
  showView: boolean = false;
  ngAfterViewInit(){
    this.showView = true;
  }
  ngOnInit(): void {
  }

  @Input()
  public product:Product;

  public quantitySelected:number = 1;
  public faShoppingCart = faShoppingCart;


  onAddToCart(){
    if(this.product.quantity === 0)
        return;

        console.log(this.quantitySelected);
    this.orderService.addItemToCart(this.product.id,this.quantitySelected).subscribe(x => console.log("Dad"));
  }
}
