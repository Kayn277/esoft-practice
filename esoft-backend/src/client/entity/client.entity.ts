import { Column, Entity } from "typeorm";
import { TextEncoder } from "util";

@Entity()
export class Client {
    @Column({type: 'int', generated: 'increment', primary: true})
    id: number;
    
    @Column({type: 'varchar', length: 55, nullable: true})
    lastName: string;

    @Column({type: 'varchar', length: 55, nullable: true})
    firstName: string;

    @Column({type: 'varchar', length: 25555, nullable: true})
    middleName: string;

    @Column({type: 'varchar', length: 11, nullable: true})
    telephone: string;

    @Column({type: 'varchar', length: 255, nullable: true})
    email: string;
}
