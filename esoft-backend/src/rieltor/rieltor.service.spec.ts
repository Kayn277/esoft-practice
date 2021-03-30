import { Test, TestingModule } from '@nestjs/testing';
import { RieltorService } from './rieltor.service';

describe('RieltorService', () => {
  let service: RieltorService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [RieltorService],
    }).compile();

    service = module.get<RieltorService>(RieltorService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
