import { Module } from '@nestjs/common';
import { RieltorService } from './rieltor.service';
import { RieltorController } from './rieltor.controller';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Rieltor } from './entity/rieltor.entity';

@Module({
  imports: [TypeOrmModule.forFeature([Rieltor])],
  providers: [RieltorService],
  controllers: [RieltorController],
  exports: [RieltorService]
})
export class RieltorModule {}
