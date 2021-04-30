import { TestBed } from '@angular/core/testing';

import { BurritoService } from './burrito.service';

describe('BurritoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BurritoService = TestBed.get(BurritoService);
    expect(service).toBeTruthy();
  });
});
