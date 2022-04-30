import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { faArchive, faBars, faShoppingCart, faSignInAlt, faUser } from '@fortawesome/free-solid-svg-icons';
import { UserModel } from '../../modules/account/models/user.model';
import { AccountService } from '../../modules/account/services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  @Output() public sidenavToggle = new EventEmitter();

  constructor(private accountService: AccountService) {}

  faSignIn = faSignInAlt;
  faUser = faUser;
  faCart = faShoppingCart;
  faOrders = faBars;
  public loggedInUser: UserModel;
  ngOnInit(): void {
    this.loggedInUser = this.accountService.getLoggedInUser();
    this.accountService.isLoggedIn$.subscribe((res) => this.login(res));
  }

  login(result: boolean) {
    if (result) this.loggedInUser = this.accountService.getLoggedInUser();
    else this.loggedInUser = null;
  }
  logout() {
    this.accountService.logout();
  }

  public onlineStoreName: string = 'Default  NameNameName';

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  };
}
