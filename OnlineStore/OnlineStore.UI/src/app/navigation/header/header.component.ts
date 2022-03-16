import { Component, OnInit, Output, EventEmitter, HostListener, Input } from '@angular/core';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Output() public sidenavToggle = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  public onlineStoreName:string = "Default  NameNameName";


  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
}
