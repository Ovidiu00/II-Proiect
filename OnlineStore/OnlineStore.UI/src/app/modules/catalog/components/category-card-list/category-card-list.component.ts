import { Component, HostBinding, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Category } from '../../models/category.model';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-category-card-list',
  templateUrl: './category-card-list.component.html',
  styleUrls: ['./category-card-list.component.css']
})
export class CategoryCardListComponent implements OnInit {

  constructor(
    public activatedRoute:ActivatedRoute,
    public categoryService : CategoryService,
    public router:Router) { }

  @Input()
  categories$ : Observable<Category[]>
  selectedCategory:Category;
  
  @HostBinding('class.show-view') 
  showView: boolean = false;
  ngAfterViewInit(){
    this.showView = true;
  }

  ngOnInit(): void {
    var categoryId:number;
    this.activatedRoute.paramMap.subscribe(params => {
      categoryId = Number(params.get('id'));
      if(categoryId){
        this.categoryService.getCategoryById(categoryId).subscribe( (category) =>
         {
           this.selectedCategory = category
          console.log(category);


          if(this.selectedCategory?.subCategories.length == 0){

            this.router.navigate(["products"],{relativeTo:this.activatedRoute});
          }

          this.categories$ = of(this.selectedCategory?.subCategories);

         });
      }
    });

  }

}
