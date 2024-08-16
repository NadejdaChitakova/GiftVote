import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url = "https://localhost:44385/api/User";

  constructor(  private httpClient: HttpClient,
                private router: Router) { }

  login(login: Login){

    this.httpClient.post<any>(this.url,login).subscribe({
      next: (data) => {
        this.setToken(data);
        //this.router.navigate(["/"])
      },
      error: (err) => {
        this.setToken(null)
      }
    });
  }

  setToken(token: string | null) {
    console.log(window)
    if(token !== null) {
      window.localStorage.setItem("auth_token", token)
    }
    else {
      window.localStorage.removeItem("auth_token")
    }
  }

  getToken() {
    if(typeof window !== "undefined"){
      return window.localStorage.getItem("auth_token")
    }

    return null
  }

  isLoggedIn(){
    console.log("is logged in: " + this.getToken() !== null)
    return this.getToken() !== null;
  }

  logout(){
    this.setToken(null);
    this.router.navigate(["/login"])
  }
}
