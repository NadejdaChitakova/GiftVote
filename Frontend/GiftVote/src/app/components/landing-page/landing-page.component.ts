import { Component } from '@angular/core';
import { EmployeeTableComponent } from "../employee-table/employee-table.component";
import { BallotsComponent } from "../ballots/ballots.component";
import { ButtonModule } from 'primeng/button';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [EmployeeTableComponent, BallotsComponent, ButtonModule],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {

  constructor(private authService: AuthService,
              private router: Router){}

  logOut(){
    this.authService.logout();

    this.router.navigate(["/login"])
  }
}
