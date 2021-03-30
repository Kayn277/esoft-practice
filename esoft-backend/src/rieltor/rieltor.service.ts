import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { FindManyOptions, Repository, SaveOptions } from 'typeorm';
import { Rieltor } from './entity/rieltor.entity';

@Injectable()
export class RieltorService {

    constructor(@InjectRepository(Rieltor) private RieltorRepository: Repository<Rieltor>) {
        
    }

    async getAll(options: FindManyOptions<Rieltor>) {
        const rieltors = this.RieltorRepository.find(options);
        return rieltors;
    }

    async getOneById(id: number,options?: FindManyOptions<Rieltor>) {
        const rieltor = this.RieltorRepository.findOne(id, options);
        return rieltor;
    }

    async getAllByKey(rieltor: keyof Rieltor, options?: FindManyOptions<Rieltor> ) {
        options.where = rieltor;
        const rieltors = this.RieltorRepository.find(options);
        return rieltors;
    }

    async createOne(rieltor: Rieltor, options?: SaveOptions) {
        console.log(rieltor);
        const rieltors = this.RieltorRepository.save(rieltor, options);
        return rieltors;
    }

    async createAll(rieltor: Rieltor[], options?: SaveOptions) {
        const rieltors = this.RieltorRepository.save(rieltor, options);
        return rieltors;
    }

    async updateOne(rieltor: Rieltor) {
        const rieltors = this.RieltorRepository.update(rieltor.id, rieltor);
        return rieltors;
    }

    async delete(id: number) {
        const rieltors = this.RieltorRepository.delete(id);
        return rieltors;
    }

    async deleteById(id: number) {
        const rieltors = this.RieltorRepository.delete(id);
        return rieltors;
    }

}
