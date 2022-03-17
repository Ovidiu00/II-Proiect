import { Component, OnDestroy, OnInit } from '@angular/core';
import { CategoryDropdownListService } from 'src/app/navigation/category-dropdown-list.service';

@Component({
  selector: 'app-admin-dashbord',
  templateUrl: './admin-dashbord.component.html',
  styleUrls: ['./admin-dashbord.component.css']
})
export class AdminDashbordComponent implements OnInit,OnDestroy {

  constructor(public categoryDropdownService:CategoryDropdownListService) { }

  ngOnInit(): void {
    this.categoryDropdownService.hide();
  }

  ngOnDestroy(): void{
    this.categoryDropdownService.show();
  }

}
