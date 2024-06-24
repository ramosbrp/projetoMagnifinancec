import { Disciplina } from "./disciplina.model";

export class Professor{
    Id!: number;
    Nome!: string;
    DataNascimento?: Date;
    Salario?: number;
    Disciplinas?: Disciplina[];
}