import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GiftResponse } from '../models/giftResponse';

@Injectable({
  providedIn: 'root'
})
export class GiftService {

  url = "https://localhost:44385/api/Gift/";

  constructor(private http: HttpClient) { }

  getAll() : Observable<GiftResponse[]>{
    const getEmployeesUrl = this.url + "GetAll";

    return this.http.get<GiftResponse[]>(getEmployeesUrl);
  }
}
