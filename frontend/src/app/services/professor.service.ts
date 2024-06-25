import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap, map } from 'rxjs/operators';
import { Professor } from '../models/professor.model'; // Substitua pelo caminho correto para o modelo Professor
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  // private apiUrl = `${environment.apiUrl}/professor`; 
  private apiUrlProd = `api/professor`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  // Buscar todos os professores
  getProfessores(): Observable<Professor[]> {
    return this.http.get<{ Success: boolean, Message: string, Data: Professor[] }>(`${this.apiUrlProd}`, this.httpOptions)
      .pipe(
        tap(response => console.log(response)),
        retry(2),
        map(response => response.Data),
        catchError(this.handleError)
      );
  }

  // Buscar um professor pelo ID
  getProfessorById(id: number): Observable<Professor> {
    const url = `${this.apiUrlProd}/${id}`;
    return this.http.get<Professor>(url, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Criar um novo professor
  createProfessor(professor: Professor): Observable<Professor> {
    return this.http.post<{ Success: boolean, Message: string, Data: Professor }>(`${this.apiUrlProd}/create`, professor, this.httpOptions)
      .pipe(
        retry(2),
        map(response => response.Data),
        catchError(this.handleError)
      );
  }

  // Atualizar um professor
  updateProfessor(id: number, professor: Professor): Observable<any> {
    const url = `${this.apiUrlProd}/${id}`;
    return this.http.put(url, professor, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Deletar um professor
  deleteProfessor(id: number): Observable<Professor> {
    const url = `${this.apiUrlProd}/${id}`;
    return this.http.delete<Professor>(url, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Tratar erros
  private handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Erro: ${error.error.message}`;
    } else {
      errorMessage = `Código do erro: ${error.status}\nMensagem: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}
