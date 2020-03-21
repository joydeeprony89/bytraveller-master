import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { AuthService } from 'angular-6-social-login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [AuthService]
})
export class HomeComponent {
  public data: any;
  public userData: any;

  constructor () {
    }
}
