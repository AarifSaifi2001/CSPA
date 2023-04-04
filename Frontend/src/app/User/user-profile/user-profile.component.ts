import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/user';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  user : any;
  currentUserId: any;

  constructor(private userServ: UserService) { }

  ngOnInit() {

    this.currentUserId = localStorage.getItem('currentUserId');

    this.userServ.userInfo(this.currentUserId).subscribe((data) => {
      this.user = data;
      console.log(this.user);

    })

  }

}
