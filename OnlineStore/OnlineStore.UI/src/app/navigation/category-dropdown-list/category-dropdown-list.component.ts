import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from 'src/app/modules/catalog/models/category.model';
import { CategoryDropdownListService } from '../category-dropdown-list.service';

@Component({
  selector: 'app-category-dropdown-list',
  templateUrl: './category-dropdown-list.component.html',
  styleUrls: ['./category-dropdown-list.component.css'],
})
export class CategoryDropdownListComponent implements OnInit {
  constructor(public service: CategoryDropdownListService) {}

  public isComponentVisible: boolean = true;
  ngOnInit(): void {
     this.service.isVisible().subscribe(x => this.isComponentVisible = x);
  }

  @Input()
  public categories$ :Observable<Category[]>;
}
