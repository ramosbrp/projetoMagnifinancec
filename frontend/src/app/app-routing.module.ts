import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunoComponent } from './components/aluno/aluno.component';

const routes: Routes = [
  {path: 'alunos', component: AlunoComponent},
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
