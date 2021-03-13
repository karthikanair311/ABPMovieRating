import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMoviedetailsComponent } from './view-moviedetails.component';

describe('ViewMoviedetailsComponent', () => {
  let component: ViewMoviedetailsComponent;
  let fixture: ComponentFixture<ViewMoviedetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewMoviedetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewMoviedetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
