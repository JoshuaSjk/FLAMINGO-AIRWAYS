import { TestBed } from '@angular/core/testing';
import { SearchFlightDetailsService } from './search-flight-details.service';

describe('SearchFlightDetailsService', () => {
  let service: SearchFlightDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchFlightDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
