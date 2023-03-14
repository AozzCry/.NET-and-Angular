import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee, EmployeeVm } from './models';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private url = 'http://localhost:5026/employee';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.url);
  }

  addNew(newEmployee: EmployeeVm): Observable<Employee> {
    return this.http.post<Employee>(this.url, newEmployee);
  }

  deleteById(id: number): Observable<Employee> {
    return this.http.delete<Employee>(`${this.url}/${id}`);
  }
}
