import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedModule } from "../../shared/shared.module";
import { LoginDialogComponent } from "./components/login/login-dialog/login-dialog.component";
import { LoginDirective } from "./components/login/login.directive";
import { ShoppingCartComponent } from "./components/shopping-cart/shopping-cart.component";
import { RegisterDialogComponent } from './components/register/register-dialog/register-dialog.component';
import { RegisterDirective } from './components/register/register.directive';
import { JwtInterceptor } from "./services/jwt-interceptor.interceptor";
import { HTTP_INTERCEPTORS } from "@angular/common/http";

@NgModule({
  declarations: [
    LoginDirective,
    ShoppingCartComponent,
    LoginDialogComponent,
    RegisterDialogComponent,
    RegisterDirective
  ],
  imports: [CommonModule,SharedModule],
  exports: [
    LoginDirective,
    RegisterDirective
  ],
  providers:[
    {provide:HTTP_INTERCEPTORS,useClass:JwtInterceptor,multi:true}
  ]
})
export class AccountModule {}
