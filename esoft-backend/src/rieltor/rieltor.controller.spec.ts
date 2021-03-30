import { Test, TestingModule } from '@nestjs/testing';
import { RieltorController } from './rieltor.controller';

describe('RieltorController', () => {
  let controller: RieltorController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [RieltorController],
    }).compile();

    controller = module.get<RieltorController>(RieltorController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
