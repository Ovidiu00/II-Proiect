import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashbordComponent } from './admin-dashbord/admin-dashbord.component';
import { AdminCategoryListComponent } from './components/categories-management/admin-category-list/admin-category-list.component';
import { AdminProductListComponent } from './components/products-management/admin-product-list/admin-product-list.component';

const routes: Routes = [
  { path: '', component:AdminDashbordComponent },
  { path: 'categories', component:AdminCategoryListComponent },
  { path: 'categories/:categoryId', component:AdminCategoryListComponent },
  { path: 'categories/:categoryId/products', component:AdminProductListComponent },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
