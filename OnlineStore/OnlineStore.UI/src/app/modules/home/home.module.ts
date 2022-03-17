import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "src/app/shared/shared.module";
import { CatalogModule } from "../catalog/catalog.module";
import { AdressInfoComponent } from "./components/adress-info/adress-info.component";
import { HomeImageComponent } from "./components/home-image/home-image.component";
import { OtherIfnoComponent } from "./components/other-ifno/other-ifno.component";
import { HomeComponent } from "./home.component";

const homeComponents = [
  AdressInfoComponent,
  HomeImageComponent,
  OtherIfnoComponent,
  HomeComponent
]

@NgModule({
  declarations: [homeComponents],
  imports: [CommonModule,CatalogModule,SharedModule],
  providers: [],
  exports: [],
})
export class HomeModule {}
