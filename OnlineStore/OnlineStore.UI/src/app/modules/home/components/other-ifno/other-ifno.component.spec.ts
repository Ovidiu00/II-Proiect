import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtherIfnoComponent } from './other-ifno.component';

describe('OtherIfnoComponent', () => {
  let component: OtherIfnoComponent;
  let fixture: ComponentFixture<OtherIfnoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OtherIfnoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OtherIfnoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
