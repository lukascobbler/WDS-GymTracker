import { TestBed } from '@angular/core/testing';

import { TrainingTypeService } from './training-type.service';

describe('TrainingTypeService', () => {
  let service: TrainingTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainingTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
