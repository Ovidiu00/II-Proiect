import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderHistoryDialogComponent } from './order-history-dialog.component';

describe('OrderHistoryDialogComponent', () => {
  let component: OrderHistoryDialogComponent;
  let fixture: ComponentFixture<OrderHistoryDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderHistoryDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderHistoryDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
