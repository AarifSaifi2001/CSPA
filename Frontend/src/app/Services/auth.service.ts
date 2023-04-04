import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserForLogIn } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private http: HttpClient){ }

authUser(user: UserForLogIn){

  return this.http.post("http://localhost:5000/api/account/login", user);
  // let userArray = [];

  // if(localStorage.getItem('Users')){
  //   userArray = JSON.parse(localStorage.getItem('Users'));
  // }

  // return userArray.find(u => {return u.username === user.username && u.password === user.password});
}

currentUsedId(){
  return this.http.get("http://localhost:5000/api/car/userid");
}

}
