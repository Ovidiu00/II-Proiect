import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdressInfoComponent } from './adress-info.component';

describe('AdressInfoComponent', () => {
  let component: AdressInfoComponent;
  let fixture: ComponentFixture<AdressInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdressInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdressInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
