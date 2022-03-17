import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/modules/catalog/models/category.model';
import { CategoryService } from 'src/app/modules/catalog/services/category.service';
import { CategoryDropdownListService } from 'src/app/navigation/category-dropdown-list.service';
import { AddCategoryDialogComponent } from '../dialogs/add-category-dialog/add-category-dialog.component';

@Component({
  selector: 'app-admin-category-list',
  templateUrl: './admin-category-list.component.html',
  styleUrls: ['./admin-category-list.component.css']
})
export class AdminCategoryListComponent implements OnInit,OnDestroy {

  constructor(
    public activatedRoute:ActivatedRoute,
    public categoryService:CategoryService,
    public dialog: MatDialog,
    public categoryDropDownService:CategoryDropdownListService
    ) { }

    selectedCategory:Category;

    public isBaseCategoriesView :boolean= true;

    public categories: Category[];

  ngOnInit(): void {
    this.categoryDropDownService.hide();

    var categoryId:number;
    this.activatedRoute.paramMap.subscribe(params => {
      categoryId = Number(params.get('categoryId'));
      if(categoryId){
        this.categoryService.getCategoryById(categoryId).subscribe( (category) =>
        {
          this.selectedCategory = category;
          this.categories = this.selectedCategory?.subCategories;
        });
        this.isBaseCategoriesView = false;
      }
      else{
        this.categoryService.getCategories().subscribe(res => {this.categories = res;this.isBaseCategoriesView=true});

      }
    });
  }
  ngOnDestroy(): void {
      this.categoryDropDownService.show();
  }

  addCategoryClicked(){
    const dialogRef = this.dialog.open(AddCategoryDialogComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.saveClicked)
       this.handleDialogSaveClicked(result.dto)
    });

  }

  private handleDialogSaveClicked(dto:FormData){
    if(this.isBaseCategoriesView)
        this.categoryService.addCategory(dto);
        else{
          this.categoryService.addSubCategory(dto,this.selectedCategory.id);
        }
  }
}
