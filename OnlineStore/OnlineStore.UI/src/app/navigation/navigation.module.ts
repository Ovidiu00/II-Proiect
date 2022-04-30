import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { AccountModule } from "../modules/account/account-module";
import { CatalogModule } from "../modules/catalog/catalog.module";
import { SharedModule } from "../shared/shared.module";
import { CategoryDropdownListComponent } from "./category-dropdown-list/category-dropdown-list.component";
import { CategoryDropdownComponent } from "./category-dropdown/category-dropdown.component";
import { HeaderComponent } from "./header/header.component";
import { LayoutComponent } from "./layout/layout.component";
import { SidenavListComponent } from "./sidenav-list/sidenav-list.component";
import { SubCategoriesTooltipComponent } from "./sub-categories-tooltip/sub-categories-tooltip.component";

@NgModule({
  declarations:[
    SidenavListComponent,
    HeaderComponent,
    LayoutComponent,
    CategoryDropdownListComponent,
    CategoryDropdownComponent,
    SubCategoriesTooltipComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    AccountModule,
    CatalogModule,
  ],
  exports:[
    SidenavListComponent,
    HeaderComponent,
    LayoutComponent,
    CategoryDropdownListComponent,
    CategoryDropdownComponent,
    SubCategoriesTooltipComponent,
  ]
})
export class NavigationModule {}
