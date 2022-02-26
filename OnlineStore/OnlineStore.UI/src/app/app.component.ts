import {Component, OnInit} from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from './modules/catalog/models/category.model';
import { CategoryService } from './modules/catalog/services/category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit {
  title = 'ang-material-owneraccount';

  constructor(public categoryService : CategoryService) {
  }

  public categories$ : Observable<Category[]>;
  ngOnInit(): void {
      this.categories$ = this.categoryService.getCategories();
  }
}
