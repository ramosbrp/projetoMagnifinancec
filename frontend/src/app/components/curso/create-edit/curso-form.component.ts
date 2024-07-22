import { Component, OnInit } from '@angular/core';
import { CursoService } from '../../../services/curso.service';
import { Curso } from '../../../models/curso.model';
import { ProfessorService } from 'src/app/services/professor.service';
import { FormArray, FormBuilder, FormGroup, } from '@angular/forms';
import { Professor } from 'src/app/models/professor.model';
import { Disciplina } from 'src/app/models/disciplina.model';

@Component({
  selector: 'app-curso-form',
  templateUrl: './curso-form.component.html',
  styleUrls: ['./curso-form.component.scss', '../../../../styles.scss']
})
export class CursoFormComponent implements OnInit {
    cursoForm: FormGroup;
    professores: Professor[] = []; 
  
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
        },
        error: (error) => {
          console.error(error);
        }
      });

      this.disciplinas.controls.forEach((control, index) => {
        control.valueChanges.subscribe( value =>{
          console.log(value, index)
        })
      });

    }
  
    get disciplinas(): FormArray {
      return this.cursoForm.get('disciplinas') as FormArray;
    }
  

    novaDisciplina(): FormGroup {
      return this.fb.group({
        nome: '',
        professorId: null // Armazenar o ID do professor aqui
      });
    }
  
    adicionarDisciplina(): void {
      const novaDisciplina = this.novaDisciplina();
      this.disciplinas.push(novaDisciplina);

      const index = this.disciplinas.length -1;

      novaDisciplina.get('professorId')?.valueChanges.subscribe( value => {
        console.log(`${value}`)

      })

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
