import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMoviedetailsComponent } from './edit-moviedetails.component';

describe('EditMoviedetailsComponent', () => {
  let component: EditMoviedetailsComponent;
  let fixture: ComponentFixture<EditMoviedetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditMoviedetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditMoviedetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
