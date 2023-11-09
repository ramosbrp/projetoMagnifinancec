import { Component } from "@angular/core";

import { Professor } from "src/app/models/professor.model";
import { ProfessorService } from "src/app/services/professor.service";

@Component({
    selector: 'app-professor',
    templateUrl: './professor-list.component.html',
    styleUrls: ['./professor-list.component.css', '../../../../styles.scss']
})

export class ProfessorComponent{
    professores: Professor[] = [];

    constructor(private professorService: ProfessorService){}

    ngOnInit(){
        this.getProfessores();
    }

    getProfessores(): void{
        this.professorService.getProfessores().subscribe({
            next: (professores) =>{
                this.professores = professores;
            },
            error: (error) => {
                console.error(error);
            }
        });
    }
}
