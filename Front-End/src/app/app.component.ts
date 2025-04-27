import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SignUpComponent } from "../auth-forms/sign-up/sign-up.component";
import { HeaderComponent } from "../UI/header/header.component";
import { FooterComponent } from "../UI/footer/footer.component";
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'invoicing-system';
}
