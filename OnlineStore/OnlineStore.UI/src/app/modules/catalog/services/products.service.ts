import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor() { }

  private products : Product[] = [
    {
      id:1,
      name: "Bluza pentru tricou",
      displayPhoto : "https://s1.cel.ro/images/mari/2020/10/31/bluza-dama-sport-zusss-bumbac-somon-777687.jpg",
      price : 179,
      description : 'Bluza foarte confortabila'
    },
    {
      id:2,
      name: "Papuci smecher",
      displayPhoto : "https://cdn.shopify.com/s/files/1/0302/4945/1653/products/RjaveNaslovna_1024x1024.jpg?v=1605518397",
      price : 102,
      description : 'Papuci foarte caldurosi'
    },
    {
      id:3,
      name: "Tricou smecher",
      displayPhoto : "https://static.thcdn.com/images/large/webp//productimg/1600/1600/12302898-1574807812314115.jpg",
      price : 67.2,
      description : 'Tricou bun'
    },
    {
      id:1,
      name: "Bluza pentru tricou",
      displayPhoto : "https://s1.cel.ro/images/mari/2020/10/31/bluza-dama-sport-zusss-bumbac-somon-777687.jpg",
      price : 179,
      description : 'Bluza foarte confortabila'
    },
    {
      id:2,
      name: "Papuci smecher",
      displayPhoto : "https://cdn.shopify.com/s/files/1/0302/4945/1653/products/RjaveNaslovna_1024x1024.jpg?v=1605518397",
      price : 102,
      description : 'Papuci foarte caldurosi'
    },
    {
      id:3,
      name: "Tricou smecher",
      displayPhoto : "https://static.thcdn.com/images/large/webp//productimg/1600/1600/12302898-1574807812314115.jpg",
      price : 67.2,
      description : 'Tricou bun'
    },
    {
      id:1,
      name: "Bluza pentru tricou",
      displayPhoto : "https://s1.cel.ro/images/mari/2020/10/31/bluza-dama-sport-zusss-bumbac-somon-777687.jpg",
      price : 179,
      description : 'Bluza foarte confortabila'
    },
    {
      id:2,
      name: "Papuci smecher",
      displayPhoto : "https://cdn.shopify.com/s/files/1/0302/4945/1653/products/RjaveNaslovna_1024x1024.jpg?v=1605518397",
      price : 102,
      description : 'Papuci foarte caldurosi'
    },
    {
      id:3,
      name: "Tricou smecher",
      displayPhoto : "https://static.thcdn.com/images/large/webp//productimg/1600/1600/12302898-1574807812314115.jpg",
      price : 67.2,
      description : 'Tricou bun'
    }

  ]
  getLatestProducts():Observable<Product[]>{

    return of(this.products.slice(0,4));
  }

  getMostPopularProducts():Observable<Product[]>{
    return of(this.products.slice(0,4));
  }

  getProductById(id:number):Observable<Product>
  {
    var product = this.products.find(x => x.id == id);
    return of(product);
  }
}
