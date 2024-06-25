import { Component } from '@angular/core';

import { Aluno } from '../../../models/aluno.model';
import { AlunoService } from 'src/app/services/aluno.service';
import { FormBuilder, FormGroup, Validators, } from '@angular/forms';

@Component({
  selector: 'app-aluno-form',
  templateUrl: './aluno-form.component.html',
  styleUrls: ['./aluno-form.component.css', '../../../../styles.scss']
})
export class AlunoFormComponent  {
    alunoForm: FormGroup;
    alunoCadastrado: Aluno | null = null;
  
    constructor(
      private fb: FormBuilder,
      private alunoService: AlunoService
    ) {
      this.alunoForm = this.fb.group({
        nome: ['', Validators.required],
        dataNascimento: ['', Validators.required],
      });
    }
  
    onSubmit(): void {
      if (this.alunoForm.valid) {
        this.alunoService.createAluno(this.alunoForm.value).subscribe({
          next: (aluno: Aluno) => {
            this.alunoCadastrado = aluno; 
          },
          error: (erro) => {
            console.error('Erro ao cadastrar o aluno:', erro);
            // Trate o erro conforme necessário
          }
      });
      }
    }
  }
