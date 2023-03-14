import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company, CompanyVm } from './models';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  private url = 'http://localhost:5026/company';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Company[]> {
    return this.http.get<Company[]>(this.url);
  }

  addNew(newEmployee: CompanyVm): Observable<Company> {
    return this.http.post<Company>(this.url, newEmployee);
  }

  deleteById(id: number): Observable<Company> {
    return this.http.delete<Company>(`${this.url}/${id}`);
  }
}
