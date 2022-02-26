import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubCategoriesTooltipComponent } from './sub-categories-tooltip.component';

describe('SubCategoriesTooltipComponent', () => {
  let component: SubCategoriesTooltipComponent;
  let fixture: ComponentFixture<SubCategoriesTooltipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubCategoriesTooltipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubCategoriesTooltipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
