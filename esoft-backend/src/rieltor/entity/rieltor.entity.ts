import { Column, Entity } from "typeorm";

@Entity()
export class Rieltor {
    @Column({type: 'int', generated: 'increment', primary: true})
    id: number;
    
    @Column({type: 'varchar', length: 55, nullable: false})
    lastName: string;

    @Column({type: 'varchar', length: 55, nullable: false})
    firstName: string;

    @Column({type: 'varchar', length: 25555, nullable: false})
    middleName: string;

    @Column({type: 'int',})
    comission: number;

}
