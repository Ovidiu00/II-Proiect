import { Directive, HostListener } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CartItemsDialogComponent } from './cart-items-dialog/cart-items-dialog.component';

@Directive({
  selector: '[appCart]'
})
export class CartDirective {

  constructor(public dialog: MatDialog) {}

  @HostListener('click')
  openDialog(): void {
    const dialogRef = this.dialog.open(CartItemsDialogComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result)
      console.log("order clicked")
    });
  }
}
