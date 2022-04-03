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

  addSubCategory(parnetCategoryId:number,childCategoryId:number){
    return this.http.put(this.categoriesBaseApi+"/"+parnetCategoryId+"/add-subcategory?childCategory="+childCategoryId,null);
  }

  addCategory(dto:FormData):Observable<any>{
    return this.http.post(this.categoriesBaseApi,dto);
  }
  editCategory(dto:FormData,id:number):Observable<any>{
    return this.http.put(this.categoriesBaseApi+"/"+id,dto);
  }
  deleteCategory(categoryId:number){
    return this.http.delete(this.categoriesBaseApi+"/"+categoryId);
  }
}
