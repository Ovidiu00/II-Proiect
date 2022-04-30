import { Directive, HostListener } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { OrderHistoryDialogComponent } from './order-history-dialog/order-history-dialog.component';

@Directive({
  selector: '[appOrdersHistory]'
})
export class OrdersHistoryDirective {

  constructor(public dialog: MatDialog) {}

  @HostListener('click')
  openDialog(): void {
    const dialogRef = this.dialog.open(OrderHistoryDialogComponent, {
      width: '1100px',
    });
  }
}
