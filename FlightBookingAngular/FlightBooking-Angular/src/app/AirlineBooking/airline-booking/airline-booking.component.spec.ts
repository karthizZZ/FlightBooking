import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirlineBookingComponent } from './airline-booking.component';

describe('AirlineBookingComponent', () => {
  let component: AirlineBookingComponent;
  let fixture: ComponentFixture<AirlineBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AirlineBookingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AirlineBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
