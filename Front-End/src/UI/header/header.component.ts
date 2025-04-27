import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit{
  constructor(private router:Router){}
  isLoggedIn : string | null = null;
  groupName : string | null = null;
  ngOnInit(): void {
    this.isLoggedIn = localStorage.getItem('isLoggedIn');
    this.groupName = localStorage.getItem('groupName');

  }
  signout():void{
    localStorage.clear();
    this.router.navigate(['/signin'])
  }
  gotosignin(){
    this.router.navigate(['/signin'])
  }
}
