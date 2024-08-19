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
import { StopBallotRequest } from '../../models/stopBallotRequest';
import { GiftDialogComponent } from "../../gift-dialog/gift-dialog.component";

@Component({
  selector: 'app-ballots',
  standalone: true,
  imports: [
    TableModule,
    CommonModule,
    ButtonModule,
    RippleModule,
    ToastModule,
    GiftDialogComponent
],
  templateUrl: './ballots.component.html',
  styleUrl: './ballots.component.css',
  providers: [MessageService]
})
export class BallotsComponent {

  ballots!: EmployeeBallot[];
  voteRequest!: VoteRequest;
  stopBallotRequest!: StopBallotRequest;
  isDialogVisible = false;

  constructor(
    private ballotService: BallotService,
    private voteService: VoteService ){}

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
    this.stopBallotRequest.ballotId = ballotId;
    this.stopBallotRequest.birthdayGay= birthdayGay;

    this.ballotService.stopBallot(this.stopBallotRequest).subscribe();
  }

  OpenVoteDialog(){
    this.isDialogVisible = true;
    //this.voteService.vote(employeeId).subscribe();
  }
}
