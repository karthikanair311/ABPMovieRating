import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditActordetailsComponent } from './edit-actordetails.component';

describe('EditActordetailsComponent', () => {
  let component: EditActordetailsComponent;
  let fixture: ComponentFixture<EditActordetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditActordetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditActordetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
