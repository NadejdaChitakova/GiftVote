import { Component } from '@angular/core';
import { EmployeeTableComponent } from "../employee-table/employee-table.component";
import { BallotsComponent } from "../ballots/ballots.component";

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [EmployeeTableComponent, BallotsComponent],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {

}
