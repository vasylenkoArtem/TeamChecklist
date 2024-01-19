import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private baseUrl = 'http://localhost:5236';

    constructor(private http: HttpClient) { }

    public get<T>(endpoint: string): Observable<T> {
        const url = `${this.baseUrl}/${endpoint}`;
        return this.http.get<T>(url);
    }

    public post<T>(endpoint: string, data: any): Observable<T> {
        const url = `${this.baseUrl}/${endpoint}`;
        return this.http.post<T>(url, data);
    }

    public put<T>(endpoint: string, data: any): Observable<T> {
        const url = `${this.baseUrl}/${endpoint}`;
        return this.http.put<T>(url, data);
    }

    public delete<T>(endpoint: string): Observable<T> {
        const url = `${this.baseUrl}/${endpoint}`;
        return this.http.delete<T>(url);
    }
}