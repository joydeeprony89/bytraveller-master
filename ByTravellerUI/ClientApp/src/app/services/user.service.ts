import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class UserService {
constructor(public router: Router) {}

public messageSource = new BehaviorSubject<any>(null);

 storeData(data) {
    localStorage.setItem('userData', JSON.stringify(data));
    this.messageSource.next(data);
    return this.router.navigate(['']);
}

getData() {
   return JSON.parse(localStorage.getItem('userData'));
}

sessionIn() {
   let A;
   if (this.getData()) {
       A = this.router.navigate([''], this.getData());
   }
   return A;
}

sessionOut() {
   debugger;
   let A;
   if (!this.getData()) {
     A = this.router.navigate(['']);
   }
   return A;
}

logOut() {
   localStorage.setItem('userData', '');
   localStorage.clear();
   this.messageSource.next('');
   return this.router.navigate(['']);
}

signIn(userName,password): boolean{
  return true;
 }
}