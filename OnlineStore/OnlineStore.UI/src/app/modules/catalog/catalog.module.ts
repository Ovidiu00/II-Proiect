import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatalogComponent } from './catalog.component';

import { SharedModule } from 'src/app/shared/shared.module';

import { CatalogRoutingModule } from './catalog-routing.module';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { CategoryCardComponent } from './components/category-card/category-card.component';
import { CategoryCardListComponent } from './components/category-card-list/category-card-list.component';
import { ProductViewComponent } from './components/product-view/product-view.component';
import { CategoryService } from './services/category.service';
import { ProductsService } from './services/products.service';

@NgModule({
  declarations: [
    CatalogComponent,
    ProductListComponent,
    ProductCardComponent,
    CategoryCardComponent,
    CategoryCardListComponent,
    ProductViewComponent,
  ],
  imports: [CommonModule, SharedModule, CatalogRoutingModule],
  providers: [CategoryService, ProductsService],
  exports: [
    CatalogComponent,
    ProductListComponent,
    ProductCardComponent,
    CategoryCardComponent,
    CategoryCardListComponent,
  ],
})
export class CatalogModule {}
