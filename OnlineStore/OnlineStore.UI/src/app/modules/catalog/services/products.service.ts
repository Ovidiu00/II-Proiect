import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(public http:HttpClient) { }

  private apiBaseURL = "https://localhost:44350";
  private productsBaseApi = this.apiBaseURL +"/Products";


  getLatestProducts(count:number):Observable<Product[]>{

    return this.http.get<Product[]>(this.productsBaseApi+"/recent-products?count=" +count);
  }

  getMostPopularProducts(count:number):Observable<Product[]>{
    return this.http.get<Product[]>(this.productsBaseApi+"/popular-products?count=" +count);
  }

  getProductById(id:number):Observable<Product>
  {
      return this.http.get<Product>(this.productsBaseApi+"/"+id);
  }
  getProductsForCategory(categoryId:number):Observable<Product[]>{
    return this.http.get<Product[]>(this.apiBaseURL+"/categories/"+categoryId+"/products");
  }
  addProduct(dto:FormData,categoryId:number):Observable<any>{
    return this.http.post(this.productsBaseApi+"/"+categoryId,dto);
  }
  editProduct(dto:FormData,productId:number):Observable<any>{
    return this.http.put(this.productsBaseApi+"/"+productId,dto);
  }
  deleteProduct(productId:number){
    return this.http.delete(this.productsBaseApi+"/"+productId);
  }
}
