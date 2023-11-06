import { Curso } from './curso.model';
import { Professor } from './professor.model';
import { Matricula } from './aluno.model';

export class Disciplina{

        DisciplinaId!: number;
        Nome!: string;
        CursoId!: number;
        Curso!: Curso;
        Professor!: Professor;
        Matriculas?: Matricula[];
}