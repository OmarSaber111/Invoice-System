import { AuthService } from './../../Services/auth-service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [RouterLink,ReactiveFormsModule,FormsModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss'
})
export class SignInComponent implements OnInit {
  constructor(private authService:AuthService,private router : Router){}

  ngOnInit(): void {
    localStorage.clear();
  }
  usernameControl = new FormControl();
  passwordControl = new FormControl();

  alertType : string | null = null;
  alertMessage : string | null = null;
  signin(): void {
    this.authService.signin({
      username: this.usernameControl.value!,
      password: this.passwordControl.value!
    }).subscribe({
      next: (res) => {
        if (res.IsSucceeded && res.Data) {
          localStorage.setItem("isLoggedIn","true");
          localStorage.setItem("userName",res.Data.userName);
          localStorage.setItem("groupName",res.Data.groupName);
          localStorage.setItem("token",res.Data.token);
          if(res.Data.groupName=='Admin Group'){
            localStorage.setItem("groupId","1");
          }
          if(res.Data.groupName=='Seller Group'){
            localStorage.setItem("groupId","2");
            localStorage.setItem("sellerId",res.Data.sellerId);
          }
          if(res.Data.groupName=='Buyer Group'){
            localStorage.setItem("buyerId",res.Data.buyerId);
          }



          this.alertType = 'success';
          this.alertMessage = 'Logged in successfully!';
          setTimeout(() => this.alertMessage =null, 2000);
           if (res.Data.groupName === 'Admin Group') {
            this.router.navigate(['/admindashboard']);
          } else if (res.Data.groupName === 'Seller Group') {
            const sellerId = parseInt(localStorage.getItem('sellerId') || '0', 10);
            this.router.navigate(['/frontstore', sellerId]);
          } else if (res.Data.groupName === 'Buyer Group') {
            const buyerId = parseInt(localStorage.getItem('buyerId') || '0', 10);
            this.router.navigate(['/shopping']);
          }
        } else {
          this.alertType = 'danger';
          this.alertMessage = res.ErrorMessage ?? 'Login failed. Please try again.';
          setTimeout(() => this.alertMessage =null, 2000);
        }
      },
      error: () => {
        this.alertType = 'danger';
        this.alertMessage = 'Login failed. Please check your credentials.';
        setTimeout(() => this.alertMessage =null, 2000);
      }
    });
  }

}
