import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Category } from './modules/catalog/models/category.model';
import { CategoryService } from './modules/catalog/services/category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Foo';

  constructor(public categoryService: CategoryService,public router:Router) {}

  public categories$: Observable<Category[]>;

    ngOnInit(): void {
      this.categories$ = this.categoryService.getCategories();

  }

  onActivate(event: any) {

    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
          const contentContainer = document.querySelector('.mat-sidenav-content');
          contentContainer.scrollTo(0, 0);
      }
  });
  }
}
