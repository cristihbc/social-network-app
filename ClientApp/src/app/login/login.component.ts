import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { BurritoService } from '../burrito.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  url: string;

  constructor(
    private http: HttpClient, 
    private burritoService: BurritoService,
    @Inject('BASE_URL') baseUrl: string
    ) { 
    this.form = new FormGroup({
      username: new FormControl(),
      password: new FormControl()
    });

    this.url = baseUrl + 'api/user';
  }

  ngOnInit() {
  }

  onSubmit() {
    var user = {
      "username": this.form.get('username').value,
      "password": this.form.get('password').value
    };

    this.fetchUsers(user)
  }

  fetchUsers(user) {
    this.http.get<User[]>(this.url).subscribe(result => {
      if (!this.burritoService.getLoggedInfo()) {
        result.forEach(it => {
          if ((it.username == user["username"]) && (it.password == user["password"])) {
            localStorage.setItem(it.username, it.password);

            this.burritoService.setLogInfo(true);
          }
        });
      }
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
