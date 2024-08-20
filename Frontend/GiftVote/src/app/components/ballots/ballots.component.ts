import { StopBallotRequest } from './../../models/stopBallotRequest';
import { Component } from '@angular/core';
import { EmployeeBallot } from '../../models/getEmployeeBallots';
import { BallotService } from '../../services/ballot.service';
import { RippleModule } from 'primeng/ripple';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { TableModule } from 'primeng/table';
import { Button, ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';
import { VoteService } from '../../services/vote.service';
import { VoteRequest } from '../../models/voteRequest';
import { GiftDialogComponent } from "../../gift-dialog/gift-dialog.component";
import { StatisticDialogComponent } from "../statistic-dialog/statistic-dialog.component";
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-ballots',
  standalone: true,
  imports: [
    TableModule,
    CommonModule,
    ButtonModule,
    RippleModule,
    ToastModule,
    GiftDialogComponent,
    StatisticDialogComponent
],
  templateUrl: './ballots.component.html',
  styleUrl: './ballots.component.css',
  providers: [MessageService]
})
export class BallotsComponent {

  ballots!: EmployeeBallot[];
  voteRequest!: VoteRequest;
  isDialogVisible = false;
  isResultDialogVisible = false;

  constructor(
    private ballotService: BallotService,
    private voteService: VoteService,
    private router: Router){}

  ngOnInit() {
    this.ballotService.getBallots().subscribe({
      next: (data) => {
        this.ballots = data;
        console.log(this.ballots)
      },
      error: (error) => {
        console.log(error, "test");
      }
    });
  }

  StopBallot(ballotId: number, birthdayGay: number){
    let request: StopBallotRequest = {ballotId : ballotId, birthdayGay: birthdayGay};

    this.ballotService.stopBallot(request).subscribe();

    this.router.navigate(["/landingPage"])
  }

  OpenVoteDialog(){
    this.isDialogVisible = true;
  }

  GetResults(){
    this.isDialogVisible = true;
  }
}
