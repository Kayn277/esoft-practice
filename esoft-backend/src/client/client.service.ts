import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { FindManyOptions, Repository, SaveOptions } from 'typeorm';
import { Client } from './entity/client.entity';

@Injectable()
export class ClientService {

    constructor(@InjectRepository(Client) private clientRepository: Repository<Client>) {
        
    }

    async getAll(options: FindManyOptions<Client>) {
        const clients = this.clientRepository.find(options);
        return clients;
    }

    async getOneById(id: number,options?: FindManyOptions<Client>) {
        const client = this.clientRepository.findOne(id, options);
        return client;
    }

    async getAllByKey(client: keyof Client, options?: FindManyOptions<Client> ) {
        options.where = client;
        const clients = this.clientRepository.find(options);
        return clients;
    }

    async createOne(client: Client, options?: SaveOptions) {
        console.log(client);
        const clients = this.clientRepository.save(client, options);
        return clients;
    }

    async createAll(client: Client[], options?: SaveOptions) {
        const clients = this.clientRepository.save(client, options);
        return clients;
    }

    async updateOne(client: Client) {
        const clients = this.clientRepository.update(client.id, client);
        return clients;
    }

    async delete(id: number) {
        const clients = this.clientRepository.delete(id);
        return clients;
    }

    async deleteById(id: number) {
        const clients = this.clientRepository.delete(id);
        return clients;
    }

}
