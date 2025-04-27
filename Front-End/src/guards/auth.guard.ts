import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    if (this.isLoggedIn()) {
      return true;
    } else {
      localStorage.clear();
      this.router.navigate(['/signin']);
      return false;
    }
  }

  private isLoggedIn(): boolean {
    const isLoggedIn = localStorage.getItem('isLoggedIn');
    if(isLoggedIn) {return true}
    else { return false}
  }
}
