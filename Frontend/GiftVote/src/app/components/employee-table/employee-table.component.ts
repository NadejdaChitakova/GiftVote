import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee';
import { Column } from '../../models/column';
import { Button, ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { VoteRequest } from '../../models/voteRequest';
import { BallotService } from '../../services/ballot.service';

@Component({
  selector: 'app-employee-table',
  standalone: true,
  imports: [
    TableModule,
    CommonModule,
    ButtonModule,
    RippleModule,
    ToastModule],
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.css',
  providers: [MessageService]
})

export class EmployeeTableComponent {
  employees!: Employee[];


  constructor(
    private employeeService: EmployeeService,
    private ballotService: BallotService,
    private messageService: MessageService
  ){}

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
  }

  StartBallot(employeeId: number){
    this.ballotService.startBallot(employeeId).subscribe();
  }
}
