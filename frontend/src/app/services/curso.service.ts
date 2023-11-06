import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Curso } from '../models/curso.model'; // Caminho do modelo Aluno
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class CursoService {
  private apiUrl = `${environment.apiUrl}/curso`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {}

  //Get
  getCursos(): Observable<Curso[]> {
    console.log('ok')
    return this.http.get<Curso[]>(`${this.apiUrl}`, this.httpOptions)
    .pipe(
        retry(2), // Tenta a chamada novamente se falhar
        catchError(this.handleError) // Trata erros em caso de falha
        );
  }

  //Create
  createCurso(curso: Curso): Observable<Curso> {
    return this.http.post<Curso>(`${this.apiUrl}/create`, curso, this.httpOptions)
      .pipe(
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
            console.log('erro')
      errorMessage = `Código do erro: ${error.status}\nMensagem: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
