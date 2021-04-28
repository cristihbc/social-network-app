import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {
  public users: User[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>(baseUrl + 'api/user').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
   }
}

interface User {
  username: string;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  password: string;
  sex: number;
  city: string;
  country: string;
}