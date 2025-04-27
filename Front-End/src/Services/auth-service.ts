import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignupPayloadModel } from '../models/signup-payload.model';
import { Observable } from 'rxjs';
import { SigninPayloadModel } from '../models/signin-payload.model';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  currentUser$: any;
  constructor(private httpClient:HttpClient) {}
  signup(data: SignupPayloadModel): Observable<any> {
    const api = 'http://invoice.somee.com/api/Auth/signup'
    return this.httpClient.post(api, data);
  }
  signin(data: SigninPayloadModel): Observable<any> {
    const api = 'http://invoice.somee.com/api/Auth/login';
    return this.httpClient.post(api, data);
  }
  signout(data:void):Observable<any>{
    const api = 'http://invoice.somee.com/api/Auth/SignOut';
    return this.httpClient.post(api,data);
  }
}
