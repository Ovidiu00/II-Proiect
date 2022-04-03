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
  styleUrls: ['./admin-category-list.component.css'],
})
export class AdminCategoryListComponent implements OnInit, OnDestroy {
  constructor(
    public activatedRoute: ActivatedRoute,
    public categoryService: CategoryService,
    public dialog: MatDialog,
    public categoryDropDownService: CategoryDropdownListService
  ) {}

  selectedCategory: Category;
  public emptySubCategories: boolean;

  public isBaseCategoriesView: boolean = true;

  public categories: Category[];
  private categoryId: number;

  ngOnInit(): void {
    this.categoryDropDownService.hide();

    this.activatedRoute.paramMap.subscribe((params) => {
      this.categoryId = Number(params.get('categoryId'));
      if (this.categoryId) {
        this.categoryService
          .getCategoryById(this.categoryId)
          .subscribe((category) => {
            this.selectedCategory = category;
            this.categories = this.selectedCategory?.subCategories;

            if (!this.categories) {
              this.emptySubCategories = true;
            }
          });
        this.isBaseCategoriesView = false;
      } else {
        this.categoryService.getCategories().subscribe((res) => {
          this.categories = res;
          this.isBaseCategoriesView = true;
        });
      }
    });
  }

  ngOnDestroy(): void {
    this.categoryDropDownService.show();
  }

  addCategoryClicked() {
    const dialogRef = this.dialog.open(AddCategoryDialogComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result.saveClicked)
        this.handleAddProductDialogSaveClicked(result.dto);
    });
  }

  private handleAddProductDialogSaveClicked(dto: FormData) {
    this.categoryService.addCategory(dto).subscribe((result: Category) => {
      if (!this.isBaseCategoriesView) {
        this.categoryService
          .addSubCategory(this.categoryId, result.id)
          .subscribe();
      }
      this.categories.push(result);
    });
  }

  deleteCategory(categoryId: number) {
    this.categoryService.deleteCategory(categoryId).subscribe(() => {
      this.categories = this.categories.filter((x) => x.id !== categoryId);
    });
  }
  editCategory(categoryId: number) {
    const dialogRef = this.dialog.open(AddCategoryDialogComponent, {
      width: '300px',
      data: this.categories.find((x) => x.id == categoryId),
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result.saveClicked) {
        console.log(result.dto.get('name'));
        this.categoryService
          .editCategory(result.dto, categoryId)
          .subscribe((apiResult) => {
            var categoryEdited = this.categories.find(
              (x) => x.id == apiResult.id
            );
            categoryEdited.name = apiResult.name;
            categoryEdited.filePath = apiResult.filePath;

            console.log(categoryEdited);
          });
      }
    });
  }
  getCategoryImage(category: Category): string {
    var image = category.filePath;
    if (category.filePath.indexOf('http') == -1)
      image = 'http://localhost:4200/assets/images/' + category.filePath;
    return image;
  }
}
