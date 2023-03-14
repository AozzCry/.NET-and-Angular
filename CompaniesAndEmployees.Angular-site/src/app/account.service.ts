import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponse, UserLogin, UserRegister } from './models';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private url = 'http://localhost:5026/auth';

  constructor(private http: HttpClient) {}

  login(newEmployee: UserLogin): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.url + '/login', newEmployee);
  }

  register(newEmployee: UserRegister): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.url + '/register', newEmployee);
  }
}
