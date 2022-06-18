import { TestBed } from '@angular/core/testing';

import { AirlinescheduleService } from './airlineschedule.service';

describe('AirlinescheduleService', () => {
  let service: AirlinescheduleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AirlinescheduleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
