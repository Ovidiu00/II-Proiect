import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatalogRoutes } from 'src/app/shared/routes/routes';
import { CatalogComponent } from './catalog.component';
import { CategoryCardListComponent } from './components/category-card-list/category-card-list.component';
import { ProductViewComponent } from './components/product-view/product-view.component';


const routes: Routes = [
  { path: '', component: CatalogComponent },
  { path: CatalogRoutes.productView.path+"/:id", component: ProductViewComponent },
  { path: CatalogRoutes.categories.path+"/:id", component: CategoryCardListComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CatalogRoutingModule {}
