import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignupPayloadModel } from '../../models/signup-payload.model';
import { AuthService } from '../../Services/auth-service';
import { Router, RouterLink } from '@angular/router';
@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule,RouterLink],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent implements OnInit{
  ngOnInit() {
    localStorage.clear();
  }
  constructor(private authService:AuthService,private router:Router){}
  isSeller : boolean = false;

  firstNameControl = new FormControl();
  lastNameControl = new FormControl();
  name:string = this.firstNameControl.value+" "+this.lastNameControl.value;
  emailControl = new FormControl();
  usernameControl = new FormControl();
  passwordControl = new FormControl();
  confirmPasswordControl = new FormControl();
  nationalIdControl = new FormControl();
  storeNameControl = new FormControl();
  productTypeControl = new FormControl();
  selectedGovernorateControl = new FormControl();



  alertMessage: string | null = null;
  alertType: string = ''; // 'success' or 'danger'

  check() {
    this.isSeller = !this.isSeller;
  }

  //sign up

  signup() {
    const password = this.passwordControl.value;
    const confirmPassword = this.confirmPasswordControl.value;


    // Check if passwords match
    if (password !== confirmPassword) {
      this.alertMessage = 'Passwords do not match!';
      this.alertType = 'danger';
      setTimeout(() => {
        this.alertMessage = '';
      }, 2000);

      return;
    }


    const payload: SignupPayloadModel = {
      name: `${this.firstNameControl.value} ${this.lastNameControl.value}`,
      username: this.usernameControl.value,
      email: this.emailControl.value,
      password: password,
      nationalId: this.nationalIdControl.value,
      isSeller: this.isSeller,
      storeName: this.isSeller ? this.storeNameControl.value : '',
      productType: this.isSeller ? this.productTypeControl.value : '',
      governmentId: this.isSeller ? this.selectedGovernorateControl.value : 0,
    };

    this.authService.signup(payload).subscribe({
      next: () => {
        this.alertMessage = 'Signup successful! Redirecting to Sign In...';
        this.alertType = 'success';
        setTimeout(() => {
          this.router.navigate(['/signin']);

        }, 2000);
      },
      error: (err) => {
        this.alertMessage = `Signup failed: ${err.message}`;
        this.alertType = 'danger';
        setTimeout(() => {
          this.alertMessage =null;
        }, 2000);

      },
    });
  }


  governs = [
    { "id": 1, "name": "Cairo" },
    { "id": 2, "name": "Giza" },
    { "id": 3, "name": "Alexandria" },
    { "id": 4, "name": "Dakahlia" },
    { "id": 5, "name": "Red Sea" },
    { "id": 6, "name": "Beheira" },
    { "id": 7, "name": "Fayoum" },
    { "id": 8, "name": "Gharbia" },
    { "id": 9, "name": "Ismailia" },
    { "id": 10, "name": "Monufia" },
    { "id": 11, "name": "Minya" },
    { "id": 12, "name": "Qaliubiya" },
    { "id": 13, "name": "New Valley" },
    { "id": 14, "name": "Suez" },
    { "id": 15, "name": "Aswan" },
    { "id": 16, "name": "Assiut" },
    { "id": 17, "name": "Beni Suef" },
    { "id": 18, "name": "Port Said" },
    { "id": 19, "name": "Damietta" },
    { "id": 20, "name": "Sharkia" },
    { "id": 21, "name": "South Sinai" },
    { "id": 22, "name": "Kafr El Sheikh" },
    { "id": 23, "name": "Matrouh" },
    { "id": 24, "name": "Luxor" },
    { "id": 25, "name": "Qena" },
    { "id": 26, "name": "North Sinai" },
    { "id": 27, "name": "Sohag" }
  ];

}
