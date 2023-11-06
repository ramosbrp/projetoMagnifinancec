import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunoComponent } from './components/aluno/list/aluno-list.component';
import { CursoFormComponent } from './components/curso/create-edit/curso-form.component';
import { CursoListComponent } from './components/curso/list/curso-list.component';

const routes: Routes = [
  {path: 'cursos', component: CursoListComponent},
  {path: 'cursos/novo', component: CursoFormComponent},

  {path: 'professores', component: CursoFormComponent},
  {path: 'professores/novo"', component: CursoFormComponent},

  {path: 'alunos', component: AlunoComponent},
  {path: 'alunos/novo', component: AlunoComponent},

  {path: 'matriculas', component: AlunoComponent},
  {path: 'matriculas/nova', component: AlunoComponent},


  // Adicione outras rotas aqui conforme necessário
  // { path: 'professores', component: ProfessorComponent },
  // { path: 'matriculas', component: MatriculaComponent },
  // { path: '', redirectTo: '/alunos', pathMatch: 'full' }, // Redireciona para 'alunos' como padrão
  // { path: '**', component: PageNotFoundComponent }, // Rota curinga para 'página não encontrada'
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
