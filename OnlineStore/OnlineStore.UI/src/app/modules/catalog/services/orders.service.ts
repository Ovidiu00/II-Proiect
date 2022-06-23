import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
import { AlertifyService } from '../../../shared/services/alertify-service/alertify.service';
import { UserModel } from '../../account/models/user.model';
import { AccountService } from '../../account/services/account.service';
import { CartItem } from '../models/cart-item.model';
import { Order } from '../models/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(public http:HttpClient,private accountService:AccountService,private alertify:AlertifyService) { }

  private apiBaseURL = "https://localhost:44350";
  private ordersBaseApi = this.apiBaseURL +"/orders";
  private cartBaseApi = this.apiBaseURL +"/cart";

  private currentUser:UserModel = this.accountService.getLoggedInUser();

  addItemToCart(productId:number,quantity:number){
    return this.http.post(this.cartBaseApi+"/add-to-cart?userId="+this.currentUser.userId,{id:productId,quantity:quantity}).pipe(
      tap(() => this.alertify.success("Produs adaugat cu succes!")),
      catchError(async () => this.alertify.error("Eroare la adaugare produs!"))
    );
  }
  getItemsInCart():Observable<CartItem[]>{
    return this.http.get<CartItem[]>(this.cartBaseApi+"/view-items?userId="+this.currentUser.userId);
  }

  orderProductsFromCart(){
    return this.http.post(this.ordersBaseApi+"?userId="+this.currentUser.userId,null).pipe(
      tap(() => this.alertify.success("Comanda produselor s-a plasat cu succes!")),
      catchError(async () => this.alertify.error("Eroare la plasarea comenzii produs!"))
    );
  }
  getOrders():Observable<Order[]>{
    return this.http.get<Order[]>(this.ordersBaseApi+"/history?userId="+this.currentUser.userId);
  }
  removeFromCart(id:number){
    return this.http.post(this.ordersBaseApi+"/remove-from-cart?id="+id+"&userId="+this.currentUser.userId,null);
  }
}
