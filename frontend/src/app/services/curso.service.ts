import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap, map } from 'rxjs/operators';
import { Curso } from '../models/curso.model'; // Caminho do modelo Aluno
import { environment } from 'src/environment/environment';
import { ApiResponse } from '../models/api-response.model';

@Injectable({
  providedIn: 'root'
})
export class CursoService {
  // private apiUrl = `${environment.apiUrl}/curso`;
  private apiUrlProd = `api/curso`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  //Get
  getCursos(): Observable<Curso[]> {
    return this.http.get<ApiResponse<Curso[]>>(`${this.apiUrlProd}`, this.httpOptions)
      .pipe(
        // tap(response => console.log(response.Data)),
        retry(2),
        map(response => response.Data),
        catchError(this.handleError)
      );
  }

  //Create
  createCurso(curso: Curso): Observable<Curso> {
    return this.http.post<ApiResponse<Curso>>(`${this.apiUrlProd}/create`, curso, this.httpOptions)
      .pipe(
        tap(response => console.log(response.Data)),
        tap(response => {
          if (!response.Success) {
            console.error('Erro no servidor:', response.Message);
          }
        }),
        map(response => response.Data),
        catchError(error => {
          console.error('Erro na comunicação com o servidor:', error);
          console.error('Detalhes do erro:', error.message);
          if (error.error instanceof ErrorEvent) {
            // Erro do lado do cliente ou problema de rede
            console.error('Erro do lado do cliente:', error.error.message);
          } else {
            // O backend retornou um código de resposta de falha
            // A resposta pode conter alguma pista
            console.error(`Backend retornou código ${error.status}, `, `corpo era: `, error.error);
          }
          return throwError(() => new Error('Falha na comunicação com o servidor'));
        })
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
