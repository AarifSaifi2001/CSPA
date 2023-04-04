import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User, UserChangePassowrd } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor(private http: HttpClient) { }

addUser(user: User){

    return this.http.post("http://localhost:5000/api/account/register",user);
//   let users = [];

//   if(localStorage.getItem('Users')){
//     users = JSON.parse(localStorage.getItem('Users'));
//     users = [user, ...users];
//   }else{
//     users = [user];
//   }

//   localStorage.setItem('Users', JSON.stringify(users));
 }

 userInfo(userId: any){

    return this.http.get("http://localhost:5000/api/account/userInfo/"+userId.toString());
 }

 changeUserPassword(userId: any, password: UserChangePassowrd){

  return this.http.put("http://localhost:5000/api/account/updatepassword/"+userId.toString(), password);
 }
}
