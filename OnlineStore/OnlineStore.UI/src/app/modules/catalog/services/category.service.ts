import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { AlertifyService } from '../../../shared/services/alertify-service/alertify.service';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(public http:HttpClient,private alertify:AlertifyService) {}

  categoriesBaseApi = "https://localhost:44350/Category";

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.categoriesBaseApi);
  }

  getCategoryById(id: number): Observable<Category> {
    return this.http.get<Category>(this.categoriesBaseApi+"/"+id);
  }

  addSubCategory(parnetCategoryId:number,childCategoryId:number){
    return this.http.put(this.categoriesBaseApi+"/"+parnetCategoryId+"/add-subcategory?childCategory="+childCategoryId,null);
  }

  addCategory(dto:FormData):Observable<any>{
    return this.http.post(this.categoriesBaseApi,dto).pipe(
      tap(() => this.alertify.success("Categorie adaugata cu succes!")),
      catchError(async () => this.alertify.error("Eroare la adaugare categorie!"))
    );
  }
  editCategory(dto:FormData,id:number):Observable<any>{
    return this.http.put(this.categoriesBaseApi+"/"+id,dto).pipe(
      tap(() => this.alertify.success("Categorie editata cu succes!")),
      catchError(async () => this.alertify.error("Eroare la editare categorie!"))
      );
  }
  deleteCategory(categoryId:number){
    return this.http.delete(this.categoriesBaseApi+"/"+categoryId).pipe(
      tap(() => this.alertify.success("Categorie stearsa cu succes!")),
      catchError(async () => this.alertify.error("Eroare la stergere categorie!"))
    );
  }
}
