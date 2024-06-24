import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry , tap, map} from 'rxjs/operators';
import { Curso } from '../models/curso.model'; // Caminho do modelo Aluno
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class CursoService {
  private apiUrl = `${environment.apiUrl}/curso`;
  private apiUrlProd = `api/curso`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  //Get
  getCursos(): Observable<Curso[]> {
    return this.http.get<{Success: boolean, Message: string, Data: Curso[]}>(`${this.apiUrlProd}`, this.httpOptions)
      .pipe(
        tap(response => console.log(response.Data)),
        map(response => response.Data),
        retry(2),
        catchError(this.handleError) 
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
