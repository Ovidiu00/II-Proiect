import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Product } from '../../../../catalog/models/product.model';
import { ProductsService } from '../../../../catalog/services/products.service';
import { ProductDialogComponent } from '../product-dialog/product-dialog.component';

@Component({
  selector: 'app-admin-product-card',
  templateUrl: './admin-product-card.component.html',
  styleUrls: ['./admin-product-card.component.css']
})
export class AdminProductCardComponent implements OnInit {

  constructor(
    public dialog: MatDialog,
    public productService:ProductsService
    ) { }

  @Input()
  product:Product;

  ngOnInit(): void {
  }

  @Output()
  public productSelected : EventEmitter<number> = new EventEmitter<number>();
  onDeleteClicked(){

    this.productService.deleteProduct(this.product.id);
  }
  onEditClicked(){
    const dialogRef = this.dialog.open(ProductDialogComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.saveClicked){
        this.productService.editProduct(result.dto);
      }
    });
  }
}