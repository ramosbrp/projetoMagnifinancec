import { Component, OnInit } from '@angular/core';
import { AlunoService } from 'src/app/services/aluno.service';
import { Aluno } from 'src/app/models/aluno.model';

@Component({
    selector: 'app-aluno',
    templateUrl: './aluno-list.component.html',
    styleUrls: ['./aluno-list.component.css']
})

export class AlunoComponent implements OnInit{

    alunos: Aluno[] = [];

    constructor(private alunoService: AlunoService) {}

    ngOnInit() {
        
        this.getAlunos();
    }

    
    getAlunos(): void {
        this.alunoService.getAlunos().subscribe({
          next: (alunos) => {
            this.alunos = alunos;
          },
          error: (error) => {
            console.error(error);
          }
          // Você pode adicionar 'complete' aqui, se houver alguma lógica a ser executada quando a Observable terminar
          // complete: () => {
          //   console.log('Observable completado.');
          // }
        });
      }
}