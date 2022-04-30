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
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RouterModule } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatChipsModule} from '@angular/material/chips';
import {MatDialogModule} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { AlertifyComponent } from './services/alertify-service/component/alertify.component';

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
  MatChipsModule,
  MatDialogModule,
  MatFormFieldModule,
  MatInputModule,
  MatSnackBarModule
];

const components = [];
const services = [];

@NgModule({
  imports: [
    CommonModule,
    ...matModules,
    FontAwesomeModule,
    RouterModule,
    FlexLayoutModule
  ],
  providers: [],
  exports: [
    CommonModule,
    ...matModules,
    FontAwesomeModule,
    RouterModule,
    FlexLayoutModule
  ],
  declarations: [
    AlertifyComponent
  ],
})
export class SharedModule {}
