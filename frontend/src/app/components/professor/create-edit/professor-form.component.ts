import { Component } from "@angular/core";

import { Professor } from "src/app/models/professor.model";
import { ProfessorService } from "src/app/services/professor.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
    selector: 'app-professor-form',
    templateUrl: './professor-form.component.html',
    styleUrls: ['./professor-form.component.css', '../../../../styles.scss']
})

export class ProfessorFormComponent{
    professorForm: FormGroup;
    professorCadastrado: Professor | null = null;

    constructor(
        private fb: FormBuilder,
        private professorService: ProfessorService
    ){
        this.professorForm = this.fb.group({
            nome: ['', Validators.required],
            dataNascimento: ['', Validators.required],
            salario: ['']
        });
    }

    onSubmit(): void {
        if(this.professorForm.valid){
            this.professorService.createProfessor(this.professorForm.value).subscribe({
                next: (professor: Professor) => {
                    this.professorCadastrado = professor;
                },
                error: (erro) => {
                    console.error('Erro ao cadastrar professor:', erro)
                }
            })
        }
    }
}