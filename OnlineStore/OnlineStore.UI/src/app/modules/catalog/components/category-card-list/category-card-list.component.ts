import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Category } from '../../models/category.model';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-category-card-list',
  templateUrl: './category-card-list.component.html',
  styleUrls: ['./category-card-list.component.css']
})
export class CategoryCardListComponent implements OnInit {

  constructor(public activatedRoute:ActivatedRoute,public categoryService : CategoryService) { }

  @Input()
  categories$ : Observable<Category[]>

  ngOnInit(): void {

    var categoryId:number;
    this.activatedRoute.paramMap.subscribe(params => {
      categoryId = Number(params.get('id'));
      console.log(categoryId);
      var activatedCategory:Category;
      this.categoryService.getCategoryById(categoryId).subscribe( (category) => activatedCategory = category);


      this.categories$ = of(activatedCategory.subCategories);
    });

  }

}
