import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDashbordComponent } from './admin-dashbord/admin-dashbord.component';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminOperationsComponent } from './components/admin-operations/admin-operations.component';
import { AdminOperationComponent } from './components/admin-operation/admin-operation.component';
import { SharedModule } from 'src/app/shared/shared.module';
import {CatalogModule} from '../catalog/catalog.module';
import { AdminCategoryListComponent } from './components/categories-management/admin-category-list/admin-category-list.component';
import { AdminCategoryItemComponent } from './components/categories-management/admin-category-item/admin-category-item.component';
import { SubcategoryBadgeListComponent } from './components/categories-management/subcategory-badge-list/subcategory-badge-list.component';
import { AddCategoryDialogComponent } from './components/categories-management/dialogs/add-category-dialog/add-category-dialog.component';
import { AdminProductListComponent } from './components/products-management/admin-product-list/admin-product-list.component';
import { AdminProductCardComponent } from './components/products-management/admin-product-card/admin-product-card.component';
import { ProductDialogComponent } from './components/products-management/product-dialog/product-dialog.component';


@NgModule({
  declarations: [
    AdminDashbordComponent,
    AdminOperationsComponent,
    AdminOperationComponent,
    AdminCategoryListComponent,
    AdminCategoryItemComponent,
    SubcategoryBadgeListComponent,
    AddCategoryDialogComponent,
    AdminProductListComponent,
    AdminProductCardComponent,
    ProductDialogComponent
  ],
  imports: [
    AdminRoutingModule,
    SharedModule,
    CatalogModule,
    CommonModule
  ]
})
export class AdminModule { }
