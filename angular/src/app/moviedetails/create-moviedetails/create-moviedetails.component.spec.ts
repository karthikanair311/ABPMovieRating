import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateMoviedetailsComponent } from './create-moviedetails.component';

describe('CreateMoviedetailsComponent', () => {
  let component: CreateMoviedetailsComponent;
  let fixture: ComponentFixture<CreateMoviedetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateMoviedetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateMoviedetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
