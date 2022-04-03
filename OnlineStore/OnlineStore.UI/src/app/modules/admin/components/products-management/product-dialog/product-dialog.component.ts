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



   fileSelected:any;

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
    console.log(this.name);

    var dialogResult: DialogResult = new DialogResult();
    dialogResult.dto = this.constructFormData();
    dialogResult.saveClicked = true;

    this.dialogRef.close(dialogResult);

  }

  private constructFormData(): FormData {
    let formData = new FormData();

    formData.append('photo', this.fileSelected);
    formData.append('name', this.name.nativeElement.value);
    formData.append('price', this.price.nativeElement.value);
    formData.append('quantity', this.quantity.nativeElement.value);

    return formData;
  }
  onFileSelected(event:any){
    this.fileSelected = event.target.files[0];
  }

}
