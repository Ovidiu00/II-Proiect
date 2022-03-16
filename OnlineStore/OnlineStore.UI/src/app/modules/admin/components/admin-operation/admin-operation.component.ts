import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-operation',
  templateUrl: './admin-operation.component.html',
  styleUrls: ['./admin-operation.component.css']
})
export class AdminOperationComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input()
  public title:string;

}
