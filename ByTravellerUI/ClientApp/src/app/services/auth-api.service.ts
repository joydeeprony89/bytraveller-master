import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Endpoints } from '../shared/endpoints/endpoints';
import { catchError, map } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';
import { User } from '../models/user';

const httpOptions = {
    headers: new Headers({
      'Content-Type':  'application/json'
    })
  };

@Injectable()
export class AuthAPIService {

    constructor(public http: Http) {
    }

   signIn$(credentials: User): Observable<any> {
       return this.http.post(Endpoints.BYTRAVELLER.SIGNIN, JSON.stringify(credentials), httpOptions)
            .pipe(
                map((res) => res.json()),
                catchError((res) => throwError('')));
    }

    signUp$(userData: User): Observable<any> {
      return this.http.post(Endpoints.BYTRAVELLER.SIGNUP, JSON.stringify(userData), httpOptions)
      .pipe(
        map((res) => res.json()),
        catchError((res) => throwError('')));
    }
}