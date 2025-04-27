import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product.model';
import { HeaderComponent } from "../../UI/header/header.component";
import { ProductCarouselComponent } from "../../UI/product-carousel/product-carousel.component";
import { Router } from '@angular/router';
import { ProductsService } from '../../Services/products.service';
import { FooterComponent } from "../../UI/footer/footer.component";

@Component({
  selector: 'app-shopping',
  standalone: true,
  imports: [HeaderComponent, FooterComponent, ProductCarouselComponent],
  templateUrl: './shopping.component.html',
  styleUrl: './shopping.component.scss'
})
export class ShoppingComponent implements OnInit {
  constructor(private router:Router, private productService:ProductsService){ }
  ngOnInit() {
    this.getAllProducts();
  }
  products:Product[] = [];
  selectedProduct:Product={} as Product;
  getAllProducts(): void {
    this.productService.getAllProducts().subscribe({
      next: (res) => {
        this.products = res.Data;
      },
      error: (err) => {
        console.error('Failed to load products', err);
      }
    });
  }

  buyProduct(productid:number):void{
    this.router.navigate(['/checkout', productid]);
  }
}
