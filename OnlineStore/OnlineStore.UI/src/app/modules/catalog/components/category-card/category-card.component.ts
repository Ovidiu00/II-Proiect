import { Component, Input, OnInit } from '@angular/core';
import { Category } from '../../models/category.model';

@Component({
  selector: 'app-category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.css']
})
export class CategoryCardComponent implements OnInit {

  constructor() {}

  ngOnInit(): void {
  }

  @Input()
  public category: Category;

  status: boolean = false;
  mouseHover() {
    this.status = !this.status;
  }
}
