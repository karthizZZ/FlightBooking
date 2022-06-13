import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
const AUTH_API = 'https://localhost:5050/api/user/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }
  login(username: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + 'Login', {
      Email:username,
      Password:password
    }, httpOptions);
  }
  register(firstname: string,lastname:string, email: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + 'AddNewUser', {
      FirstName:firstname,
      LastName:lastname,
      Email:email,
      Password:password
    }, httpOptions);
  }
}