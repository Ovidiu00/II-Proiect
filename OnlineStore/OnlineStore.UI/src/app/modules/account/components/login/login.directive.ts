import { Directive, HostListener } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AccountService } from '../../services/account.service';
import { LoginDialogComponent } from './login-dialog/login-dialog.component';

@Directive({
  selector: '[appLogin]'
})
export class LoginDirective {

  constructor(public dialog: MatDialog,public accountService:AccountService) {}

  @HostListener('click')
  openDialog(): void {
    const dialogRef = this.dialog.open(LoginDialogComponent, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {

      if(result){
          this.accountService.login(result);
      }
    });
  }
}
