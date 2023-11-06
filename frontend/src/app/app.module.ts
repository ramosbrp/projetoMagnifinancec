import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { AlunoComponent } from './components/aluno/list/aluno-list.component';
import { CursoFormComponent } from './components/curso/create-edit/curso-form.component';

import { AlunoService } from './services/aluno.service';
import { CursoService } from './services/curso.service';
import { ProfessorService } from './services/professor.service';

import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    AlunoComponent,
    CursoFormComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    AlunoService,
    CursoService,
    ProfessorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
