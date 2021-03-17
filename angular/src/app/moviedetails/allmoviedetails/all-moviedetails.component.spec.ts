import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllMoviedetailsComponent } from './all-moviedetails.component';

describe('AllMoviedetailsComponent', () => {
  let component: AllMoviedetailsComponent;
  let fixture: ComponentFixture<AllMoviedetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllMoviedetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllMoviedetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
