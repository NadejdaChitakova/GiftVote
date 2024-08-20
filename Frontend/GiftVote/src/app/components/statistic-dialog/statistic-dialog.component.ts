import { BallotService } from './../../services/ballot.service';
import { Component, Input } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { BallotStatisticResponse } from '../../models/statisticResult';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-statistic-dialog',
  standalone: true,
  imports: [DialogModule, ButtonModule, CommonModule],
  templateUrl: './statistic-dialog.component.html',
  styleUrl: './statistic-dialog.component.css'
})
export class StatisticDialogComponent {
  @Input() isResultDialogVisible: boolean = false;
  @Input() ballotId!: number;
  ballotResponse !: BallotStatisticResponse;

  constructor(private ballotService : BallotService){}

  ngOnInit(){
    this.ballotService.getBallotResult(this.ballotId).subscribe({
      next: (data) => {
        this.ballotResponse = data;
      },
      error: (error) => {
        console.log(error, "test");
      }
    });
  }

  showDialog() {
    this.isResultDialogVisible = true;
  }

  closeDialog(){
    this.isResultDialogVisible = false;
  }
}
