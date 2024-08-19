import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { VoteRequest } from '../models/voteRequest';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  url = "https://localhost:44385/api/Vote/";

  constructor(private http: HttpClient) { }

  vote(request: VoteRequest) : Observable<any>{
    const voteUrl = this.url + "CreateVote";

    return this.http.post<any>(voteUrl, request);
  }
}
