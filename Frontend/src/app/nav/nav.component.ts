import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../Services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{

  search: string = '';
  userLogIn: string;

  constructor(private alertify:AlertifyService){

  }

  ngOnInit(): void {

  }

  loggedIn(){
    this.userLogIn = localStorage.getItem('username');
    return this.userLogIn;
  }

  loggedOut(){
    this.alertify.success("Logout successfull");
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('currentUserId');
  }
}
