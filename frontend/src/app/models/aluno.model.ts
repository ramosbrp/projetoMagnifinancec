export interface Matricula{


}

export class Aluno{
    Id!: number;
    Nome!: string;
    DataNascimento!: Date;
    NumeroMatricula!: string;
    Matriculas!: Matricula[];

}