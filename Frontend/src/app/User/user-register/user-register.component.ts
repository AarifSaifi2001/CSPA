import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validator, Validators } from '@angular/forms';
import * as alertify from 'alertifyjs';
import { User } from 'src/app/Models/user';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {

  registrationForm : FormGroup;
  userSubmit : boolean = false;
  user: User;

  constructor(private alertify: AlertifyService, private userServ: UserService) { }

  ngOnInit() {

    this.registrationForm = new FormGroup({

      username : new FormControl(null, Validators.required),
      useremail : new FormControl(null,[Validators.required, Validators.email]),
      password : new FormControl(null, [Validators.required, Validators.minLength(8)]),
      confirmpassword : new FormControl(null, Validators.required),
      mobileno : new FormControl(null, [Validators.required, Validators.maxLength(10)])
    }, this.passwordMatchingValidator);
  }



  passwordMatchingValidator(fg: FormGroup): Validators | null {

    return fg.get('password')?.value === fg.get('confirmpassword')?.value ?  null : {notmatched : true};

  }

  onSubmit(){
    this.userSubmit = true;

    if(this.registrationForm.valid){
      // this.user = Object.assign(this.user, this.registrationForm.value);
      this.userServ.addUser(this.userData()).subscribe(() => {
        this.userSubmit = false;
        this.registrationForm.reset();
        this.alertify.success('Congrats you have registered successfully');
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

  userData(): User{
    return this.user = {
      username : this.registrationForm.get('username').value,
      email : this.registrationForm.get('useremail').value,
      password : this.registrationForm.get('password').value,
      mobileno : this.registrationForm.get('mobileno').value
    }
  }

}
