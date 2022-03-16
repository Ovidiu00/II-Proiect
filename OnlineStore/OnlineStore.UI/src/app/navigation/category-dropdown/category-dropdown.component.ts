import { Component, Input, OnInit } from '@angular/core';
import { Category } from 'src/app/modules/catalog/models/category.model';

@Component({
  selector: 'app-category-dropdown',
  templateUrl: './category-dropdown.component.html',
  styleUrls: ['./category-dropdown.component.css'],
})
export class CategoryDropdownComponent implements OnInit {
  constructor() {}

  @Input()
  public category: Category;

  ngOnInit(): void {}

  public showSubCategories: boolean = false;
  public toolTipHovered: boolean = false;

  showToolTip() {
    if(this.category?.subCategories.length != 0)
    this.showSubCategories = true;
  }
  hideToolTip() {

        this.showSubCategories = this.toolTipHovered;

  }
}
