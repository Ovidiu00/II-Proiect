import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoryDropdownListService {
  private visible = new Subject<boolean>();

  public hide() {
    this.visible.next(false);
  }
  public isVisible(): Observable<boolean> {
    return this.visible.asObservable();
  }
  public show() {
    this.visible.next(true);
  }
  constructor() {}
}
