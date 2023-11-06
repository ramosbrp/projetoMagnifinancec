import { Disciplina } from "./disciplina.model";

export class Curso{
    CursoId!: number;
    Nome!: string;
    Disciplinas!: Disciplina[];
}