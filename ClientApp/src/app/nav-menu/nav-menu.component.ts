import { Component } from '@angular/core';
import { BurritoService } from '../burrito.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  usernameParam: string;

  constructor(private burritoService: BurritoService) {
    // this.usernameParam = this.burritoService.getUsername();
    this.usernameParam = localStorage.getItem("logged");
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    localStorage.clear();
  }
}
