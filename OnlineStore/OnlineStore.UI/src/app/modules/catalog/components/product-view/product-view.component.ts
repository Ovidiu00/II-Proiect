import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { Product } from '../../models/product.model';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {

  constructor(public activatedRoute:ActivatedRoute,public productService:ProductsService) { }

  ngOnInit(): void {
    var productId:number;
    this.activatedRoute.paramMap.subscribe(params =>
       {
         productId =  Number(params.get('id'));
         this.productService.getProductById(productId).subscribe(response => {
           this.product = response
           console.log(this.product);
         });

        })


  }
public product:Product = new Product();

 public faShoppingCart = faShoppingCart;

}
