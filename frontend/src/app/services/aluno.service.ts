import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, map, tap } from 'rxjs/operators';
import { Aluno } from '../models/aluno.model'; // Caminho do modelo Aluno
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {
  // private apiUrl = `${environment.apiUrl}/aluno`;

  private apiUrlProd = `api/aluno`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  //Get
  getAlunos(): Observable<Aluno[]> {
    return this.http.get<{ Success: boolean, Message: string, Data: Aluno[] }>(this.apiUrlProd, this.httpOptions)
      .pipe(
        retry(2),
        map(response => response.Data),
        catchError(this.handleError)
      );
  }

  //Create
  createAluno(aluno: Aluno): Observable<Aluno> {

    return this.http.post<{ Success: boolean, Message: string, Data: Aluno }>(`${this.apiUrlProd}/create`, aluno, this.httpOptions)
      .pipe(
        // tap(response => console.log(response.Data)),
        
        map(response => response.Data),
        catchError(this.handleError)
      );
  }

  // Método para tratar erros
  private handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro do lado do cliente
      errorMessage = `Erro: ${error.error.message}`;
    } else {
      // Erro do lado do servidor
      errorMessage = `Código do erro: ${error.status}\nMensagem: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
