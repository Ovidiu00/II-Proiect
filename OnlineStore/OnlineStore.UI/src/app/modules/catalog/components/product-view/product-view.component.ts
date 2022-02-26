import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product.model';
import { ProductsService } from '../../services/products.service';
import { faMinus, faPhone, faPlus, faShoppingCart } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {

  constructor(public activatedRoute:ActivatedRoute,public productService:ProductsService) { }

  ngOnInit(): void {
    var productId:number;
    this.activatedRoute.paramMap.subscribe(params => productId =  Number(params.get('id')))


    this.productService.getProductById(productId).subscribe(response => this.product = response);
  }
public product:Product;
public faPlus = faPlus;
public faMinus = faMinus;
public faShoppingCart = faShoppingCart;
public faPhone = faPhone;

}
