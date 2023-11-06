import { Component } from '@angular/core';
import { CursoService } from '../../../services/curso.service';
import { Aluno } from '../../../models/aluno.model';
import { AlunoService } from 'src/app/services/aluno.service';
import { FormArray, FormBuilder, FormGroup, } from '@angular/forms';

@Component({
  selector: 'app-aluno-form',
  templateUrl: './aluno-form.component.html',
  styleUrls: ['./aluno-form.component.css', '../../../../styles.scss']
})
export class AlunoFormComponent  {
    [x: string]: any;
    alunoForm: FormGroup;
    alunos: any[] = []; 
    alunoCadastrado: Aluno | null = null;
  
    constructor(
      private fb: FormBuilder,
      private alunoService: AlunoService
    ) {
      this.alunoForm = this.fb.group({
        nome: '',
        disciplinas: this.fb.array([])
      });
    }
  
    
  
    get disciplinas(): FormArray {
      return this.alunoForm.get('disciplinas') as FormArray;
    }
  
    
  
    onSubmit(): void {
      if (this.alunoForm.valid) {
        this.alunoService.createAluno(this.alunoForm.value).subscribe({
          next: (aluno: Aluno) => {
            this.alunoCadastrado = aluno; // Armazena o aluno retornado pelo servidor
            // Se desejar, aqui você pode redirecionar o usuário para outra página
            // ou limpar o formulário para nova entrada
          },
          error: (erro) => {
            console.error('Erro ao cadastrar o aluno:', erro);
            // Trate o erro conforme necessário
          }
      });
      }
    }
  }
