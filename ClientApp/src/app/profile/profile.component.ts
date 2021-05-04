import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BurritoService } from '../burrito.service';
import { User } from '../users/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  username: string;
  user: User;
  isLogged: boolean;
  friends: Friend[];
  
  constructor(
    private route: ActivatedRoute, 
    private http: HttpClient,
    private burritoService: BurritoService,
    @Inject('BASE_URL') baseUrl: string
    ) { 
    this.isLogged = this.burritoService.getLoggedInfo();
    
    if (this.isLogged) {
      http.get<User[]>(baseUrl + 'api/user').subscribe(result => {
        this.user = result.filter(it => it.username === this.username)[0];
      });

      http.get<Friend[]>(baseUrl + 'api/friend').subscribe(result => {
        this.friends = result;
      });
    }
  }

  ngOnInit() {
    this.username = this.route.snapshot.paramMap.get('username');
  }
}

// interface User {
//   username: string;
//   firstName: string;
//   lastName: string;
//   email: string;
//   phone: string;
//   password: string;
//   sex: number;
//   city: string;
//   country: string;
// }

interface Friend {
  username: string;
  friendUsername: string;
  friendshipData: string;
}