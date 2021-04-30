import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BurritoService {
  public static isLogged: boolean;

  constructor() { 
    BurritoService.isLogged = false;
  }

  getLoggedInfo() {
    return BurritoService.isLogged;
  }

  setLogInfo(status: boolean) {
    BurritoService.isLogged = status;
  }
}
