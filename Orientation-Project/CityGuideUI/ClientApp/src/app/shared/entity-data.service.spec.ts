import { TestBed } from '@angular/core/testing';

import { EntityDataService } from './entity-data.service';

describe('EntityDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EntityDataService = TestBed.get(EntityDataService);
    expect(service).toBeTruthy();
  });
});
