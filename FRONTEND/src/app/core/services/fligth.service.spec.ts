import { TestBed } from '@angular/core/testing';

import { FligthService } from './fligth.service';

describe('FligthService', () => {
  let service: FligthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FligthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
