import { Body, Controller, Delete, Get, Param, Post, Put } from '@nestjs/common';
import { FindManyOptions, SaveOptions } from 'typeorm';
import { RieltorDTO } from './dto/rieltor.dto';
import { Rieltor } from './entity/rieltor.entity';
import { RieltorService } from './rieltor.service';

@Controller('rieltor')
export class RieltorController {
    constructor(private readonly rieltorService: RieltorService) {
        
    }
    @Get('/all')
    async getAll(@Param() options: FindManyOptions<Rieltor>) {
        return await this.rieltorService.getAll(options);
    }

    @Get('/:id')
    async getOne(@Param('id') id: number, @Param() options: FindManyOptions<Rieltor>) {
        return await this.rieltorService.getOneById(id,options);
    }

    @Get('/:key')
    async getAllByKey(@Param('key') key: keyof Rieltor, @Param() options: FindManyOptions<Rieltor>) {
        return await this.rieltorService.getAllByKey(key, options);
    }

    @Post()
    async createOne(@Body() rieltor: RieltorDTO, @Param() options: SaveOptions) {
        console.log(rieltor);
        return await this.rieltorService.createOne(rieltor as Rieltor, options);
    }

    @Post('/all')
    async createAll(@Body() rieltor: RieltorDTO[], @Param() options: SaveOptions) {
        return await this.rieltorService.createAll(rieltor as Rieltor[], options);
    }
    
    @Delete('/:id')
    async deleteOne(@Param('id') id) {
        return await this.rieltorService.delete(id);
    }
    @Put()
    async updateOne(@Body() rieltor: RieltorDTO) {
        return await this.rieltorService.updateOne(rieltor as Rieltor);
    }

}
