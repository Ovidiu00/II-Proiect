import { Component, OnInit, Output, EventEmitter, HostListener, Input } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';


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

  public faSearch = faSearch;

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
}
