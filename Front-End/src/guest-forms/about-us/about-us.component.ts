import { Component } from '@angular/core';
import { HeaderComponent } from "../../UI/header/header.component";
import { FooterComponent } from "../../UI/footer/footer.component";
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-about-us',
  standalone: true,
  imports: [HeaderComponent, FooterComponent,RouterLink],
  templateUrl: './about-us.component.html',
  styleUrl: './about-us.component.scss'
})
export class AboutUsComponent {

}
