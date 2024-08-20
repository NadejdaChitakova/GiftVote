import { StopBallotRequest } from './../models/stopBallotRequest';
import { EmployeeBallot } from './../models/getEmployeeBallots';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BallotStatisticResponse } from '../models/statisticResult';

@Injectable({
  providedIn: 'root'
})
export class BallotService {

  url = "https://localhost:44385/api/Ballot/";

  constructor(private http: HttpClient) { }

  getBallots() : Observable<EmployeeBallot[]>{
    const getBallotUrl = this.url + "GetAll";

    return this.http.get<EmployeeBallot[]>(getBallotUrl);
  }

  startBallot(employeeId: number) : Observable<any>{
    const ballotUrl = this.url + "StartBallot?id=" + employeeId;

    return this.http.get<any>(ballotUrl);
  }

  stopBallot(request: StopBallotRequest) : Observable<any>{
    console.log(request + "ballot")
    const ballotUrl = this.url + "StopBallot";

    return this.http.post<any>(ballotUrl, request);
  }

  getBallotResult(ballotId: number) : Observable<BallotStatisticResponse>{
    const ballotUrl = this.url+ "GetBallotResult" + "?ballotId=" + ballotId;

    return this.http.get<BallotStatisticResponse>(ballotUrl);
  }
}
