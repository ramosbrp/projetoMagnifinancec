import { Component, OnInit } from '@angular/core';
import { CursoService } from '../../../services/curso.service';
import { Curso } from '../../../models/curso.model';
import { ProfessorService } from 'src/app/services/professor.service';
import { FormArray, FormBuilder, FormGroup, } from '@angular/forms';
import { Professor } from 'src/app/models/professor.model';

@Component({
  selector: 'app-curso-form',
  templateUrl: './curso-form.component.html',
  styleUrls: ['./curso-form.component.css', '../../../../styles.scss']
})
export class CursoFormComponent implements OnInit {
    cursoForm: FormGroup;
    professores: Professor[] = []; // Substitua 'any' pelo tipo correto se tiver um modelo para professores
  
    constructor(
      private fb: FormBuilder,
      private cursoService: CursoService,
      private professorService: ProfessorService
    ) {
      this.cursoForm = this.fb.group({
        nome: '',
        disciplinas: this.fb.array([])
      });
    }
  
    ngOnInit(): void {
      this.professorService.getProfessores().subscribe({
        next: (professores) => {
          this.professores = professores
          console.log(professores)
        },
        error: (error) => {
          console.error(error);
        }
      });
    }
  
    get disciplinas(): FormArray {
      return this.cursoForm.get('disciplinas') as FormArray;
    }
  
    novaDisciplina(): FormGroup {
      return this.fb.group({
        nome: '',
        professorId: '' // Você pode armazenar o ID do professor aqui
      });
    }
  
    adicionarDisciplina(): void {
      this.disciplinas.push(this.novaDisciplina());
    }
  
    removerDisciplina(index: number): void {
      this.disciplinas.removeAt(index);
    }
  
    onSubmit(): void {
      if (this.cursoForm.valid) {
        this.cursoService.createCurso(this.cursoForm.value).subscribe(
          // Trate a resposta aqui
        );
      }
    }
  }
