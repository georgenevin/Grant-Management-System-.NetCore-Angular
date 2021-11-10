import { TestBed } from '@angular/core/testing';

import { GrantprgmserviceService } from './grantprgmservice.service';

describe('GrantprgmserviceService', () => {
  let service: GrantprgmserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GrantprgmserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
