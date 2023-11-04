import  { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environment/environment';

@Injectable({
    providedIn: 'root'
})

export class MyService {
    private apiUrl = `${environment.apiUrl}/Home/Teste`;

    constructor(private http: HttpClient ) {}

    getSomething() {
        return this.http.get(this.apiUrl)
    }
}