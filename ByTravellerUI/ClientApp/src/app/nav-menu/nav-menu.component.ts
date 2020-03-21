import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})

export class NavMenuComponent implements OnInit{
  public isExpanded : boolean;
  public isLoggedIn : boolean;
  public userData: any;

  constructor(public user: UserService){
    this.setUserSessionData();
  }

  ngOnInit() {
    this.user.messageSource.subscribe(message =>
      {
        if(message != null) {
          this.userData = message;
          this.isLoggedIn = true;
        }
      } );
 }    

  public logOut(){
    this.user.logOut();
    this.isLoggedIn = false;
  }

  public setUserSessionData(){
    this.userData = this.user.getData();
    this.isLoggedIn = this.userData?true:false;
  }
}
