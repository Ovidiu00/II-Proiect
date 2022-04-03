import { Component, Input, OnInit } from '@angular/core';
import { Category } from '../../models/category.model';

@Component({
  selector: 'app-category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.css']
})
export class CategoryCardComponent implements OnInit {

  constructor() {}

  public image:string;
  ngOnInit(): void {
    this.image = this.category.filePath;
    if(this.category.filePath.indexOf("http") == -1)
       this.image = "http://localhost:4200/assets/images/" + this.category.filePath;
  }

  @Input()
  public category: Category;

  status: boolean = false;
  mouseHover() {
    this.status = !this.status;
  }
}
