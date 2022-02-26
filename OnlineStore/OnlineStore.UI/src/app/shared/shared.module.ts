import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatRadioModule } from '@angular/material/radio';
import { TranslateModule } from '@ngx-translate/core';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { LayoutComponent } from './layout/layout.component';
import { CategoryDropdownComponent } from './navigation/category-dropdown/category-dropdown.component';
import { CategoryDropdownListComponent } from './navigation/category-dropdown-list/category-dropdown-list.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SubCategoriesTooltipComponent } from './navigation/sub-categories-tooltip/sub-categories-tooltip.component';
import { RouterModule } from '@angular/router';
import { ContactInfoComponent } from './navigation/contact-info/contact-info.component';

const matModules = [
  MatPaginatorModule,
  MatTableModule,
  MatIconModule,
  MatStepperModule,
  MatToolbarModule,
  MatButtonModule,
  MatSidenavModule,
  MatIconModule,
  MatTableModule,
  MatStepperModule,
  MatListModule,
  MatCardModule,
  MatMenuModule,
  MatRadioModule,
];
const ngxModules = [TranslateModule];
const navigationComponents = [
  HeaderComponent,
  SidenavListComponent,
  CategoryDropdownComponent,
  CategoryDropdownListComponent,
  SubCategoriesTooltipComponent,
  ContactInfoComponent,
];
const components = [];
const services = [];

@NgModule({
  declarations: [navigationComponents, LayoutComponent],
  imports: [
    CommonModule,
    ...matModules,
    ngxModules,
    FlexLayoutModule,
    NgbModule,
    FontAwesomeModule,
    RouterModule,
  ],
  providers: [],
  exports: [
    CommonModule,
    ...matModules,
    ngxModules,
    navigationComponents,
    LayoutComponent,
    FlexLayoutModule,
    NgbModule,
    FontAwesomeModule,
    RouterModule,
  ],
})
export class SharedModule {}
