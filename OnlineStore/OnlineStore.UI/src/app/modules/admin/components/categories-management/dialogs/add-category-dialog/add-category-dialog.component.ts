import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogResult } from 'src/app/modules/admin/models/dialog-result.model';
import { Category } from 'src/app/modules/catalog/models/category.model';

@Component({
  selector: 'app-add-category-dialog',
  templateUrl: './add-category-dialog.component.html',
  styleUrls: ['./add-category-dialog.component.css'],
})
export class AddCategoryDialogComponent implements OnInit {
  constructor(
    @Inject(MAT_DIALOG_DATA) public category: Category,
    public dialogRef: MatDialogRef<AddCategoryDialogComponent>) {}

  ngOnInit(): void {}

  onExitClick() {
    this.dialogRef.close();
  }
  onSaveClick(files: any, name: string) {
    var dialogResult: DialogResult = new DialogResult();
    dialogResult.dto = this.constructFormData(files, name);
    dialogResult.saveClicked = true;

    this.dialogRef.close(dialogResult);
  }

  private constructFormData(files: any, name: string): FormData {
    if (files.length === 0) return null;

    const formData = new FormData();
    for (const file of files) {
      formData.append('file', file);
    }

    formData.append('name', name);
    return formData;
  }
}
