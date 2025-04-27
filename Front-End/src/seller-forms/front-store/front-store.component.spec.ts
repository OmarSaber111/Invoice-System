import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FrontStoreComponent } from './front-store.component';

describe('FrontStoreComponent', () => {
  let component: FrontStoreComponent;
  let fixture: ComponentFixture<FrontStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FrontStoreComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FrontStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
