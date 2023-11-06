import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Professor } from '../models/professor.model'; // Substitua pelo caminho correto para o modelo Professor
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  private apiUrl = `${environment.apiUrl}/professor`; // Substitua pela URL correta da API

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {}

  // Buscar todos os professores
  getProfessores(): Observable<Professor[]> {
    return this.http.get<Professor[]>(this.apiUrl, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  // Buscar um professor pelo ID
  getProfessorById(id: number): Observable<Professor> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Professor>(url, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Criar um novo professor
  createProfessor(professor: Professor): Observable<Professor> {
    return this.http.post<Professor>(this.apiUrl, professor, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Atualizar um professor
  updateProfessor(id: number, professor: Professor): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put(url, professor, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  // Deletar um professor
  deleteProfessor(id: number): Observable<Professor> {
    const url = `${this.apiUrl}/${id}`;
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
