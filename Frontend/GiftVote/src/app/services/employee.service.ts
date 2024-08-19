import { Employee } from './../models/employee';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {

  url = "https://localhost:44385/api/Employee/";

  constructor(private http: HttpClient) { }

  getEmployees() : Observable<Employee[]>{
    const getEmployeesUrl = this.url + "GetAll";

    return this.http.get<Employee[]>(getEmployeesUrl);
  }
}
