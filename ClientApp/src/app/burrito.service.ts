import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BurritoService {
  private static isLogged: boolean;
  private static LOCAL_STORAGE_TAG: string; 
  private static username: string;

  constructor() { 
    BurritoService.isLogged = false;
    BurritoService.LOCAL_STORAGE_TAG = "logged";
  }

  getLoggedInfo() {
    return BurritoService.isLogged;
  }

  setLogInfo(status: boolean) {
    BurritoService.isLogged = status;
  }

  getLoggedTag() {
    return BurritoService.LOCAL_STORAGE_TAG;
  }

  getUsername() {
    return BurritoService.username;
  }

  setUsername(username) {
    BurritoService.username = username;
  }
}
