import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Product } from '../../../../catalog/models/product.model';
import { ProductsService } from '../../../../catalog/services/products.service';
import { CategoryDropdownListService } from 'src/app/navigation/category-dropdown-list.service';

@Component({
  selector: 'app-admin-product-list',
  templateUrl: './admin-product-list.component.html',
  styleUrls: ['./admin-product-list.component.css'],
})
export class AdminProductListComponent implements OnInit,OnDestroy {
  constructor(
    public productService: ProductsService,
    public router: Router,
    public activatedRoute: ActivatedRoute,
    public categoryDropdownService:CategoryDropdownListService
  ) {}

  @Input()
  products$: Observable<Product[]>;

  ngOnInit(): void {
    this.categoryDropdownService.hide();

    var categoryId: number;
    this.activatedRoute.paramMap.subscribe((params) => {
      categoryId = Number(params.get('categoryId'));
      if (categoryId) {
        this.products$ = this.productService.getProductsForCategory(categoryId);
      }
    });
  }

  ngOnDestroy(){

    this.categoryDropdownService.show();
  }
  selectProduct(id: number) {
    // this.router.navigate([CatalogRoutes.productView.url,id]);

    this.router.navigate(['catalog/produs/' + id]);
  }
}
