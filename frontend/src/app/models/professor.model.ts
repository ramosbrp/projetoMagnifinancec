import { Disciplina } from "./disciplina.model";

export class Professor{
    ProfessorId!: number;
    Nome!: string;
    DataNascimento!: Date;
    Salario!: number;
    Disciplinas!: Disciplina[];
}