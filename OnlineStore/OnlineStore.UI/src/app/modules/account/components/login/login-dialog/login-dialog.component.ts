import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { LoginModel } from '../../../models/login-model';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.css']
})
export class LoginDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<LoginDialogComponent>) { }

  ngOnInit(): void {
  }

  onExitClick(): void {
    this.dialogRef.close();
  }

  onLoginClick(email:string,password:string): void {
    this.dialogRef.close(new LoginModel(email,password));
  }
}
