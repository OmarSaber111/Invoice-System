import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyerInvoicesComponent } from './buyer-invoices.component';

describe('BuyerInvoicesComponent', () => {
  let component: BuyerInvoicesComponent;
  let fixture: ComponentFixture<BuyerInvoicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BuyerInvoicesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BuyerInvoicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
