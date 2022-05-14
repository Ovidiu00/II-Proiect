import { Component, HostBinding, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Product } from '../../models/product.model';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  constructor(public productService: ProductsService, public router: Router) {}

  @Input()
  products$: Observable<Product[]>;

  @HostBinding('class.show-view') 
  showView: boolean = false;
  ngAfterViewInit(){
    this.showView = true;
  }
  ngOnInit(): void {}
  


  selectProduct(id: number) {
    this.router.navigate(['catalog/produs/'+id]);
  }
}
