import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunoComponent } from './components/aluno/list/aluno-list.component';
import { CursoFormComponent } from './components/curso/create-edit/curso-form.component';
import { CursoListComponent } from './components/curso/list/curso-list.component';
import { AlunoFormComponent } from './components/aluno/create-edit/aluno-form.component';
import { ProfessorFormComponent } from './components/professor/create-edit/professor-form.component';
import { ProfessorComponent } from './components/professor/list/professor-list.component';

const routes: Routes = [
  {path: 'cursos', component: CursoListComponent},
  {path: 'cursos/novo', component: CursoFormComponent},

  {path: 'professores', component: ProfessorComponent},
  {path: 'professores/novo', component: ProfessorFormComponent},

  {path: 'alunos', component: AlunoComponent},
  {path: 'alunos/novo', component: AlunoFormComponent},

  {path: 'matriculas', component: AlunoComponent},
  {path: 'matriculas/nova', component: AlunoComponent},


  // { path: '', redirectTo: '/alunos', pathMatch: 'full' }, // Redireciona para 'alunos' como padrão
  // { path: '**', component: PageNotFoundComponent }, // Rota curinga para 'página não encontrada'
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
