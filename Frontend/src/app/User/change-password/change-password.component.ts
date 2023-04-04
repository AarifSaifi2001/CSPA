import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validator, Validators } from '@angular/forms';
import * as alertify from 'alertifyjs';
import { UserChangePassowrd } from 'src/app/Models/user';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  registrationForm : FormGroup;
  userSubmit : boolean = false;
  user: UserChangePassowrd;
  currentUserId: any;

  constructor(private alertify: AlertifyService, private userServ: UserService) { }

  ngOnInit() {

    this.registrationForm = new FormGroup({

      password : new FormControl(null, [Validators.required, Validators.minLength(8)]),
      confirmpassword : new FormControl(null, Validators.required)
    }, this.passwordMatchingValidator);
  }



  passwordMatchingValidator(fg: FormGroup): Validators | null {

    return fg.get('password')?.value === fg.get('confirmpassword')?.value ?  null : {notmatched : true};

  }

  onSubmit(){
    this.userSubmit = true;
    this.currentUserId = localStorage.getItem('currentUserId');

    if(this.registrationForm.valid){
      // this.user = Object.assign(this.user, this.registrationForm.value);
      this.userServ.changeUserPassword(this.currentUserId, this.userData()).subscribe(() => {
        this.userSubmit = false;
        this.registrationForm.reset();
        this.alertify.success('Congrats you have changed your password successfully');
      }
      // , (error) => {
      //   console.log(error);
      //   this.alertify.error(error.error);
      // }
      );

    }
    else{
      this.alertify.error('Please provide valid data');
    }
  }

  userData(): UserChangePassowrd{
    return this.user = {
      password : this.registrationForm.get('password').value
    }
  }


}
