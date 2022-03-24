import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(public http:HttpClient) {}

  categoriesBaseApi = "https://localhost:44350/Category";

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.categoriesBaseApi);
  }

  getCategoryById(id: number): Observable<Category> {
    return this.http.get<Category>(this.categoriesBaseApi+"/"+id);
  }

  addSubCategory(dto:FormData,categoryId:number){
    console.log(dto);
    console.log("pt categoria " + categoryId);
  }

  addCategory(dto:FormData):Observable<any>{
    return of();
  }
  editCategory(dto:FormData):Observable<any>{
    return of();
  }
  deleteCategory(categoryId:number){
    return of();
  }
}
