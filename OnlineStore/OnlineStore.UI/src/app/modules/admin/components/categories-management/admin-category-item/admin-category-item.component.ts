import { Component, Input, OnInit } from '@angular/core';
import { Category } from 'src/app/modules/catalog/models/category.model';

@Component({
  selector: 'app-admin-category-item',
  templateUrl: './admin-category-item.component.html',
  styleUrls: ['./admin-category-item.component.css']
})
export class AdminCategoryItemComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    if(this.category.subCategories)
        this.categoryContainsSubCategories = true;
  }

  @Input()
  category:Category;


  public categoryContainsSubCategories:boolean;

  onDeleteClicked(){

  }
  onEditClicked(){

  }


}


