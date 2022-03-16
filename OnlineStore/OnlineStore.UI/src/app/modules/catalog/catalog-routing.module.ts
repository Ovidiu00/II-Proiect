import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { CategoryCardListComponent } from './components/category-card-list/category-card-list.component';
import { CategoryProductsComponent } from './components/category-products/category-products.component';
import { ProductViewComponent } from './components/product-view/product-view.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: "catalog/produs/:id", component: ProductViewComponent },
  { path: "catalog/categorii/:id", component: CategoryCardListComponent },
  { path: "catalog/categorii/:id/products", component: CategoryProductsComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CatalogRoutingModule {}
