import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Product } from '../../../../catalog/models/product.model';
import { ProductsService } from '../../../../catalog/services/products.service';
import { CategoryDropdownListService } from 'src/app/navigation/category-dropdown-list.service';
import { MatDialog } from '@angular/material/dialog';
import { ProductDialogComponent } from '../product-dialog/product-dialog.component';

@Component({
  selector: 'app-admin-product-list',
  templateUrl: './admin-product-list.component.html',
  styleUrls: ['./admin-product-list.component.css'],
})
export class AdminProductListComponent implements OnInit,OnDestroy {
  constructor(
    public productService: ProductsService,
    public router: Router,
    public activatedRoute: ActivatedRoute,
    public dialog: MatDialog,
    public categoryDropdownService:CategoryDropdownListService
  ) {}

  @Input()
  products$: Observable<Product[]>;

  private categoryId:number;
  ngOnInit(): void {
    this.categoryDropdownService.hide();

    this.activatedRoute.paramMap.subscribe((params) => {
      this.categoryId = Number(params.get('categoryId'));
      if (this.categoryId) {
        this.products$ = this.productService.getProductsForCategory(this.categoryId);
      }
    });
  }

  ngOnDestroy(){

    this.categoryDropdownService.show();
  }
  selectProduct(id: number) {
    this.router.navigate(['catalog/produs/' + id]);
  }
  addProductClicked(){
    const dialogRef = this.dialog.open(ProductDialogComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.saveClicked)
       this.handleAddProductDialogSaveClicked(result.dto)
    });
  }
  private handleAddProductDialogSaveClicked(dto:FormData){
    this.productService.addProduct(dto,this.categoryId).subscribe(x => this.refreshData())
  }
  refreshData(){
    this.products$ = this.productService.getProductsForCategory(this.categoryId);

  }
}
