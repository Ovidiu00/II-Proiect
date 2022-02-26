import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  public categories : Category[] = [
    {
      id :1,
      name : "Articole Barbati",
      photo : "https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_88.jpg",
      description: "Haine barbati puternici",
      subCategories: [
        {
          id:24,
          name:"Incaltaminte",
          photo:"https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_71.jpg",
          description :"Incaltaminte pentru picioarele tale",
          subCategories : [
            {
              id :12,
              name : "Ghete",
              photo : "https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_98.jpg",
            },
            {
              id :122,
              name : "Pantofi",
              photo : "https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_72.jpg",
            },
            {
              id :123,
              name : "Incaltaminte Sport",
              photo : "https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_74.jpg",
            },
          ]

        },
        {
          id:25,
          name:"Imbracaminte",
          photo:"https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_71.jpg",
          description :"Imbracaminte pentru corpul tau",
          subCategories : [
            {
              id :212,
              name : "Bluze",
              photo : "https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_117.jpg",
            },
            {
              id :222,
              name : "Trening",
              photo : "https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_161.jpg",
            },
            {
              id :223,
              name : "Camasi",
              photo : "https://s.cdnmpro.com/431827071/custom/cat/cat_thumb_123.jpg",
            },
          ]

        }
      ]

    },
    {
      id :2,
      name : "Articole Femei",
      photo : "https://scontent.fomr1-1.fna.fbcdn.net/v/t1.15752-9/p1080x2048/269173873_353017836157334_3689338577468909169_n.jpg?_nc_cat=107&ccb=1-5&_nc_sid=ae9488&_nc_ohc=cO_29h50hMMAX_9RFo_&_nc_ht=scontent.fomr1-1.fna&oh=03_AVKiwC3hN67soKmERj-qHhjuWlofukWTOKOF3kqxwq4bJQ&oe=61F40F25",
      description: "Haine femei puternice"
    },
    {
      id :3,
      name : "Articole copii",
      photo : "https://scontent.fomr1-1.fna.fbcdn.net/v/t1.15752-9/269806032_821349505925119_592029479524565391_n.jpg?_nc_cat=105&ccb=1-5&_nc_sid=ae9488&_nc_ohc=L7ysWxeklDIAX8mmQOO&_nc_ht=scontent.fomr1-1.fna&oh=03_AVJigHqKXmjONvDnQujeiO4jorgbqXzQuZCQ4Fmxeb43Kg&oe=61F6212E",
      description: "Haine copii puternici"
    },
    {
      id :4,
      name : "Articole generale",
      photo : "https://scontent.fomr1-1.fna.fbcdn.net/v/t1.15752-9/269806032_821349505925119_592029479524565391_n.jpg?_nc_cat=105&ccb=1-5&_nc_sid=ae9488&_nc_ohc=L7ysWxeklDIAX8mmQOO&_nc_ht=scontent.fomr1-1.fna&oh=03_AVJigHqKXmjONvDnQujeiO4jorgbqXzQuZCQ4Fmxeb43Kg&oe=61F6212E",
      description: "Chestii generale"
    }
  ]
  constructor() { }
  getCategories():Observable<Category[]>{

    return of(this.categories);
  }

  getCategoryById(id:number) : Observable<Category>{
    var mainCategory:Category =  this.categories.find(x => x.id == id)

    var found;
    if(!mainCategory){
      this.categories.forEach(category =>
        {
         var subCategoryFound:Category = category.subCategories?.find(x => x.id == id)

         if(subCategoryFound)
            found = subCategoryFound;

        })
    }
    else
    return of(mainCategory);

    return of(found);
  }
}
