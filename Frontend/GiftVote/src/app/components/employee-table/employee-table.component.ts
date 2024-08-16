import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../../services/employee.service';
import { Column } from '../../models/Column';
import { Employee } from '../../models/employee';

@Component({
  selector: 'app-employee-table',
  standalone: true,
  imports: [
    TableModule,
    CommonModule],
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.css'
})

export class EmployeeTableComponent {
  employees!: Employee[];
  columns!: Column[];

  constructor(private employeeService: EmployeeService){}

  ngOnInit() {
    this.employeeService.getEmployees().subscribe({
      next: (data) => {
        this.employees = data;
        console.log(this.employees);
      },
      error: (error) => {
        console.log(error, "test");
      }
    });

    this.columns = [
      {field: 'fullName', header: 'Full name'},
      {field: '', header: "Butons"}
    ];
  }
}
