import { Component, OnInit } from '@angular/core';
import { AuthService, FacebookLoginProvider, GoogleLoginProvider } from 'angular-6-social-login';
import { AuthAPIService } from '../services/auth-api.service';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthService]
})
export class LoginComponent implements OnInit {
  public responseData: any;
  public userPostData = new User();
  public userLoggedIn = false;

  constructor(private socialAuthService: AuthService,
    public authAPIService: AuthAPIService,
    public user: UserService) {

  }

  public socialSignIn(socialPlatform: string) {
    let socialPlatformProvider;
    if (socialPlatform === 'facebook') {
      socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
    } else if (socialPlatform === 'google') {
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    }

    this.socialAuthService.signIn(socialPlatformProvider).then(userData => {
      this.apiConnection(userData);
    });
  }

  apiConnection(data) {
    this.userPostData.email = data.email;
    this.userPostData.name = data.name;
    this.userPostData.provider = data.provider;
    this.userPostData.provider_id = data.id;
    this.userPostData.provider_pic = data.image;
    this.userPostData.token = data.token;
    this.user.storeData(data);
    this.authAPIService.signUp$(this.userPostData).subscribe((res) =>{
      alert(res);
    })
  }

  signIn(userName, password) {
    this.userPostData.email = userName;
    this.userPostData.password = password;
    this.authAPIService.signIn$(this.userPostData).subscribe((res) =>{
      alert(res);
      this.userLoggedIn = res;
    })
  }

  ngOnInit() {
  }
}
