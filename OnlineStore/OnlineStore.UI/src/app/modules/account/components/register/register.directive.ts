import { Directive, HostListener } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AccountService } from '../../services/account.service';
import { RegisterDialogComponent } from './register-dialog/register-dialog.component';

@Directive({
  selector: '[appRegister]'
})
export class RegisterDirective {

  constructor(public dialog: MatDialog,private accountService:AccountService) {}

  @HostListener('click')
  openDialog(): void {
    const dialogRef = this.dialog.open(RegisterDialogComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result)
       this.accountService.register(result).subscribe();
    });
  }
}
