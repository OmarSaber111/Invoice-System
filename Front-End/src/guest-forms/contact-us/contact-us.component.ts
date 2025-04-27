import { Component } from '@angular/core';
import { FooterComponent } from '../../UI/footer/footer.component';
import { HeaderComponent } from '../../UI/header/header.component';

@Component({
  selector: 'app-contact-us',
  standalone: true,
  imports: [FooterComponent,HeaderComponent],
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.scss'
})
export class ContactUsComponent {

}
