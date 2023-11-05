export interface Matricula{


}

export class Aluno{
    AlunoId!: number;
    Nome!: string;
    DataNascimento!: Date;
    NumeroMatricula!: string;
    Matriculas!: Matricula[];

    constructor(init?: Partial<Aluno>){
        Object.assign(this, init);
    }
}