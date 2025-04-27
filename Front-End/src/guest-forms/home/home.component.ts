import { Component } from '@angular/core';
import { ProductCarouselComponent } from "../../UI/product-carousel/product-carousel.component";
import { FooterComponent } from "../../UI/footer/footer.component";
import { Router } from '@angular/router';
import { HeaderComponent } from "../../UI/header/header.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ProductCarouselComponent, HeaderComponent, FooterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  constructor(private router: Router) {}
  formId:number = 8;
  gotosignup():void{
    this.router.navigate(['/signup']);
  }
}
