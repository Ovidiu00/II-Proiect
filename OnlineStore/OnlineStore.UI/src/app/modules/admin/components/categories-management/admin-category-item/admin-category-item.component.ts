import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from 'src/app/modules/catalog/models/category.model';

@Component({
  selector: 'app-admin-category-item',
  templateUrl: './admin-category-item.component.html',
  styleUrls: ['./admin-category-item.component.css'],
})
export class AdminCategoryItemComponent implements OnInit {
  constructor() {}

  @Input()
  public image: string;

  ngOnInit(): void {
    if (this.category.subCategories.length)
      this.categoryContainsSubCategories = true;

  }

  @Input()
  category: Category;

  @Output()
  categoryDeleted: EventEmitter<any> = new EventEmitter<any>();

  @Output()
  categoryEdited: EventEmitter<any> = new EventEmitter<any>();

  public categoryContainsSubCategories: boolean;

  onDeleteClicked() {
    this.categoryDeleted.emit(this.category.id);
  }
  onEditClicked() {
    this.categoryEdited.emit(this.category.id);
  }
}
