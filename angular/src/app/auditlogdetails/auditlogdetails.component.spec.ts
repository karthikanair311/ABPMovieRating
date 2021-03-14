import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditlogdetailsComponent } from './auditlogdetails.component';

describe('AuditlogdetailsComponent', () => {
  let component: AuditlogdetailsComponent;
  let fixture: ComponentFixture<AuditlogdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuditlogdetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditlogdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
