import { Component } from '@angular/core';

type CollapsedState = {
  curso: boolean;
  aluno: boolean;
  professor: boolean;
  matricula: boolean;
};

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'My University';

  collapsed: CollapsedState = {
    curso: false,
    aluno: false,
    professor: false,
    matricula: false
  };


    toggleCollapse(menuItem: keyof CollapsedState): void {
      this.collapsed[menuItem] = !this.collapsed[menuItem];
    }
}
