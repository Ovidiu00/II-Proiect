import { Component,OnDestroy,OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryDropdownListService } from 'src/app/shared/navigation/category-dropdown-list.service';
import { Category } from '../catalog/models/category.model';
import { Product } from '../catalog/models/product.model';
import { CategoryService } from '../catalog/services/category.service';
import { ProductsService } from '../catalog/services/products.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  constructor(
    public categoryDropdownVisbilityService:CategoryDropdownListService,
    public categoryService : CategoryService,
    public productService:ProductsService) {}


  public mainCategories$:Observable<Category[]>
  public mostPopularProducts$:Observable<Product[]>;
  public mostRecentProducts$:Observable<Product[]>;
  ngOnInit(): void {
    this.categoryDropdownVisbilityService.hide();

    this.mostPopularProducts$ = this.productService.getMostPopularProducts();
    this.mostRecentProducts$ = this.productService.getLatestProducts();

    this.mainCategories$ = this.categoryService.getCategories();
  }

  ngOnDestroy(): void {
      this.categoryDropdownVisbilityService.show();
  }
}
