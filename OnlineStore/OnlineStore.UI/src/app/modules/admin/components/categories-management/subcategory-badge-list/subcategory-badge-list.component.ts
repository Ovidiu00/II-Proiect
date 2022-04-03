import { Component, Input, OnInit } from '@angular/core';
import { Category } from 'src/app/modules/catalog/models/category.model';

@Component({
  selector: 'app-subcategory-badge-list',
  templateUrl: './subcategory-badge-list.component.html',
  styleUrls: ['./subcategory-badge-list.component.css']
})
export class SubcategoryBadgeListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input()
  subCategories:Category[];

}


