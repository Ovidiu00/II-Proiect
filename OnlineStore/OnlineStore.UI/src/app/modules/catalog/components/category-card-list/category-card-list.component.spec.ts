import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryCardListComponent } from './category-card-list.component';

describe('CategoryCardListComponent', () => {
  let component: CategoryCardListComponent;
  let fixture: ComponentFixture<CategoryCardListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryCardListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryCardListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
