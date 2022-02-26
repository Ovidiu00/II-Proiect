import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryDropdownListComponent } from './category-dropdown-list.component';

describe('CategoryDropdownListComponent', () => {
  let component: CategoryDropdownListComponent;
  let fixture: ComponentFixture<CategoryDropdownListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoryDropdownListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryDropdownListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
