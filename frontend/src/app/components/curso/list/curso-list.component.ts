import { Component } from '@angular/core';
import { CursoService } from '../../../services/curso.service';
import { Curso } from '../../../models/curso.model';

@Component({
  selector: 'app-curso-list',
  templateUrl: './curso-list.component.html',
  styleUrls: ['./curso-list.component.css', '../../../../styles.scss']
})
export class CursoListComponent{
  cursos: Curso[] = [];

  constructor(private cursoService: CursoService) {}

  ngOnInit(){
    this.getCursos();
  }

  getCursos(): void{
    this.cursoService.getCursos().subscribe({
      next: (cursos) => {
        this.cursos = cursos
      },
      error: (error => {
        console.error(error);
      })
    });
  }

 
}
