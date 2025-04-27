import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BuyerGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    if (this.isBuyer()) {
      return true;
    } else {
      this.router.navigate(['/home']);
      return false;
    }
  }

  private isBuyer(): boolean {
    const groupName = localStorage.getItem('groupName');
    if(groupName=='Buyer Group') {return true}
    else { return false}
  }
}
