import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { HomeComponent } from './modules/home/home.component';
import { CatalogModule } from './modules/catalog/catalog.module';
import { HomeImageComponent } from './modules/home/components/home-image/home-image.component';
import { AdressInfoComponent } from './modules/home/components/adress-info/adress-info.component';
import { OtherIfnoComponent } from './modules/home/components/other-ifno/other-ifno.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeImageComponent,
    AdressInfoComponent,
    OtherIfnoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CatalogModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
