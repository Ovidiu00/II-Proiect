import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { RegisterModel } from '../../../models/register-model';

@Component({
  selector: 'app-register-dialog',
  templateUrl: './register-dialog.component.html',
  styleUrls: ['./register-dialog.component.css']
})
export class RegisterDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<RegisterDialogComponent>) { }

  ngOnInit(): void {
  }

  onExitClick(): void {
    this.dialogRef.close();
  }

  onRegisterClick(username:string,password:string,nume:string,prenume:string): void {
    this.dialogRef.close(new RegisterModel(username,password,nume,prenume));
  }

}
