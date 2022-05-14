import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { AlertifyService } from '../../../shared/services/alertify-service/alertify.service';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  constructor(public http: HttpClient,private alertify:AlertifyService) {}

  private apiBaseURL = 'https://localhost:44350';
  private productsBaseApi = this.apiBaseURL + '/Products';

  getLatestProducts(count: number): Observable<Product[]> {
    return this.http.get<Product[]>(
      this.productsBaseApi + '/recent-products?count=' + count
    );
  }

  getMostPopularProducts(count: number): Observable<Product[]> {
    return this.http.get<Product[]>(
      this.productsBaseApi + '/popular-products?count=' + count
    );
  }

  getProductById(id: number): Observable<Product> {
    return this.http.get<Product>(this.productsBaseApi + '/' + id);
  }
  getProductsForCategory(categoryId: number): Observable<Product[]> {
    return this.http.get<Product[]>(
      this.apiBaseURL + '/categories/' + categoryId + '/products'
    );
  }
  addProduct(dto: FormData, categoryId: number): Observable<any> {
    return this.http.post(this.productsBaseApi + '/' + categoryId, dto).pipe(
      tap(() => this.alertify.success("Produs adaugat cu succes!")),
      catchError(async () => this.alertify.error("Eroare la adaugare produs!"))
    );
  }
  editProduct(dto: FormData, productId: number): Observable<any> {
    return this.http.put(this.productsBaseApi + '/' + productId, dto).pipe(
      tap(() => this.alertify.success("Produs editat cu succes!")),
      catchError(async () => this.alertify.error("Eroare la editare produs!"))
    );
  }
  deleteProduct(productId: number) {
    return this.http.delete(this.productsBaseApi + '/' + productId).pipe(
      tap(() => this.alertify.success("Produs sters cu succes!")),
      catchError(async () => this.alertify.error("Eroare la stergere produs!"))
    );
  }
}
