import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-friend',
  templateUrl: './friend.component.html',
  styleUrls: ['./friend.component.css']
})
export class FriendComponent {
  public friends: Friend[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Friend[]>(baseUrl + 'api/friend').subscribe(result => {
      this.friends = result;
    }, error => console.error(error));
  }

}

interface Friend {
  username: string;
  friendUsername: string;
  friendshipDate: string;
}