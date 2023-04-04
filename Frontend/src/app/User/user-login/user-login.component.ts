import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForLogIn } from 'src/app/Models/user';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  constructor(private authServ: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  onLogin(loginform: NgForm){

    console.log(loginform.value);

    const token = this.authServ.authUser(loginform.value).subscribe(
      (response: UserForLogIn) => {
        console.log(response);
        const user = response;
        localStorage.setItem('currentUserId', user.id);
        localStorage.setItem('token', user.token);
        localStorage.setItem('username', user.username);
        this.alertify.success("Login Successfull");
       this.router.navigateByUrl('');
      }
      // , (error) => {
      //   console.log(error);
      //   this.alertify.error(error.error);
      // }
    );

    // if(token){
    //   localStorage.setItem('token', token.username)
    //   this.alertify.success("Login Successfull");
    //   this.router.navigateByUrl('');
    // }

    // else{
    //   this.alertify.error("Login Not Successfull");
    // }
  }
}
