import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from 'src/app/modules/catalog/models/category.model';

@Component({
  selector: 'app-sub-categories-tooltip',
  templateUrl: './sub-categories-tooltip.component.html',
  styleUrls: ['./sub-categories-tooltip.component.css']
})
export class SubCategoriesTooltipComponent implements OnInit {

  constructor() { }

  @Output()
  public mouseEnter:EventEmitter<void> = new EventEmitter()

  @Output()
  public mouseLeave:EventEmitter<void> = new EventEmitter()

  ngOnInit(): void {
  }

  @Input()
  public show:boolean = false;
  @Input()
  public subCategories:Category[];

  onMouseEntered(){
    this.mouseEnter.emit();
  }
  onMouseLeave(){
    this.mouseLeave.emit();
  }
}
