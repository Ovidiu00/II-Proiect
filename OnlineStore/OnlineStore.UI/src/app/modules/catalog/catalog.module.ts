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
import { CartItemsDialogComponent } from './components/cart-items/cart-items-dialog/cart-items-dialog.component';
import { CartDirective } from './components/cart-items/cart.directive';
import { CartItemComponent } from './components/cart-items/cart-item/cart-item.component';
import { OrdersHistoryDirective } from './components/order-history/orders-history.directive';
import { OrderHistoryDialogComponent } from './components/order-history/order-history-dialog/order-history-dialog.component';
import { OrderItemComponent } from './components/order-history/order-item/order-item.component';

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
    CartItemsDialogComponent,
    CartDirective,
    CartItemComponent,
    OrdersHistoryDirective,
    OrderHistoryDialogComponent,
    OrderItemComponent,
  ],
  imports: [CommonModule, CatalogRoutingModule,SharedModule],
  exports: [
    CategoryCardComponent,
    CategoryCardListComponent,
    ProductListComponent,
    ProductCardComponent,
    ProductViewComponent,
    CartDirective,
    OrdersHistoryDirective
  ],
})
export class CatalogModule {}
