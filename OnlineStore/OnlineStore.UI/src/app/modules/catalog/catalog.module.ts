import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryCardComponent } from './components/category-card/category-card.component';
import { CategoryCardListComponent } from './components/category-card-list/category-card-list.component';
import { CatalogRoutingModule } from './catalog-routing.module';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { ProductViewComponent } from './components/product-view/product-view.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ProductDetailsComponent } from './components/product-view/product-details/product-details.component';
import { QuantitySelectorComponent } from './components/product-view/product-details/quantity-selector/quantity-selector.component';
import { CategoryProductsComponent } from './components/category-products/category-products.component';

@NgModule({
  declarations: [
    CategoryCardComponent,
    CategoryCardListComponent,
    ProductListComponent,
    ProductCardComponent,
    ProductViewComponent,
    ProductDetailsComponent,
    QuantitySelectorComponent,
    CategoryProductsComponent,
  ],
  imports: [CommonModule, CatalogRoutingModule,SharedModule],
  exports: [
    CategoryCardComponent,
    CategoryCardListComponent,
    ProductListComponent,
    ProductCardComponent,
    ProductViewComponent,
  ],
})
export class CatalogModule {}
