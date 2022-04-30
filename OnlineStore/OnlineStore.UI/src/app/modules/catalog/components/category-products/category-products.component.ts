import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Product } from '../../models/product.model';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-category-products',
  templateUrl: './category-products.component.html',
  styleUrls: ['./category-products.component.css']
})
export class CategoryProductsComponent implements OnInit {

  constructor(
    public route:ActivatedRoute,
    public productService:ProductsService
    ) { }

  public showComponent:boolean = false;
  public products$ :Observable<Product[]>;

  ngOnInit(): void {
    this.route.params.subscribe( x => {
     this.products$ = this.productService.getProductsForCategory(x['id']);
     console.log("aici")

    })
  }

  ngAfterViewInit(){
    this.showComponent = true;
  }
}
