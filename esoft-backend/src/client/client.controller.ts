import { Body, Controller, Delete, Get, Param, Post, Put } from '@nestjs/common';
import { FindManyOptions, SaveOptions } from 'typeorm';
import { ClientService } from './client.service';
import { ClientDTO } from './dto/client.dto';
import { Client } from './entity/client.entity';

@Controller('client')
export class ClientController {

    constructor(private readonly clientService: ClientService) {
        
    }
    @Get('/all')
    async getAll(@Param() options: FindManyOptions<Client>) {
        return await this.clientService.getAll(options);
    }

    @Get('/:id')
    async getOne(@Param('id') id: number, @Param() options: FindManyOptions<Client>) {
        return await this.clientService.getOneById(id,options);
    }

    @Get('/:key')
    async getAllByKey(@Param('key') key: keyof Client, @Param() options: FindManyOptions<Client>) {
        return await this.clientService.getAllByKey(key, options);
    }

    @Post()
    async createOne(@Body() client: ClientDTO, @Param() options: SaveOptions) {
        console.log(client);
        return await this.clientService.createOne(client as Client, options);
    }

    @Post('/all')
    async createAll(@Body() client: ClientDTO[], @Param() options: SaveOptions) {
        return await this.clientService.createAll(client as Client[], options);
    }
    
    @Delete('/:id')
    async deleteOne(@Param('id') id) {
        return await this.clientService.delete(id);
    }
    @Put()
    async updateOne(@Body() client: ClientDTO) {
        return await this.clientService.updateOne(client as Client);
    }

    
}
