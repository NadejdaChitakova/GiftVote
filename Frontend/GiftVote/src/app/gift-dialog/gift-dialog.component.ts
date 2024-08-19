import { VoteRequest } from './../models/voteRequest';
import { Component, Input } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { AvatarModule } from 'primeng/avatar';
import { GiftService } from '../services/gift.service';
import { EmployeeBallot } from '../models/getEmployeeBallots';
import { GiftResponse } from '../models/giftResponse';
import { FormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { VoteService } from '../services/vote.service';

@Component({
  selector: 'app-gift-dialog',
  standalone: true,
  imports: [DialogModule, ButtonModule, InputTextModule, AvatarModule, FormsModule, DropdownModule],
  templateUrl: './gift-dialog.component.html',
  styleUrl: './gift-dialog.component.css'
})
export class GiftDialogComponent {
  @Input() isVisible: boolean = false;
  @Input() ballot!: EmployeeBallot;
  gifts!: GiftResponse[];
  selectedGift!: GiftResponse;

  constructor(private giftService: GiftService,
              private voteService : VoteService
  ){}

  ngOnInit() {
    this.giftService.getAll().subscribe({
      next: (data) => {
        this.gifts = data;
        console.log(this.gifts)
      },
      error: (error) => {
        console.log(error, "test");
      }
    });
  }

  showDialog() {
      this.isVisible = true;
  }

  closeDialog(){
    this.isVisible = false;
  }

  vote(){

    let voteRequest: VoteRequest = { BallotId: this.ballot.id, GiftId: this.selectedGift.id };

    this.voteService.vote(voteRequest).subscribe();

    this.isVisible = false;
  }
}
