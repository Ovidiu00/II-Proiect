import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  public categories: Category[] = [
    {
      id: 1,
      name: 'Articole Barbati',
      filePath: 'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_88.jpg',
      subCategories: [
        {
          id: 24,
          name: 'Incaltaminte',
          filePath: 'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_71.jpg',
          subCategories: [
            {
              id: 12,
              name: 'Ghete',
              filePath:
                'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_98.jpg',
            },
            {
              id: 122,
              name: 'Pantofi',
              filePath:
                'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_72.jpg',
            },
            {
              id: 123,
              name: 'Incaltaminte Sport',
              filePath:
                'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_74.jpg',
            },
          ],
        },
        {
          id: 25,
          name: 'Imbracaminte',
          filePath: 'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_88.jpg',
          subCategories: [
            {
              id: 212,
              name: 'Bluze',
              filePath:
                'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_117.jpg',
            },
            {
              id: 222,
              name: 'Trening',
              filePath:
                'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_161.jpg',
            },
            {
              id: 223,
              name: 'Camasi',
              filePath:
                'https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_123.jpg',
            },
          ],
        },
      ],
    },
    {
      id: 2,
      name: 'Articole Femei',
      filePath: 'https://50style.ro/media/cache/gallery/rc/gvk1dj5d/nike-bluza-cu-gluga-w-nsw-flc-gx-fnl-ftra-femei-bluze-negru-dd5836-010.jpg',
    },
    {
      id: 3,
      name: 'Articole copii',
      filePath: 'https://media1.popsugar-assets.com/files/thumbor/ICuFJn7n3UUD1dhvWoO0JVCpuQw/fit-in/728xorig/filters:format_auto-!!-:strip_icc-!!-/2021/10/06/913/n/24155406/5ff37d40615e0d3ed75611.77240046_/i/best-free-assembly-kids-clothes-at-walmart.jpg',
    },
    {
      id: 4,
      name: 'Articole generale',
      filePath: 'https://cdn.shopify.com/s/files/1/0049/4423/2534/products/hosi-1_789bc507-8604-4b21-9edb-d8a56549730c_grande.jpg?v=1603186636',
    },
  ];
  constructor(public http:HttpClient) {}

  categoriesBaseApi = "https://localhost:44350/Category";

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.categoriesBaseApi);
  }

  getCategoryById(id: number): Observable<Category> {
    return this.http.get<Category>(this.categoriesBaseApi+"/"+id);
  }

  addCategory(dto:FormData){
    console.log(dto);
  }
  addSubCategory(dto:FormData,categoryId:number){
    console.log(dto);
    console.log("pt categoria " + categoryId);
  }
}
