import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  username: string;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;

  constructor(private route: ActivatedRoute) { 
    this.username = null;
    this.firstName = 'Alex';
    this.lastName = 'Cojocaru';
    this.email = 'alex.cojocaru73@gmail.com';
    this.phone = '214348234';
  }

  ngOnInit() {
    this.username = this.route.snapshot.paramMap.get('username');
  }

}
