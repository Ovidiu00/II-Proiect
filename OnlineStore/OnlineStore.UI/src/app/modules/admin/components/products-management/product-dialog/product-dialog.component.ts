import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product } from 'src/app/modules/catalog/models/product.model';
import { DialogResult } from '../../../models/dialog-result.model';

@Component({
  selector: 'app-product-dialog',
  templateUrl: './product-dialog.component.html',
  styleUrls: ['./product-dialog.component.css']
})
export class ProductDialogComponent implements OnInit {

  constructor(
    @Inject(MAT_DIALOG_DATA) public product: Product,
    public dialogRef: MatDialogRef<ProductDialogComponent>) {}

  ngOnInit(): void {
  }


  @ViewChild('fileInput')
   files:any;

   @ViewChild('name')
   name:any;

   @ViewChild('price')
   price:any;

   @ViewChild('quantity')
   quantity:any;


   onExitClick() {
    this.dialogRef.close();
  }
  onSaveClick() {
    var dialogResult: DialogResult = new DialogResult();
    dialogResult.dto = this.constructFormData();
    dialogResult.saveClicked = true;

    this.dialogRef.close(dialogResult);
  }

  private constructFormData(): FormData {


    if (this.files.length === 0) return null;

    const formData = new FormData();
    for (const file of this.files) {
      formData.append('file', file);
    }

    formData.append('name', this.name.value);
    formData.append('price', this.name.value);
    formData.append('quantity', this.name.quantity);

    return formData;
  }

}
