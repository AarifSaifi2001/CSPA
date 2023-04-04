export interface User {
  username: string;
  email: string;
  password: string;
  mobileno: number;
}


export interface UserForLogIn {
  id: any;
  username: string;
  email: string;
  token: string;
}

export interface UserChangePassowrd{
  password: string;
}
